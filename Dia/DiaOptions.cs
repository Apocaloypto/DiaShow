namespace Dia
{
   public class DiaOptions
   {
      private const string SETTINGS_FILE = "settings.cfg";

      public enum SortingModeEnum
      {
         ByName,
         Random
      }

      public OptionValue<int> ImageShowMilliSecs { get; set; } = new OptionValue<int>(1000);
      public OptionValue<SortingModeEnum> SortingMode { get; set; } = new OptionValue<SortingModeEnum>(SortingModeEnum.ByName);
      public OptionValue<string> ImageEditor { get; set; } = new OptionValue<string>("mspaint");

      public bool IsCustomized => ImageShowMilliSecs.IsCustomized || SortingMode.IsCustomized || ImageEditor.IsCustomized;

      public void SaveToFile()
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

      public void LoadFromFile()
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
