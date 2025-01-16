using System.Diagnostics;
using System.Text.Json;

namespace PumlGenWrapper;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        SaveSettings();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadSettings();
    }

    private void btnBrowseInput_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtInputPath.Text))
        {
            folderBrowserDialogInput.SelectedPath = txtInputPath.Text;
        }

        if (folderBrowserDialogInput.ShowDialog() == DialogResult.OK)
        {
            txtInputPath.Text = folderBrowserDialogInput.SelectedPath;
        }
    }

    private void btnBrowseOutput_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtOutputPath.Text))
        {
            folderBrowserDialogOutput.SelectedPath = txtOutputPath.Text;
        }

        if (folderBrowserDialogOutput.ShowDialog() == DialogResult.OK)
        {
            txtOutputPath.Text = folderBrowserDialogOutput.SelectedPath;
        }
    }

    private void btnExecute_Click(object sender, EventArgs e)
    {
        string inputPath = txtInputPath.Text;
        string outputPath = txtOutputPath.Text;
        string excludePaths = txtExcludePaths.Text;

        if (!CheckOutputPath(outputPath))
        {
            MessageBox.Show("Operation cancelled by the user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (chkRunSeparate.Checked)
        {
            RunSeparateForEachDirectory(inputPath, outputPath, excludePaths);
        }
        else
        {
            // Create a temporary directory
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempPath);

            try
            {
                // Copy files from inputPath to tempPath, excluding excludePaths
                CopyFiles(inputPath, tempPath, excludePaths.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

                string arguments = $"{tempPath} {outputPath}";

                if (chkDir.Checked)
                {
                    arguments += " -dir";
                }

                if (chkPublic.Checked)
                {
                    arguments += " -public";
                }

                if (chkCreateAssociation.Checked)
                {
                    arguments += " -createAssociation";
                }

                if (chkAllInOne.Checked)
                {
                    arguments += " -allInOne";
                }

                if (chkAttributeRequired.Checked)
                {
                    arguments += " -attributeRequired";
                }

                if (chkExcludeUmlBeginEndTags.Checked)
                {
                    arguments += " -excludeUmlBeginEndTags";
                }

                RunPumlGenCommand(arguments);
            }
            finally
            {
                // Clean up the temporary directory
                Directory.Delete(tempPath, true);
            }
        }
    }

    private void SaveSettings()
    {
        Settings settings = new()
        {
            InputPath = txtInputPath.Text,
            OutputPath = txtOutputPath.Text,
            ExcludePaths = txtExcludePaths.Text,
            Dir = chkDir.Checked,
            Public = chkPublic.Checked,
            CreateAssociation = chkCreateAssociation.Checked,
            AllInOne = chkAllInOne.Checked,
            AttributeRequired = chkAttributeRequired.Checked,
            ExcludeUmlBeginEndTags = chkExcludeUmlBeginEndTags.Checked,
            RunSeparate = chkRunSeparate.Checked,
        };

        string json = JsonSerializer.Serialize(settings);
        File.WriteAllText("settings.json", json);
    }

    private void LoadSettings()
    {
        if (File.Exists("settings.json"))
        {
            string json = File.ReadAllText("settings.json");
            Settings? settings = JsonSerializer.Deserialize<Settings>(json);

            if (settings != null)
            {
                txtInputPath.Text = settings.InputPath;
                txtOutputPath.Text = settings.OutputPath;
                txtExcludePaths.Text = settings.ExcludePaths;
                chkDir.Checked = settings.Dir;
                chkPublic.Checked = settings.Public;
                chkCreateAssociation.Checked = settings.CreateAssociation;
                chkAllInOne.Checked = settings.AllInOne;
                chkAttributeRequired.Checked = settings.AttributeRequired;
                chkExcludeUmlBeginEndTags.Checked = settings.ExcludeUmlBeginEndTags;
                chkRunSeparate.Checked = settings.RunSeparate;
            }
        }
    }

    private void CopyFiles(string sourceDir, string destDir, string[] excludePaths)
    {
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        foreach (string subDir in Directory.GetDirectories(sourceDir))
        {
            string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
            Directory.CreateDirectory(destSubDir);

            bool shouldExclude = excludePaths.Any(excludePath =>
            {
                string relativePath = Path.GetRelativePath(sourceDir, subDir);
                return relativePath.StartsWith(excludePath.TrimStart('*', '/'));
            });

            if (!shouldExclude)
            {
                CopyFiles(subDir, destSubDir, excludePaths);
            }
        }
    }

    private bool CheckOutputPath(string outputPath)
    {
        if (!Directory.Exists(outputPath))
        {
            DialogResult result = MessageBox.Show($"The output directory '{outputPath}' does not exist. Do you want to create it?", "Output Directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Directory.CreateDirectory(outputPath);
                return true;
            }

            return false;
        }

        if (Directory.GetFiles(outputPath).Length > 0 || Directory.GetDirectories(outputPath).Length > 0)
        {
            DialogResult result = MessageBox.Show($"The output directory '{outputPath}' already exists and contains files. Do you want to clear it?", "Output Directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Directory.Delete(outputPath, true);
                Directory.CreateDirectory(outputPath);
                return true;
            }

            return false;
        }

        return true;
    }

    private void RunSeparateForEachDirectory(string inputPath, string outputPath, string excludePaths)
    {
        string[] excludePathList = excludePaths.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string subDir in Directory.GetDirectories(inputPath))
        {
            if (IsDirectoryEmpty(subDir) || subDir.Equals(outputPath, StringComparison.OrdinalIgnoreCase))
            {
                continue; // Skip empty directories and the output directory
            }

            string dirName = Path.GetFileName(subDir);
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempPath);

            try
            {
                // Copy files from subDir to tempPath, excluding excludePaths
                CopyFiles(subDir, tempPath, excludePathList);

                string subOutputPath = Path.Combine(outputPath, dirName);
                Directory.CreateDirectory(subOutputPath);

                string arguments = $"{tempPath} {subOutputPath}";

                if (chkDir.Checked)
                {
                    arguments += " -dir";
                }

                if (chkPublic.Checked)
                {
                    arguments += " -public";
                }

                if (chkCreateAssociation.Checked)
                {
                    arguments += " -createAssociation";
                }

                if (chkAllInOne.Checked)
                {
                    arguments += " -allInOne";
                }

                if (chkAttributeRequired.Checked)
                {
                    arguments += " -attributeRequired";
                }

                if (chkExcludeUmlBeginEndTags.Checked)
                {
                    arguments += " -excludeUmlBeginEndTags";
                }

                RunPumlGenCommand(arguments);

                if (chkAllInOne.Checked)
                {
                    string includePumlPath = Path.Combine(subOutputPath, "include.puml");

                    if (File.Exists(includePumlPath))
                    {
                        string newIncludePumlPath = Path.Combine(outputPath, $"{dirName}_include.puml");
                        File.Move(includePumlPath, newIncludePumlPath);
                    }
                }
            }
            finally
            {
                // Clean up the temporary directory
                Directory.Delete(tempPath, true);
            }
        }
    }

    private bool IsDirectoryEmpty(string path)
    {
        return !Directory.EnumerateFileSystemEntries(path).Any();
    }

    private void RunPumlGenCommand(string arguments)
    {
        try
        {
            ProcessStartInfo startInfo = new()
            {
                FileName = "puml-gen",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    MessageBox.Show(result, "Output");
                }

                using (StreamReader reader = process.StandardError)
                {
                    string error = reader.ReadToEnd();

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, "Error");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error");
        }
    }
}

public class Settings
{
    public string InputPath { get; set; }
    public string OutputPath { get; set; }
    public string ExcludePaths { get; set; }
    public bool Dir { get; set; }
    public bool Public { get; set; }
    public bool CreateAssociation { get; set; }
    public bool AllInOne { get; set; }
    public bool AttributeRequired { get; set; }
    public bool ExcludeUmlBeginEndTags { get; set; }
    public bool RunSeparate { get; set; }
}
