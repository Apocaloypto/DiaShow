namespace Dia
{
   public partial class Options : Form
   {
      public Options()
      {
         InitializeComponent();

         tbxDuration.Text = $"{DiaOptions.ImageShowMilliSecs}";
      }

      private void OnBtnClickedCancel(object sender, EventArgs e)
      {
         Close();
      }

      private void OnBtnClickedOK(object sender, EventArgs e)
      {
         try
         {
            DiaOptions.ImageShowMilliSecs = Convert.ToInt32(tbxDuration.Text);
            Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error converting the value: {ex.Message}");
         }
      }
   }
}
