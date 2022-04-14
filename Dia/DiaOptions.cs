namespace Dia
{
   internal static class DiaOptions
   {
      public enum SortingModeEnum
      {
         ByName,
         Random
      }

      public static int ImageShowMilliSecs { get; set; } = 1000;
      public static SortingModeEnum SortingMode { get; set; } = SortingModeEnum.ByName;
   }
}
