using System.Diagnostics;
using System.Text.Json;

namespace PumlGenWrapper;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    protected override void OnFormClosing(FormClosingEventArgs args)
    {
        base.OnFormClosing(args);
        SaveSettings();
    }

    protected override void OnLoad(EventArgs args)
    {
        base.OnLoad(args);
        LoadSettings();
    }

    private void OnBrowseInputClicked(object sender, EventArgs args)
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

    private void OnBrowseOutputClicked(object sender, EventArgs args)
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

    private void OnExecuteClicked(object sender, EventArgs args)
    {
        string inputPath = txtInputPath.Text;
        string outputPath = txtOutputPath.Text;
        string excludePaths = txtExcludePaths.Text;

        if (CheckOutputPath(outputPath) == false)
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
            string tempPath = Path.Combine(Path.GetTempPath(), "PumlGenWrapper", Path.GetRandomFileName());
            Directory.CreateDirectory(tempPath);

            try
            {
                CopyFiles(inputPath, tempPath, excludePaths.Split([','], StringSplitOptions.RemoveEmptyEntries));
                string arguments = $"{tempPath} {outputPath}";

                RunPumlGenCommand(arguments);
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }
    }

    private static void CopyFiles(string sourceDirectory, string destinationDirectory, string[] excludePaths)
    {
        foreach (string file in Directory.GetFiles(sourceDirectory))
        {
            string destFile = Path.Combine(destinationDirectory, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        foreach (string subDirectory in Directory.GetDirectories(sourceDirectory))
        {
            string destSubDir = Path.Combine(destinationDirectory, Path.GetFileName(subDirectory));
            Directory.CreateDirectory(destSubDir);

            bool shouldExclude = excludePaths.Any(excludePath =>
            {
                string relativePath = Path.GetRelativePath(sourceDirectory, subDirectory);
                return relativePath.StartsWith(excludePath.TrimStart('*', '/'));
            });

            if (shouldExclude == false)
            {
                CopyFiles(subDirectory, destSubDir, excludePaths);
            }
        }
    }

    private static bool CheckOutputPath(string outputPath)
    {
        if (Directory.Exists(outputPath) == false)
        {
            return HandleOutputDirectory($"The output directory '{outputPath}' does not exist. Do you want to create it?");
        }

        if (Directory.GetFiles(outputPath).Length > 0 || Directory.GetDirectories(outputPath).Length > 0)
        {
            return HandleOutputDirectory($"The output directory '{outputPath}' already exists and contains files. Do you want to clear it?",
                true);
        }

        return true;

        bool HandleOutputDirectory(string message, bool shouldDelete = false)
        {
            DialogResult result = MessageBox.Show(message, "Output Directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return false;
            }

            if (shouldDelete)
            {
                Directory.Delete(outputPath, true);
            }

            Directory.CreateDirectory(outputPath);
            return true;
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
        if (File.Exists("settings.json") == false)
        {
            return;
        }

        string json = File.ReadAllText("settings.json");
        Settings? settings = JsonSerializer.Deserialize<Settings>(json);

        if (settings == null)
        {
            return;
        }

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

    private void RunSeparateForEachDirectory(string inputPath, string outputPath, string excludePaths)
    {
        string[] excludePathList = excludePaths.Split([','], StringSplitOptions.RemoveEmptyEntries);

        foreach (string subDirectory in Directory.GetDirectories(inputPath))
        {
            if (Directory.EnumerateFileSystemEntries(subDirectory).Any() == false || subDirectory.Equals(outputPath, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            string directoryName = Path.GetFileName(subDirectory);

            string tempPath = Path.Combine(Path.GetTempPath(), "PumlGenWrapper", Path.GetRandomFileName());
            Directory.CreateDirectory(tempPath);

            try
            {
                string subOutputPath = Path.Combine(outputPath, directoryName);
                Directory.CreateDirectory(subOutputPath);

                CopyFiles(subDirectory, tempPath, excludePathList);
                string arguments = $"{tempPath} {subOutputPath}";

                RunPumlGenCommand(arguments);

                if (chkAllInOne.Checked)
                {
                    string includePumlPath = Path.Combine(subOutputPath, "include.puml");

                    if (File.Exists(includePumlPath))
                    {
                        string newIncludePumlPath = Path.Combine(outputPath, $"{directoryName}_include.puml");
                        File.Move(includePumlPath, newIncludePumlPath);
                    }
                }
            }
            finally
            {
                Directory.Delete(tempPath, true);
            }
        }
    }

    private void RunPumlGenCommand(string arguments)
    {
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

            using Process? process = Process.Start(startInfo);

            if (process == null)
            {
                return;
            }

            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                MessageBox.Show(result, "Output");
            }

            using (StreamReader reader = process.StandardError)
            {
                string error = reader.ReadToEnd();

                if (string.IsNullOrEmpty(error))
                {
                    return;
                }

                MessageBox.Show(error, "Error");
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show($"An error occurred: {exception.Message}", "Error");
        }
    }
}
