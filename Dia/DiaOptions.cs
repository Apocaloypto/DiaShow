namespace Dia
{
   public static class DiaOptions
   {
      private static string SETTINGS_FILE => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.cfg");

      public enum SortingModeEnum
      {
         ByName,
         Random,
         ByCreationDate,
      }

      public static OptionValue<FormWindowState> MainWindowState { get; } = new OptionValue<FormWindowState>(FormWindowState.Normal);
      public static OptionValue<int> ImageShowMilliSecs { get; } = new OptionValue<int>(1000);
      public static OptionValue<SortingModeEnum> SortingMode { get; } = new OptionValue<SortingModeEnum>(SortingModeEnum.ByName);
      public static OptionValue<string> ImageEditor { get; } = new OptionValue<string>("mspaint");

      public static bool IsCustomized => ImageShowMilliSecs.IsCustomized || SortingMode.IsCustomized || ImageEditor.IsCustomized || MainWindowState.IsCustomized;

      public static string? SaveToFile()
      {
         try
         {
            string[] lines = {
               ImageShowMilliSecs.Serialize(),
               SortingMode.Serialize(),
               ImageEditor.Serialize(),
               MainWindowState.Serialize(),
            };

            File.WriteAllLines(SETTINGS_FILE, lines);
            return SETTINGS_FILE;
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error saving settings: {ex.Message}");
            return null;
         }
      }

      public static void LoadFromFile()
      {
         try
         {
            string[] lines = File.ReadAllLines(SETTINGS_FILE);
            if (lines.Length >= 1)
            {
               ImageShowMilliSecs.Deserialize(lines[0]);
            }

            if (lines.Length >= 2)
            {
               SortingMode.Deserialize(lines[1]);
            }

            if (lines.Length >= 3)
            {
               ImageEditor.Deserialize(lines[2]);
            }

            if (lines.Length >= 4)
            {
               MainWindowState.Deserialize(lines[3]);
            }
         }
         catch
         {
         }
      }
   }
}
