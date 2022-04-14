namespace Dia
{
   public partial class Options : Form
   {
      private class SortingModeViewModel
      {
         public string Name { get; set; }
         public DiaOptions.SortingModeEnum Mode { get; set; }

         public SortingModeViewModel(string name, DiaOptions.SortingModeEnum sortingMode)
         {
            Name = name;
            Mode = sortingMode;
         }
      }

      private IList<SortingModeViewModel> _sortingModeViewModels = new List<SortingModeViewModel>()
      {
         new SortingModeViewModel("By name", DiaOptions.SortingModeEnum.ByName),
         new SortingModeViewModel("Random", DiaOptions.SortingModeEnum.Random)
      };

      public Options()
      {
         InitializeComponent();

         tbxDuration.Text = $"{DiaOptions.ImageShowMilliSecs}";

         cbxSortingMode.DataSource = _sortingModeViewModels;
         cbxSortingMode.DisplayMember = nameof(SortingModeViewModel.Name);
         cbxSortingMode.ValueMember = nameof(SortingModeViewModel.Mode);

         cbxSortingMode.SelectedValue = DiaOptions.SortingMode;
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

            DiaOptions.SortingMode = (DiaOptions.SortingModeEnum)cbxSortingMode.SelectedValue;

            Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error converting the value: {ex.Message}");
         }
      }
   }
}
