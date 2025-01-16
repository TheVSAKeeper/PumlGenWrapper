namespace PumlGenWrapper;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtInputPath = new System.Windows.Forms.TextBox();
        txtOutputPath = new System.Windows.Forms.TextBox();
        txtExcludePaths = new System.Windows.Forms.TextBox();
        chkDir = new System.Windows.Forms.CheckBox();
        chkPublic = new System.Windows.Forms.CheckBox();
        chkCreateAssociation = new System.Windows.Forms.CheckBox();
        chkAllInOne = new System.Windows.Forms.CheckBox();
        chkAttributeRequired = new System.Windows.Forms.CheckBox();
        chkExcludeUmlBeginEndTags = new System.Windows.Forms.CheckBox();
        btnExecute = new System.Windows.Forms.Button();
        lblInputPath = new System.Windows.Forms.Label();
        lblOutputPath = new System.Windows.Forms.Label();
        lblExcludePaths = new System.Windows.Forms.Label();
        folderBrowserDialogInput = new System.Windows.Forms.FolderBrowserDialog();
        folderBrowserDialogOutput = new System.Windows.Forms.FolderBrowserDialog();
        btnBrowseInput = new System.Windows.Forms.Button();
        btnBrowseOutput = new System.Windows.Forms.Button();
        chkRunSeparate = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        //
        // txtInputPath
        //
        txtInputPath.Location = new System.Drawing.Point(12, 30);
        txtInputPath.Name = "txtInputPath";
        txtInputPath.Size = new System.Drawing.Size(360, 23);
        txtInputPath.TabIndex = 0;
        //
        // txtOutputPath
        //
        txtOutputPath.Location = new System.Drawing.Point(12, 70);
        txtOutputPath.Name = "txtOutputPath";
        txtOutputPath.Size = new System.Drawing.Size(360, 23);
        txtOutputPath.TabIndex = 1;
        //
        // txtExcludePaths
        //
        txtExcludePaths.Location = new System.Drawing.Point(12, 110);
        txtExcludePaths.Name = "txtExcludePaths";
        txtExcludePaths.Size = new System.Drawing.Size(360, 23);
        txtExcludePaths.TabIndex = 2;
        //
        // chkDir
        //
        chkDir.AutoSize = true;
        chkDir.Location = new System.Drawing.Point(12, 150);
        chkDir.Name = "chkDir";
        chkDir.Size = new System.Drawing.Size(45, 19);
        chkDir.TabIndex = 3;
        chkDir.Text = "-dir";
        chkDir.UseVisualStyleBackColor = true;
        //
        // chkPublic
        //
        chkPublic.AutoSize = true;
        chkPublic.Location = new System.Drawing.Point(12, 173);
        chkPublic.Name = "chkPublic";
        chkPublic.Size = new System.Drawing.Size(64, 19);
        chkPublic.TabIndex = 4;
        chkPublic.Text = "-public";
        chkPublic.UseVisualStyleBackColor = true;
        //
        // chkCreateAssociation
        //
        chkCreateAssociation.AutoSize = true;
        chkCreateAssociation.Location = new System.Drawing.Point(12, 196);
        chkCreateAssociation.Name = "chkCreateAssociation";
        chkCreateAssociation.Size = new System.Drawing.Size(124, 19);
        chkCreateAssociation.TabIndex = 5;
        chkCreateAssociation.Text = "-createAssociation";
        chkCreateAssociation.UseVisualStyleBackColor = true;
        //
        // chkAllInOne
        //
        chkAllInOne.AutoSize = true;
        chkAllInOne.Location = new System.Drawing.Point(12, 219);
        chkAllInOne.Name = "chkAllInOne";
        chkAllInOne.Size = new System.Drawing.Size(75, 19);
        chkAllInOne.TabIndex = 6;
        chkAllInOne.Text = "-allInOne";
        chkAllInOne.UseVisualStyleBackColor = true;
        //
        // chkAttributeRequired
        //
        chkAttributeRequired.AutoSize = true;
        chkAttributeRequired.Location = new System.Drawing.Point(12, 242);
        chkAttributeRequired.Name = "chkAttributeRequired";
        chkAttributeRequired.Size = new System.Drawing.Size(123, 19);
        chkAttributeRequired.TabIndex = 7;
        chkAttributeRequired.Text = "-attributeRequired";
        chkAttributeRequired.UseVisualStyleBackColor = true;
        //
        // chkExcludeUmlBeginEndTags
        //
        chkExcludeUmlBeginEndTags.AutoSize = true;
        chkExcludeUmlBeginEndTags.Location = new System.Drawing.Point(12, 265);
        chkExcludeUmlBeginEndTags.Name = "chkExcludeUmlBeginEndTags";
        chkExcludeUmlBeginEndTags.Size = new System.Drawing.Size(167, 19);
        chkExcludeUmlBeginEndTags.TabIndex = 8;
        chkExcludeUmlBeginEndTags.Text = "-excludeUmlBeginEndTags";
        chkExcludeUmlBeginEndTags.UseVisualStyleBackColor = true;
        //
        // btnExecute
        //
        btnExecute.Location = new System.Drawing.Point(12, 313);
        btnExecute.Name = "btnExecute";
        btnExecute.Size = new System.Drawing.Size(75, 23);
        btnExecute.TabIndex = 9;
        btnExecute.Text = "Execute";
        btnExecute.UseVisualStyleBackColor = true;
        btnExecute.Click += btnExecute_Click;
        //
        // lblInputPath
        //
        lblInputPath.AutoSize = true;
        lblInputPath.Location = new System.Drawing.Point(12, 13);
        lblInputPath.Name = "lblInputPath";
        lblInputPath.Size = new System.Drawing.Size(62, 15);
        lblInputPath.TabIndex = 10;
        lblInputPath.Text = "Input Path";
        //
        // lblOutputPath
        //
        lblOutputPath.AutoSize = true;
        lblOutputPath.Location = new System.Drawing.Point(12, 53);
        lblOutputPath.Name = "lblOutputPath";
        lblOutputPath.Size = new System.Drawing.Size(72, 15);
        lblOutputPath.TabIndex = 11;
        lblOutputPath.Text = "Output Path";
        //
        // lblExcludePaths
        //
        lblExcludePaths.AutoSize = true;
        lblExcludePaths.Location = new System.Drawing.Point(12, 93);
        lblExcludePaths.Name = "lblExcludePaths";
        lblExcludePaths.Size = new System.Drawing.Size(80, 15);
        lblExcludePaths.TabIndex = 12;
        lblExcludePaths.Text = "Exclude Paths";
        //
        // btnBrowseInput
        //
        btnBrowseInput.Location = new System.Drawing.Point(380, 30);
        btnBrowseInput.Name = "btnBrowseInput";
        btnBrowseInput.Size = new System.Drawing.Size(75, 23);
        btnBrowseInput.TabIndex = 13;
        btnBrowseInput.Text = "Browse...";
        btnBrowseInput.UseVisualStyleBackColor = true;
        btnBrowseInput.Click += btnBrowseInput_Click;
        //
        // btnBrowseOutput
        //
        btnBrowseOutput.Location = new System.Drawing.Point(380, 70);
        btnBrowseOutput.Name = "btnBrowseOutput";
        btnBrowseOutput.Size = new System.Drawing.Size(75, 23);
        btnBrowseOutput.TabIndex = 14;
        btnBrowseOutput.Text = "Browse...";
        btnBrowseOutput.UseVisualStyleBackColor = true;
        btnBrowseOutput.Click += btnBrowseOutput_Click;
        //
        // chkRunSeparate
        //
        chkRunSeparate.AutoSize = true;
        chkRunSeparate.Location = new System.Drawing.Point(12, 288);
        chkRunSeparate.Name = "chkRunSeparate";
        chkRunSeparate.Size = new System.Drawing.Size(159, 19);
        chkRunSeparate.TabIndex = 15;
        chkRunSeparate.Text = "Run Separate for Each Dir";
        chkRunSeparate.UseVisualStyleBackColor = true;
        //
        // Form1
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(474, 343);
        Controls.Add(chkRunSeparate);
        Controls.Add(btnBrowseOutput);
        Controls.Add(btnBrowseInput);
        Controls.Add(lblExcludePaths);
        Controls.Add(lblOutputPath);
        Controls.Add(lblInputPath);
        Controls.Add(btnExecute);
        Controls.Add(chkExcludeUmlBeginEndTags);
        Controls.Add(chkAttributeRequired);
        Controls.Add(chkAllInOne);
        Controls.Add(chkCreateAssociation);
        Controls.Add(chkPublic);
        Controls.Add(chkDir);
        Controls.Add(txtExcludePaths);
        Controls.Add(txtOutputPath);
        Controls.Add(txtInputPath);
        Text = "PumlGen Wrapper";
        ResumeLayout(false);
        PerformLayout();
    }
    private System.Windows.Forms.CheckBox chkRunSeparate;

    private System.Windows.Forms.TextBox txtInputPath;
    private System.Windows.Forms.TextBox txtOutputPath;
    private System.Windows.Forms.TextBox txtExcludePaths;
    private System.Windows.Forms.CheckBox chkDir;
    private System.Windows.Forms.CheckBox chkPublic;
    private System.Windows.Forms.CheckBox chkCreateAssociation;
    private System.Windows.Forms.CheckBox chkAllInOne;
    private System.Windows.Forms.CheckBox chkAttributeRequired;
    private System.Windows.Forms.CheckBox chkExcludeUmlBeginEndTags;
    private System.Windows.Forms.Button btnExecute;
    private System.Windows.Forms.Label lblInputPath;
    private System.Windows.Forms.Label lblOutputPath;
    private System.Windows.Forms.Label lblExcludePaths;
    private System.Windows.Forms.Button btnBrowseInput;
    private System.Windows.Forms.Button btnBrowseOutput;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogInput;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOutput;


    #endregion
}
