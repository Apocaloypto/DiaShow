namespace Dia.Controls
{
   public partial class DiaControlOptions : UserControl
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
         new SortingModeViewModel("Random", DiaOptions.SortingModeEnum.Random),
         new SortingModeViewModel("By creation date", DiaOptions.SortingModeEnum.ByCreationDate),
      };

      public DiaController? DiaController { get; set; }

      public DiaControlOptions()
      {
         InitializeComponent();

         cbxSortingMode.DataSource = _sortingModeViewModels;
         cbxSortingMode.DisplayMember = nameof(SortingModeViewModel.Name);
         cbxSortingMode.ValueMember = nameof(SortingModeViewModel.Mode);

         tbxDuration.Text = $"{DiaOptions.ImageShowMilliSecs.CurrentValue}";
         cbxSortingMode.SelectedValue = DiaOptions.SortingMode.CurrentValue;

         btnApply.Enabled = false;
      }

      private void OnBtnClickedApply(object sender, EventArgs e)
      {
         try
         {
            DiaOptions.ImageShowMilliSecs.CurrentValue = Convert.ToInt32(tbxDuration.Text);
            DiaOptions.SortingMode.CurrentValue = (DiaOptions.SortingModeEnum)cbxSortingMode.SelectedValue;

            if (DiaController?.IsPlaying ?? false)
            {
               DiaController?.StopDiaShow();
               DiaController?.StartDiaShow();
            }

            btnApply.Enabled = false;
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error converting the value: {ex.Message}");
         }
      }

      private void OnDurationChanged(object sender, EventArgs e)
      {
         btnApply.Enabled = true;
      }

      private void OnSortmodeChanged(object sender, EventArgs e)
      {
         btnApply.Enabled = true;
      }
   }
}
