﻿namespace Dia.Dialogs
{
   public partial class GlobalOptions : Form
   {
      public GlobalOptions()
      {
         InitializeComponent();

         SetCurrentValues();
      }

      private void SetCurrentValues()
      {
         tbxImageEditor.Text = DiaOptions.ImageEditor.CurrentValue;
      }

      private void OnBtnClickedSearchImageEditor(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Filter = "executables (*.exe)|*.exe|All files (*.*)|*.*";
         
         if (ofd.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
         {
            tbxImageEditor.Text = ofd.FileName;
         }
      }

      private void OnBtnClickedOK(object sender, EventArgs e)
      {
         DiaOptions.ImageEditor.CurrentValue = tbxImageEditor.Text;
         DialogResult = DialogResult.OK;
         Close();
      }

      private void OnBtnClickedCancel(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }

      private void OnBtnClickedSetDefaults(object sender, EventArgs e)
      {
         DiaOptions.ImageEditor.Reset();
         SetCurrentValues();
      }
   }
}
