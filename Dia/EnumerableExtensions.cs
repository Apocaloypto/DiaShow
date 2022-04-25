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

      private static IOrderedEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector, bool asc)
      {
         int max = source
             .SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?)m.Value.Length))
             .Max() ?? 0;

         Func<T, string> orderby = i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0'));

         if (asc)
         {
            return source.OrderBy(orderby);
         }
         else
         {
            return source.OrderByDescending(orderby);
         }
      }

      public static IEnumerable<FileInfo> FilterFileExtension(this IEnumerable<FileInfo> src, string[] extUpper)
      {
         return src.Where(file => extUpper.Contains(Path.GetExtension(file.FullName).ToUpper()));
      }

      public static IEnumerable<FileInfo> ConsiderSortMode(this IEnumerable<FileInfo> src, DiaOptions.SortingModeEnum sortMode)
      {
         switch (sortMode)
         {
            case DiaOptions.SortingModeEnum.ByNameAscending:
               return src.OrderByAlphaNumeric(file => file.Name, true);
            case DiaOptions.SortingModeEnum.ByNameDescending:
               return src.OrderByAlphaNumeric(file => file.Name, false);
            case DiaOptions.SortingModeEnum.Random:
               return src.ShuffleIterator(new Random());
            case DiaOptions.SortingModeEnum.ByCreationDateAscending:
               return src.OrderBy(file => file.CreationTime);
            case DiaOptions.SortingModeEnum.ByCreationDateDescending:
               return src.OrderByDescending(file => file.CreationTime);
            default:
               return src;
         }
      }
   }
}
