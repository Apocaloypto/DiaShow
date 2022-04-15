namespace Dia.Controls
{
   partial class DiaControlOptions
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
         this.label2 = new System.Windows.Forms.Label();
         this.cbxSortingMode = new System.Windows.Forms.ComboBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.btnApply = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label1.Location = new System.Drawing.Point(3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(306, 26);
         this.label1.TabIndex = 0;
         this.label1.Text = "Duration (ms):";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbxDuration
         // 
         this.tbxDuration.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tbxDuration.Location = new System.Drawing.Point(315, 3);
         this.tbxDuration.Name = "tbxDuration";
         this.tbxDuration.Size = new System.Drawing.Size(307, 23);
         this.tbxDuration.TabIndex = 1;
         this.tbxDuration.TextChanged += new System.EventHandler(this.OnDurationChanged);
         // 
         // label2
         // 
         this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label2.Location = new System.Drawing.Point(3, 26);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(306, 26);
         this.label2.TabIndex = 4;
         this.label2.Text = "Sorting";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // cbxSortingMode
         // 
         this.cbxSortingMode.Dock = System.Windows.Forms.DockStyle.Fill;
         this.cbxSortingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cbxSortingMode.FormattingEnabled = true;
         this.cbxSortingMode.Location = new System.Drawing.Point(315, 29);
         this.cbxSortingMode.Name = "cbxSortingMode";
         this.cbxSortingMode.Size = new System.Drawing.Size(307, 23);
         this.cbxSortingMode.TabIndex = 5;
         this.cbxSortingMode.SelectedIndexChanged += new System.EventHandler(this.OnSortmodeChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(637, 110);
         this.groupBox1.TabIndex = 6;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Options";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.cbxSortingMode, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.tbxDuration, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.btnApply, 1, 2);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 22);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 82);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // btnApply
         // 
         this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnApply.Location = new System.Drawing.Point(315, 55);
         this.btnApply.Name = "btnApply";
         this.btnApply.Size = new System.Drawing.Size(307, 24);
         this.btnApply.TabIndex = 6;
         this.btnApply.Text = "Apply";
         this.btnApply.UseVisualStyleBackColor = true;
         this.btnApply.Click += new System.EventHandler(this.OnBtnClickedApply);
         // 
         // Options
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Name = "Options";
         this.Size = new System.Drawing.Size(637, 110);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private Label label1;
      private TextBox tbxDuration;
      private Label label2;
      private ComboBox cbxSortingMode;
      private GroupBox groupBox1;
      private TableLayoutPanel tableLayoutPanel1;
      private Button btnApply;
   }
}