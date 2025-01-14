namespace ScoreMakerMock
{
    partial class ScoreMaker
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileFToolStripMenuItem = new ToolStripMenuItem();
            makeNewProjToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            openProjectToolStripMenuItem = new ToolStripMenuItem();
            ProjectViewer = new TabControl();
            ScoreProjectTab = new TabPage();
            LoadScoreProjectGroup = new GroupBox();
            OpenScoreButton = new Button();
            CreateScoreProjectGroup = new GroupBox();
            UpdateScoreProjectButton = new Button();
            label1 = new Label();
            ImportFileGroup = new GroupBox();
            BackGroundFilePathTextbox = new TextBox();
            OpenBackgroundFileButton = new Button();
            BackGroudFile = new Label();
            MusicFile = new Label();
            MusicFilePathTextbox = new TextBox();
            OpenMusicFileButton = new Button();
            ScoreBasicGroup = new GroupBox();
            CreditTextbox = new TextBox();
            Credit = new Label();
            AuthorTextbox = new TextBox();
            Author = new Label();
            ScoreDir = new Label();
            ScoreDirTextbox = new TextBox();
            OpenProjectDirButton = new Button();
            ScoreName = new Label();
            ScoreNameTextbox = new TextBox();
            NumberOfLanesTextbox = new TextBox();
            NumberOfLanes = new Label();
            GenerateScoreButton = new Button();
            ScoreEditorTab = new TabPage();
            renderControl1 = new Vortice.WinForms.RenderControl();
            button1 = new Button();
            menuStrip.SuspendLayout();
            ProjectViewer.SuspendLayout();
            ScoreProjectTab.SuspendLayout();
            LoadScoreProjectGroup.SuspendLayout();
            CreateScoreProjectGroup.SuspendLayout();
            ImportFileGroup.SuspendLayout();
            ScoreBasicGroup.SuspendLayout();
            ScoreEditorTab.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileFToolStripMenuItem, openProjectToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1878, 33);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            fileFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { makeNewProjToolStripMenuItem, saveToolStripMenuItem });
            fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            fileFToolStripMenuItem.Size = new Size(131, 29);
            fileFToolStripMenuItem.Text = "Score Project";
            // 
            // makeNewProjToolStripMenuItem
            // 
            makeNewProjToolStripMenuItem.Name = "makeNewProjToolStripMenuItem";
            makeNewProjToolStripMenuItem.Size = new Size(153, 34);
            makeNewProjToolStripMenuItem.Text = "Load";
            makeNewProjToolStripMenuItem.Click += OpenScoreButton_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(153, 34);
            saveToolStripMenuItem.Text = "Save";
            // 
            // openProjectToolStripMenuItem
            // 
            openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            openProjectToolStripMenuItem.Size = new Size(185, 29);
            openProjectToolStripMenuItem.Text = "Open Project Folder";
            openProjectToolStripMenuItem.Click += OpenProjectDirButton_Click;
            // 
            // ProjectViewer
            // 
            ProjectViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProjectViewer.Controls.Add(ScoreProjectTab);
            ProjectViewer.Controls.Add(ScoreEditorTab);
            ProjectViewer.Location = new Point(12, 36);
            ProjectViewer.Name = "ProjectViewer";
            ProjectViewer.SelectedIndex = 0;
            ProjectViewer.Size = new Size(1854, 1071);
            ProjectViewer.TabIndex = 6;
            // 
            // ScoreProjectTab
            // 
            ScoreProjectTab.BackColor = SystemColors.Control;
            ScoreProjectTab.Controls.Add(LoadScoreProjectGroup);
            ScoreProjectTab.Controls.Add(CreateScoreProjectGroup);
            ScoreProjectTab.Location = new Point(4, 34);
            ScoreProjectTab.Name = "ScoreProjectTab";
            ScoreProjectTab.Padding = new Padding(3);
            ScoreProjectTab.Size = new Size(1846, 1033);
            ScoreProjectTab.TabIndex = 0;
            ScoreProjectTab.Text = "Score Project";
            // 
            // LoadScoreProjectGroup
            // 
            LoadScoreProjectGroup.Controls.Add(OpenScoreButton);
            LoadScoreProjectGroup.Location = new Point(16, 19);
            LoadScoreProjectGroup.Name = "LoadScoreProjectGroup";
            LoadScoreProjectGroup.Size = new Size(1018, 127);
            LoadScoreProjectGroup.TabIndex = 8;
            LoadScoreProjectGroup.TabStop = false;
            LoadScoreProjectGroup.Text = "Load Score Project";
            // 
            // OpenScoreButton
            // 
            OpenScoreButton.Location = new Point(6, 30);
            OpenScoreButton.Name = "OpenScoreButton";
            OpenScoreButton.Size = new Size(991, 73);
            OpenScoreButton.TabIndex = 7;
            OpenScoreButton.Text = "Load Score Project";
            OpenScoreButton.UseVisualStyleBackColor = true;
            OpenScoreButton.Click += OpenScoreButton_Click;
            // 
            // CreateScoreProjectGroup
            // 
            CreateScoreProjectGroup.Controls.Add(UpdateScoreProjectButton);
            CreateScoreProjectGroup.Controls.Add(label1);
            CreateScoreProjectGroup.Controls.Add(ImportFileGroup);
            CreateScoreProjectGroup.Controls.Add(ScoreBasicGroup);
            CreateScoreProjectGroup.Controls.Add(GenerateScoreButton);
            CreateScoreProjectGroup.Location = new Point(16, 170);
            CreateScoreProjectGroup.Name = "CreateScoreProjectGroup";
            CreateScoreProjectGroup.Size = new Size(1018, 780);
            CreateScoreProjectGroup.TabIndex = 0;
            CreateScoreProjectGroup.TabStop = false;
            CreateScoreProjectGroup.Text = "Create New Score Project or Update Score Project";
            // 
            // UpdateScoreProjectButton
            // 
            UpdateScoreProjectButton.Location = new Point(508, 636);
            UpdateScoreProjectButton.Name = "UpdateScoreProjectButton";
            UpdateScoreProjectButton.Size = new Size(498, 138);
            UpdateScoreProjectButton.TabIndex = 17;
            UpdateScoreProjectButton.Text = "Update Score Project";
            UpdateScoreProjectButton.UseVisualStyleBackColor = true;
            UpdateScoreProjectButton.Click += UpdateScoreProjectButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(465, 693);
            label1.Name = "label1";
            label1.Size = new Size(37, 25);
            label1.TabIndex = 16;
            label1.Text = "OR";
            // 
            // ImportFileGroup
            // 
            ImportFileGroup.Controls.Add(BackGroundFilePathTextbox);
            ImportFileGroup.Controls.Add(OpenBackgroundFileButton);
            ImportFileGroup.Controls.Add(BackGroudFile);
            ImportFileGroup.Controls.Add(MusicFile);
            ImportFileGroup.Controls.Add(MusicFilePathTextbox);
            ImportFileGroup.Controls.Add(OpenMusicFileButton);
            ImportFileGroup.Location = new Point(7, 486);
            ImportFileGroup.Name = "ImportFileGroup";
            ImportFileGroup.Size = new Size(999, 144);
            ImportFileGroup.TabIndex = 15;
            ImportFileGroup.TabStop = false;
            ImportFileGroup.Text = "*Import File";
            // 
            // BackGroundFilePathTextbox
            // 
            BackGroundFilePathTextbox.Location = new Point(187, 87);
            BackGroundFilePathTextbox.Name = "BackGroundFilePathTextbox";
            BackGroundFilePathTextbox.ReadOnly = true;
            BackGroundFilePathTextbox.Size = new Size(768, 31);
            BackGroundFilePathTextbox.TabIndex = 15;
            // 
            // OpenBackgroundFileButton
            // 
            OpenBackgroundFileButton.Location = new Point(961, 85);
            OpenBackgroundFileButton.Name = "OpenBackgroundFileButton";
            OpenBackgroundFileButton.Size = new Size(32, 34);
            OpenBackgroundFileButton.TabIndex = 14;
            OpenBackgroundFileButton.Text = "...";
            OpenBackgroundFileButton.UseVisualStyleBackColor = true;
            OpenBackgroundFileButton.Click += OpenBackgroundFileButton_Click;
            // 
            // BackGroudFile
            // 
            BackGroudFile.AutoSize = true;
            BackGroudFile.Location = new Point(6, 90);
            BackGroudFile.Name = "BackGroudFile";
            BackGroudFile.Size = new Size(129, 25);
            BackGroudFile.TabIndex = 13;
            BackGroudFile.Text = "BackGroud File";
            // 
            // MusicFile
            // 
            MusicFile.AutoSize = true;
            MusicFile.Location = new Point(6, 39);
            MusicFile.Name = "MusicFile";
            MusicFile.Size = new Size(97, 25);
            MusicFile.TabIndex = 10;
            MusicFile.Text = "*Music File";
            // 
            // MusicFilePathTextbox
            // 
            MusicFilePathTextbox.Location = new Point(187, 39);
            MusicFilePathTextbox.Name = "MusicFilePathTextbox";
            MusicFilePathTextbox.ReadOnly = true;
            MusicFilePathTextbox.Size = new Size(768, 31);
            MusicFilePathTextbox.TabIndex = 11;
            // 
            // OpenMusicFileButton
            // 
            OpenMusicFileButton.Location = new Point(961, 37);
            OpenMusicFileButton.Name = "OpenMusicFileButton";
            OpenMusicFileButton.Size = new Size(32, 34);
            OpenMusicFileButton.TabIndex = 12;
            OpenMusicFileButton.Text = "...";
            OpenMusicFileButton.UseVisualStyleBackColor = true;
            OpenMusicFileButton.Click += OpenMusicFileButton_Click;
            // 
            // ScoreBasicGroup
            // 
            ScoreBasicGroup.Controls.Add(CreditTextbox);
            ScoreBasicGroup.Controls.Add(Credit);
            ScoreBasicGroup.Controls.Add(AuthorTextbox);
            ScoreBasicGroup.Controls.Add(Author);
            ScoreBasicGroup.Controls.Add(ScoreDir);
            ScoreBasicGroup.Controls.Add(ScoreDirTextbox);
            ScoreBasicGroup.Controls.Add(OpenProjectDirButton);
            ScoreBasicGroup.Controls.Add(ScoreName);
            ScoreBasicGroup.Controls.Add(ScoreNameTextbox);
            ScoreBasicGroup.Controls.Add(NumberOfLanesTextbox);
            ScoreBasicGroup.Controls.Add(NumberOfLanes);
            ScoreBasicGroup.Location = new Point(7, 28);
            ScoreBasicGroup.Name = "ScoreBasicGroup";
            ScoreBasicGroup.Size = new Size(1005, 452);
            ScoreBasicGroup.TabIndex = 14;
            ScoreBasicGroup.TabStop = false;
            ScoreBasicGroup.Text = "Basic";
            // 
            // CreditTextbox
            // 
            CreditTextbox.Location = new Point(186, 221);
            CreditTextbox.MaxLength = 500;
            CreditTextbox.Multiline = true;
            CreditTextbox.Name = "CreditTextbox";
            CreditTextbox.Size = new Size(813, 225);
            CreditTextbox.TabIndex = 13;
            // 
            // Credit
            // 
            Credit.AutoSize = true;
            Credit.Location = new Point(6, 224);
            Credit.Name = "Credit";
            Credit.Size = new Size(59, 25);
            Credit.TabIndex = 12;
            Credit.Text = "Credit";
            // 
            // AuthorTextbox
            // 
            AuthorTextbox.Location = new Point(186, 178);
            AuthorTextbox.MaxLength = 100;
            AuthorTextbox.Name = "AuthorTextbox";
            AuthorTextbox.Size = new Size(813, 31);
            AuthorTextbox.TabIndex = 11;
            // 
            // Author
            // 
            Author.AutoSize = true;
            Author.Location = new Point(6, 181);
            Author.Name = "Author";
            Author.Size = new Size(67, 25);
            Author.TabIndex = 10;
            Author.Text = "Author";
            // 
            // ScoreDir
            // 
            ScoreDir.AutoSize = true;
            ScoreDir.Location = new Point(6, 37);
            ScoreDir.Name = "ScoreDir";
            ScoreDir.Size = new Size(126, 25);
            ScoreDir.TabIndex = 2;
            ScoreDir.Text = "*Scores Folder";
            // 
            // ScoreDirTextbox
            // 
            ScoreDirTextbox.Location = new Point(187, 34);
            ScoreDirTextbox.Name = "ScoreDirTextbox";
            ScoreDirTextbox.ReadOnly = true;
            ScoreDirTextbox.Size = new Size(774, 31);
            ScoreDirTextbox.TabIndex = 3;
            // 
            // OpenProjectDirButton
            // 
            OpenProjectDirButton.Location = new Point(967, 32);
            OpenProjectDirButton.Name = "OpenProjectDirButton";
            OpenProjectDirButton.Size = new Size(32, 34);
            OpenProjectDirButton.TabIndex = 4;
            OpenProjectDirButton.Text = "...";
            OpenProjectDirButton.UseVisualStyleBackColor = true;
            OpenProjectDirButton.Click += OpenProjectDirButton_Click;
            // 
            // ScoreName
            // 
            ScoreName.AutoSize = true;
            ScoreName.Location = new Point(6, 83);
            ScoreName.Name = "ScoreName";
            ScoreName.Size = new Size(116, 25);
            ScoreName.TabIndex = 1;
            ScoreName.Text = "*Score Name";
            // 
            // ScoreNameTextbox
            // 
            ScoreNameTextbox.Location = new Point(187, 80);
            ScoreNameTextbox.MaxLength = 100;
            ScoreNameTextbox.Name = "ScoreNameTextbox";
            ScoreNameTextbox.Size = new Size(812, 31);
            ScoreNameTextbox.TabIndex = 0;
            // 
            // NumberOfLanesTextbox
            // 
            NumberOfLanesTextbox.Location = new Point(187, 130);
            NumberOfLanesTextbox.Name = "NumberOfLanesTextbox";
            NumberOfLanesTextbox.Size = new Size(73, 31);
            NumberOfLanesTextbox.TabIndex = 9;
            NumberOfLanesTextbox.Text = "5";
            // 
            // NumberOfLanes
            // 
            NumberOfLanes.AutoSize = true;
            NumberOfLanes.Location = new Point(6, 133);
            NumberOfLanes.Name = "NumberOfLanes";
            NumberOfLanes.Size = new Size(159, 25);
            NumberOfLanes.TabIndex = 8;
            NumberOfLanes.Text = "*Number Of Lanes";
            // 
            // GenerateScoreButton
            // 
            GenerateScoreButton.Location = new Point(7, 636);
            GenerateScoreButton.Name = "GenerateScoreButton";
            GenerateScoreButton.Size = new Size(452, 138);
            GenerateScoreButton.TabIndex = 5;
            GenerateScoreButton.Text = "Create New Score Project";
            GenerateScoreButton.UseVisualStyleBackColor = true;
            GenerateScoreButton.Click += GenerateScoreButton_Click;
            // 
            // ScoreEditorTab
            // 
            ScoreEditorTab.Controls.Add(renderControl1);
            ScoreEditorTab.Controls.Add(button1);
            ScoreEditorTab.Location = new Point(4, 34);
            ScoreEditorTab.Name = "ScoreEditorTab";
            ScoreEditorTab.Padding = new Padding(3);
            ScoreEditorTab.Size = new Size(1846, 1033);
            ScoreEditorTab.TabIndex = 1;
            ScoreEditorTab.Text = "Score Editor";
            ScoreEditorTab.UseVisualStyleBackColor = true;
            // 
            // renderControl1
            // 
            renderControl1.Location = new Point(1233, 205);
            renderControl1.Name = "renderControl1";
            renderControl1.Size = new Size(516, 731);
            renderControl1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(855, 31);
            button1.Name = "button1";
            button1.Size = new Size(477, 34);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ScoreMaker
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1878, 1112);
            Controls.Add(ProjectViewer);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "ScoreMaker";
            Text = "ScoreMaker";
            FormClosing += ScoreMaker_FormClosing;
            Load += ScoreMaker_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ProjectViewer.ResumeLayout(false);
            ScoreProjectTab.ResumeLayout(false);
            LoadScoreProjectGroup.ResumeLayout(false);
            CreateScoreProjectGroup.ResumeLayout(false);
            CreateScoreProjectGroup.PerformLayout();
            ImportFileGroup.ResumeLayout(false);
            ImportFileGroup.PerformLayout();
            ScoreBasicGroup.ResumeLayout(false);
            ScoreBasicGroup.PerformLayout();
            ScoreEditorTab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem fileFToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem makeNewProjToolStripMenuItem;
        private TabControl ProjectViewer;
        private TabPage ScoreProjectTab;
        private TabPage ScoreEditorTab;
        private GroupBox CreateScoreProjectGroup;
        private Label ProjectName;
        private TextBox ScoreNameTextbox;
        private TextBox ScoreDirTextbox;
        private Button OpenProjectDirButton;
        private Button GenerateScoreButton;
        private Label ScoreDir;
        private Label ScoreName;
        private Button OpenScoreButton;
        private Label NumberOfLanes;
        private TextBox NumberOfLanesTextbox;
        private Label MusicFile;
        private Button OpenMusicFileButton;
        private TextBox MusicFilePathTextbox;
        private GroupBox ScoreBasicGroup;
        private GroupBox ImportFileGroup;
        private Label BackGroudFile;
        private GroupBox LoadScoreProjectGroup;
        private TextBox BackGroundFilePathTextbox;
        private Button OpenBackgroundFileButton;
        private Label Author;
        private Label Credit;
        private TextBox AuthorTextbox;
        private TextBox CreditTextbox;
        private Button UpdateScoreProjectButton;
        private Label label1;
        private ToolStripMenuItem openProjectToolStripMenuItem;
        private Vortice.WinForms.RenderControl renderControl1;
        private Button button1;
    }
}
