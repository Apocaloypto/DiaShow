namespace Dia
{
   internal static class DiaOptions
   {
      public enum SortingModeEnum
      {
         ByName,
         Random
      }

      public static OptionValue<int> ImageShowMilliSecs { get; set; } = new OptionValue<int>(1000);
      public static OptionValue<SortingModeEnum> SortingMode { get; set; } = new OptionValue<SortingModeEnum>(SortingModeEnum.ByName);
      public static OptionValue<string> ImageEditor { get; set; } = new OptionValue<string>("mspaint");
   }
}
