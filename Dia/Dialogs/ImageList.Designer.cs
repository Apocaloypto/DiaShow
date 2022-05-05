namespace Dia.Dialogs
{
   partial class ImageList
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
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }

            _diaController.LoadFile -= _diaController_LoadFile;
            _diaController.MatchingFilesReloaded -= _diaController_MatchingFilesReloaded;
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
         this.lstImages = new System.Windows.Forms.ListView();
         this.colTitle = new System.Windows.Forms.ColumnHeader();
         this.SuspendLayout();
         // 
         // lstImages
         // 
         this.lstImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lstImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle});
         this.lstImages.FullRowSelect = true;
         this.lstImages.Location = new System.Drawing.Point(12, 12);
         this.lstImages.MultiSelect = false;
         this.lstImages.Name = "lstImages";
         this.lstImages.Size = new System.Drawing.Size(248, 490);
         this.lstImages.TabIndex = 0;
         this.lstImages.UseCompatibleStateImageBehavior = false;
         this.lstImages.View = System.Windows.Forms.View.Details;
         this.lstImages.Click += new System.EventHandler(this.OnClick);
         // 
         // colTitle
         // 
         this.colTitle.Text = "File";
         this.colTitle.Width = 244;
         // 
         // ImageList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(272, 514);
         this.Controls.Add(this.lstImages);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.Name = "ImageList";
         this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
         this.Text = "Image Queue";
         this.ResumeLayout(false);

      }

      #endregion

      private ListView lstImages;
      private ColumnHeader colTitle;
   }
}