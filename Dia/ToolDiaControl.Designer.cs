namespace Dia
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
         this.progTimer = new System.Windows.Forms.ProgressBar();
         this.btnReverse = new System.Windows.Forms.Button();
         this.btnPlayPause = new Dia.PlayPauseButton();
         this.btnForward = new System.Windows.Forms.Button();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // progTimer
         // 
         this.tableLayoutPanel1.SetColumnSpan(this.progTimer, 3);
         this.progTimer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.progTimer.Location = new System.Drawing.Point(3, 3);
         this.progTimer.Name = "progTimer";
         this.progTimer.Size = new System.Drawing.Size(251, 24);
         this.progTimer.Step = 1;
         this.progTimer.TabIndex = 0;
         // 
         // btnReverse
         // 
         this.btnReverse.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnReverse.Image = global::Dia.Properties.Resources.back;
         this.btnReverse.Location = new System.Drawing.Point(3, 33);
         this.btnReverse.Name = "btnReverse";
         this.btnReverse.Size = new System.Drawing.Size(79, 24);
         this.btnReverse.TabIndex = 1;
         this.btnReverse.UseVisualStyleBackColor = true;
         // 
         // btnPlayPause
         // 
         this.btnPlayPause.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnPlayPause.Location = new System.Drawing.Point(88, 33);
         this.btnPlayPause.Name = "btnPlayPause";
         this.btnPlayPause.PauseImage = global::Dia.Properties.Resources.pause;
         this.btnPlayPause.PlayImage = global::Dia.Properties.Resources.play;
         this.btnPlayPause.Size = new System.Drawing.Size(79, 24);
         this.btnPlayPause.TabIndex = 2;
         this.btnPlayPause.UseVisualStyleBackColor = true;
         this.btnPlayPause.Click += new System.EventHandler(this.OnClickedPlayPause);
         // 
         // btnForward
         // 
         this.btnForward.Dock = System.Windows.Forms.DockStyle.Fill;
         this.btnForward.Image = global::Dia.Properties.Resources.forward;
         this.btnForward.Location = new System.Drawing.Point(173, 33);
         this.btnForward.Name = "btnForward";
         this.btnForward.Size = new System.Drawing.Size(81, 24);
         this.btnForward.TabIndex = 3;
         this.btnForward.UseVisualStyleBackColor = true;
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
         this.tableLayoutPanel1.Controls.Add(this.progTimer, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.btnForward, 2, 1);
         this.tableLayoutPanel1.Controls.Add(this.btnReverse, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.btnPlayPause, 1, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 60);
         this.tableLayoutPanel1.TabIndex = 4;
         // 
         // ToolDiaControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(281, 84);
         this.Controls.Add(this.tableLayoutPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "ToolDiaControl";
         this.Text = "ToolDiaControl";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private ProgressBar progTimer;
      private Button btnReverse;
      private PlayPauseButton btnPlayPause;
      private Button btnForward;
      private TableLayoutPanel tableLayoutPanel1;
   }
}