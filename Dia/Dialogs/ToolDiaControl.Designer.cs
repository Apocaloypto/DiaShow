namespace Dia.Dialogs
{
   partial class ToolDiaControl
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
            _pictureBox.UnregisterEvents(this);

            if (components != null)
            {
               components.Dispose();
            }

            _diaController.ContextChanged -= _diaController_ContextChanged;
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolDiaControl));
         this.btnPlayPause = new Dia.Controls.PlayPauseButton();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.options1 = new Dia.Controls.DiaControlOptions();
         this.btnForward = new System.Windows.Forms.Button();
         this.btnBack = new System.Windows.Forms.Button();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnPlayPause
         // 
         this.btnPlayPause.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnPlayPause.IsPlaying = false;
         this.btnPlayPause.Location = new System.Drawing.Point(102, 115);
         this.btnPlayPause.Name = "btnPlayPause";
         this.btnPlayPause.PauseImage = global::Dia.Properties.Resources.pause;
         this.btnPlayPause.PlayImage = global::Dia.Properties.Resources.play;
         this.btnPlayPause.Size = new System.Drawing.Size(93, 24);
         this.btnPlayPause.TabIndex = 2;
         this.btnPlayPause.UseVisualStyleBackColor = true;
         this.btnPlayPause.Click += new System.EventHandler(this.OnClickedPlayPause);
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 3;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Controls.Add(this.btnPlayPause, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.options1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.btnBack, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.btnForward, 2, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 142);
         this.tableLayoutPanel1.TabIndex = 4;
         // 
         // options1
         // 
         this.tableLayoutPanel1.SetColumnSpan(this.options1, 3);
         this.options1.DiaController = null;
         this.options1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.options1.Location = new System.Drawing.Point(3, 3);
         this.options1.Name = "options1";
         this.options1.Size = new System.Drawing.Size(291, 106);
         this.options1.TabIndex = 4;
         // 
         // btnForward
         // 
         this.btnForward.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
         this.btnForward.Location = new System.Drawing.Point(201, 115);
         this.btnForward.Name = "btnForward";
         this.btnForward.Size = new System.Drawing.Size(93, 24);
         this.btnForward.TabIndex = 6;
         this.btnForward.UseVisualStyleBackColor = true;
         this.btnForward.Click += new System.EventHandler(this.OnBtnClickedNext);
         // 
         // btnBack
         // 
         this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
         this.btnBack.Location = new System.Drawing.Point(3, 115);
         this.btnBack.Name = "btnBack";
         this.btnBack.Size = new System.Drawing.Size(93, 24);
         this.btnBack.TabIndex = 5;
         this.btnBack.UseVisualStyleBackColor = true;
         this.btnBack.Click += new System.EventHandler(this.OnBtnClickedPrev);
         // 
         // ToolDiaControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(321, 166);
         this.Controls.Add(this.tableLayoutPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "ToolDiaControl";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
         this.Text = "Diashow-Controller";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion
      private Controls.PlayPauseButton btnPlayPause;
      private TableLayoutPanel tableLayoutPanel1;
      private Controls.DiaControlOptions options1;
      private Button btnBack;
      private Button btnForward;
   }
}