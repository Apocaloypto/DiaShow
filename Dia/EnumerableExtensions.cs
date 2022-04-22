using System.Text.RegularExpressions;

namespace Dia
{
   internal static class EnumerableExtensions
   {
      private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random rng)
      {
         var buffer = source.ToList();
         for (int i = 0; i < buffer.Count; i++)
         {
            int j = rng.Next(i, buffer.Count);
            yield return buffer[j];

            buffer[j] = buffer[i];
         }
      }

      public static IOrderedEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector)
      {
         int max = source
             .SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?)m.Value.Length))
             .Max() ?? 0;

         return source.OrderBy(i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0')));
      }

      public static IEnumerable<FileInfo> ConsiderSortMode(this IEnumerable<FileInfo> src, DiaOptions.SortingModeEnum sortMode)
      {
         switch (sortMode)
         {
            case DiaOptions.SortingModeEnum.ByName:
               return src.OrderByAlphaNumeric(file => file.Name);
            case DiaOptions.SortingModeEnum.Random:
               return src.ShuffleIterator(new Random());
            case DiaOptions.SortingModeEnum.ByCreationDate:
               return src.OrderByDescending(file => file.CreationTime);
            default:
               return src;
         }
      }
   }
}
