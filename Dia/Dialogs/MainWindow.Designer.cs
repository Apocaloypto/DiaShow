namespace Dia.Dialogs
{
   partial class MainWindow
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
         this.thePicture = new System.Windows.Forms.PictureBox();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.diashowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.diaControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openInEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         ((System.ComponentModel.ISupportInitialize)(this.thePicture)).BeginInit();
         this.menuStrip1.SuspendLayout();
         this.statusStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // thePicture
         // 
         this.thePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.thePicture.Location = new System.Drawing.Point(12, 27);
         this.thePicture.Name = "thePicture";
         this.thePicture.Size = new System.Drawing.Size(993, 532);
         this.thePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.thePicture.TabIndex = 0;
         this.thePicture.TabStop = false;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.diashowToolStripMenuItem,
            this.extrasToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(1017, 24);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDirToolStripMenuItem,
            this.openFileToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // openDirToolStripMenuItem
         // 
         this.openDirToolStripMenuItem.Name = "openDirToolStripMenuItem";
         this.openDirToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this.openDirToolStripMenuItem.Text = "Open Dir...";
         this.openDirToolStripMenuItem.Click += new System.EventHandler(this.OnClickedOpenDir);
         // 
         // openFileToolStripMenuItem
         // 
         this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
         this.openFileToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this.openFileToolStripMenuItem.Text = "Open File...";
         this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OnClickedOpenFile);
         // 
         // diashowToolStripMenuItem
         // 
         this.diashowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem,
            this.diaControllerToolStripMenuItem});
         this.diashowToolStripMenuItem.Name = "diashowToolStripMenuItem";
         this.diashowToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
         this.diashowToolStripMenuItem.Text = "Diashow";
         // 
         // fullScreenToolStripMenuItem
         // 
         this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
         this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
         this.fullScreenToolStripMenuItem.Text = "FullScreen";
         this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.OnClickedFullScreen);
         // 
         // diaControllerToolStripMenuItem
         // 
         this.diaControllerToolStripMenuItem.Name = "diaControllerToolStripMenuItem";
         this.diaControllerToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
         this.diaControllerToolStripMenuItem.Text = "Dia-Controller";
         this.diaControllerToolStripMenuItem.Click += new System.EventHandler(this.OnClickedDiaController);
         // 
         // extrasToolStripMenuItem
         // 
         this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInEditorToolStripMenuItem,
            this.optionsToolStripMenuItem});
         this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
         this.extrasToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
         this.extrasToolStripMenuItem.Text = "Extras";
         // 
         // openInEditorToolStripMenuItem
         // 
         this.openInEditorToolStripMenuItem.Name = "openInEditorToolStripMenuItem";
         this.openInEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.openInEditorToolStripMenuItem.Text = "Open in Editor...";
         this.openInEditorToolStripMenuItem.Click += new System.EventHandler(this.OnClickedOpenInEditor);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.optionsToolStripMenuItem.Text = "Options...";
         this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OnClickedOptions);
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
         this.statusStrip1.Location = new System.Drawing.Point(0, 562);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(1017, 22);
         this.statusStrip1.TabIndex = 2;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
         // 
         // MainWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1017, 584);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.thePicture);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainWindow";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Diashow";
         this.Shown += new System.EventHandler(this.OnWindowShown);
         ((System.ComponentModel.ISupportInitialize)(this.thePicture)).EndInit();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private PictureBox thePicture;
      private MenuStrip menuStrip1;
      private ToolStripMenuItem fileToolStripMenuItem;
      private ToolStripMenuItem openDirToolStripMenuItem;
      private ToolStripMenuItem openFileToolStripMenuItem;
      private ToolStripMenuItem diashowToolStripMenuItem;
      private ToolStripMenuItem fullScreenToolStripMenuItem;
      private ToolStripMenuItem diaControllerToolStripMenuItem;
      private StatusStrip statusStrip1;
      private ToolStripStatusLabel toolStripStatusLabel1;
      private ToolStripMenuItem extrasToolStripMenuItem;
      private ToolStripMenuItem openInEditorToolStripMenuItem;
      private ToolStripMenuItem optionsToolStripMenuItem;
   }
}