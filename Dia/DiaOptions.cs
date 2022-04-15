namespace Dia
{
   public static class DiaOptions
   {
      private const string SETTINGS_FILE = "settings.cfg";

      public enum SortingModeEnum
      {
         ByName,
         Random
      }

      public static OptionValue<int> ImageShowMilliSecs { get; set; } = new OptionValue<int>(1000);
      public static OptionValue<SortingModeEnum> SortingMode { get; set; } = new OptionValue<SortingModeEnum>(SortingModeEnum.ByName);
      public static OptionValue<string> ImageEditor { get; set; } = new OptionValue<string>("mspaint");

      public static bool IsCustomized => ImageShowMilliSecs.IsCustomized || SortingMode.IsCustomized || ImageEditor.IsCustomized;

      public static void SaveToFile()
      {
         try
         {
            string[] lines = {
               ImageShowMilliSecs.Serialize(),
               SortingMode.Serialize(),
               ImageEditor.Serialize()
            };

            File.WriteAllLines(SETTINGS_FILE, lines);
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error saving settings: {ex.Message}");
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
         }
         catch
         {
         }
      }
   }
}
