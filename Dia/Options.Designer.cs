namespace Dia
{
   partial class Options
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
         this.label1 = new System.Windows.Forms.Label();
         this.tbxDuration = new System.Windows.Forms.TextBox();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.cbxSortingMode = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(83, 15);
         this.label1.TabIndex = 0;
         this.label1.Text = "Duration (ms):";
         // 
         // tbxDuration
         // 
         this.tbxDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tbxDuration.Location = new System.Drawing.Point(101, 12);
         this.tbxDuration.Name = "tbxDuration";
         this.tbxDuration.Size = new System.Drawing.Size(241, 23);
         this.tbxDuration.TabIndex = 1;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(267, 108);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "Abbrechen";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.OnBtnClickedCancel);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(186, 108);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 3;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.OnBtnClickedOK);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 44);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(45, 15);
         this.label2.TabIndex = 4;
         this.label2.Text = "Sorting";
         // 
         // cbxSortingMode
         // 
         this.cbxSortingMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cbxSortingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cbxSortingMode.FormattingEnabled = true;
         this.cbxSortingMode.Location = new System.Drawing.Point(101, 41);
         this.cbxSortingMode.Name = "cbxSortingMode";
         this.cbxSortingMode.Size = new System.Drawing.Size(241, 23);
         this.cbxSortingMode.TabIndex = 5;
         // 
         // Options
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(354, 143);
         this.Controls.Add(this.cbxSortingMode);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.tbxDuration);
         this.Controls.Add(this.label1);
         this.Name = "Options";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Options";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private TextBox tbxDuration;
      private Button btnCancel;
      private Button btnOK;
      private Label label2;
      private ComboBox cbxSortingMode;
   }
}