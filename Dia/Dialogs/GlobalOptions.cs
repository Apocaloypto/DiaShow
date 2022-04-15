namespace Dia.Dialogs
{
   public partial class GlobalOptions : Form
   {
      private DiaOptions _diaOptions;

      public GlobalOptions(DiaOptions diaOptions)
      {
         InitializeComponent();

         _diaOptions = diaOptions;

         SetCurrentValues();
      }

      private void SetCurrentValues()
      {
         tbxImageEditor.Text = _diaOptions.ImageEditor.CurrentValue;
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
         _diaOptions.ImageEditor.CurrentValue = tbxImageEditor.Text;
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
         _diaOptions.ImageEditor.Reset();
         SetCurrentValues();
      }
   }
}
