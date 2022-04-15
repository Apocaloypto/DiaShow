namespace Dia.Dialogs
{
   partial class GlobalOptions
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
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.tbxImageEditor = new System.Windows.Forms.TextBox();
         this.btnImageEditorSearch = new System.Windows.Forms.Button();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 5;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.tbxImageEditor, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.btnImageEditorSearch, 4, 0);
         this.tableLayoutPanel1.Controls.Add(this.btnOK, 2, 2);
         this.tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 2);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 73);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label1.Location = new System.Drawing.Point(3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(94, 30);
         this.label1.TabIndex = 0;
         this.label1.Text = "Image-Editor:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbxImageEditor
         // 
         this.tableLayoutPanel1.SetColumnSpan(this.tbxImageEditor, 3);
         this.tbxImageEditor.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tbxImageEditor.Location = new System.Drawing.Point(103, 3);
         this.tbxImageEditor.Name = "tbxImageEditor";
         this.tbxImageEditor.Size = new System.Drawing.Size(208, 23);
         this.tbxImageEditor.TabIndex = 1;
         // 
         // btnImageEditorSearch
         // 
         this.btnImageEditorSearch.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnImageEditorSearch.Location = new System.Drawing.Point(317, 3);
         this.btnImageEditorSearch.Name = "btnImageEditorSearch";
         this.btnImageEditorSearch.Size = new System.Drawing.Size(24, 24);
         this.btnImageEditorSearch.TabIndex = 2;
         this.btnImageEditorSearch.Text = "...";
         this.btnImageEditorSearch.UseVisualStyleBackColor = true;
         this.btnImageEditorSearch.Click += new System.EventHandler(this.OnBtnClickedSearchImageEditor);
         // 
         // btnOK
         // 
         this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnOK.Location = new System.Drawing.Point(147, 46);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(94, 24);
         this.btnOK.TabIndex = 3;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.OnBtnClickedOK);
         // 
         // btnCancel
         // 
         this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 2);
         this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnCancel.Location = new System.Drawing.Point(247, 46);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(94, 24);
         this.btnCancel.TabIndex = 4;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.OnBtnClickedCancel);
         // 
         // GlobalOptions
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(368, 97);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Name = "GlobalOptions";
         this.Text = "Options";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private TableLayoutPanel tableLayoutPanel1;
      private Label label1;
      private TextBox tbxImageEditor;
      private Button btnImageEditorSearch;
      private Button btnOK;
      private Button btnCancel;
   }
}