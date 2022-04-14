namespace Dia
{
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
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.thePicture = new System.Windows.Forms.PictureBox();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.diashowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this.thePicture)).BeginInit();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // thePicture
         // 
         this.thePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.thePicture.Location = new System.Drawing.Point(12, 27);
         this.thePicture.Name = "thePicture";
         this.thePicture.Size = new System.Drawing.Size(993, 545);
         this.thePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.thePicture.TabIndex = 0;
         this.thePicture.TabStop = false;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.diashowToolStripMenuItem});
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
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
         this.diashowToolStripMenuItem.Name = "diashowToolStripMenuItem";
         this.diashowToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
         this.diashowToolStripMenuItem.Text = "Diashow";
         // 
         // startToolStripMenuItem
         // 
         this.startToolStripMenuItem.Name = "startToolStripMenuItem";
         this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.startToolStripMenuItem.Text = "Start";
         this.startToolStripMenuItem.Click += new System.EventHandler(this.OnClickedDiaStart);
         // 
         // stopToolStripMenuItem
         // 
         this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
         this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.stopToolStripMenuItem.Text = "Stop";
         this.stopToolStripMenuItem.Click += new System.EventHandler(this.OnClickDiaStop);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.optionsToolStripMenuItem.Text = "Options...";
         this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OnClickedDiaOptions);
         // 
         // fullScreenToolStripMenuItem
         // 
         this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
         this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.fullScreenToolStripMenuItem.Text = "FullScreen";
         this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.OnClickedFullScreen);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1017, 584);
         this.Controls.Add(this.thePicture);
         this.Controls.Add(this.menuStrip1);
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "Form1";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Diashow";
         ((System.ComponentModel.ISupportInitialize)(this.thePicture)).EndInit();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
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
      private ToolStripMenuItem startToolStripMenuItem;
      private ToolStripMenuItem optionsToolStripMenuItem;
      private ToolStripMenuItem stopToolStripMenuItem;
      private ToolStripMenuItem fullScreenToolStripMenuItem;
   }
}