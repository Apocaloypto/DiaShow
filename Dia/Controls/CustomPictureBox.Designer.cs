namespace Dia.Controls
{
   partial class CustomPictureBox
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
            UnregisterEvents(this);
            UnregisterEvents(thePicture);

            if (components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.panSize = new System.Windows.Forms.Panel();
         this.thePicture = new System.Windows.Forms.PictureBox();
         this.panSize.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.thePicture)).BeginInit();
         this.SuspendLayout();
         // 
         // panSize
         // 
         this.panSize.AutoScroll = true;
         this.panSize.Controls.Add(this.thePicture);
         this.panSize.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panSize.Location = new System.Drawing.Point(0, 0);
         this.panSize.Name = "panSize";
         this.panSize.Size = new System.Drawing.Size(591, 322);
         this.panSize.TabIndex = 0;
         // 
         // thePicture
         // 
         this.thePicture.Location = new System.Drawing.Point(3, 3);
         this.thePicture.Name = "thePicture";
         this.thePicture.Size = new System.Drawing.Size(585, 316);
         this.thePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.thePicture.TabIndex = 0;
         this.thePicture.TabStop = false;
         // 
         // CustomPictureBox
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.panSize);
         this.DoubleBuffered = true;
         this.Name = "CustomPictureBox";
         this.Size = new System.Drawing.Size(591, 322);
         this.panSize.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.thePicture)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private Panel panSize;
      private PictureBox thePicture;
   }
}
