namespace ScoreEditor
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            menuStrip = new MenuStrip();
            scoreProjectToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            ScoreSkControl = new SkiaSharp.Views.Desktop.SKControl();
            MusicTackbar = new TrackBar();
            PauseOrReplayButton = new Button();
            dataGridView1 = new DataGridView();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MusicTackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { scoreProjectToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(2048, 33);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // scoreProjectToolStripMenuItem
            // 
            scoreProjectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem });
            scoreProjectToolStripMenuItem.Name = "scoreProjectToolStripMenuItem";
            scoreProjectToolStripMenuItem.Size = new Size(131, 29);
            scoreProjectToolStripMenuItem.Text = "Score Project";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(153, 34);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // ScoreSkControl
            // 
            ScoreSkControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ScoreSkControl.BackColor = Color.Lime;
            ScoreSkControl.Location = new Point(87, 36);
            ScoreSkControl.Name = "ScoreSkControl";
            ScoreSkControl.Size = new Size(777, 1416);
            ScoreSkControl.TabIndex = 1;
            ScoreSkControl.Text = "skControl1";
            ScoreSkControl.PaintSurface += ScoreSkControl_PaintSurface;
            ScoreSkControl.MouseClick += ScoreSkControl_MouseClick;
            // 
            // MusicTackbar
            // 
            MusicTackbar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            MusicTackbar.Location = new Point(12, 36);
            MusicTackbar.Name = "MusicTackbar";
            MusicTackbar.Orientation = Orientation.Vertical;
            MusicTackbar.Size = new Size(69, 1358);
            MusicTackbar.TabIndex = 2;
            MusicTackbar.Scroll += MusicTackbar_Scroll;
            // 
            // PauseOrReplayButton
            // 
            PauseOrReplayButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PauseOrReplayButton.Location = new Point(9, 1400);
            PauseOrReplayButton.Name = "PauseOrReplayButton";
            PauseOrReplayButton.Size = new Size(72, 66);
            PauseOrReplayButton.TabIndex = 3;
            PauseOrReplayButton.Text = ">||";
            PauseOrReplayButton.UseVisualStyleBackColor = true;
            PauseOrReplayButton.Click += PauseOrReplayButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(880, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1156, 1266);
            dataGridView1.TabIndex = 4;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2048, 1464);
            Controls.Add(dataGridView1);
            Controls.Add(PauseOrReplayButton);
            Controls.Add(MusicTackbar);
            Controls.Add(ScoreSkControl);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Editor";
            Text = "Editor";
            Load += Editor_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MusicTackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem scoreProjectToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private SkiaSharp.Views.Desktop.SKControl ScoreSkControl;
        private TrackBar MusicTackbar;
        private Button PauseOrReplayButton;
        private DataGridView dataGridView1;
    }
}