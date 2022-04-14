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

      public static IEnumerable<string> ConsiderSortMode(this IEnumerable<string> src, DiaOptions.SortingModeEnum sortMode)
      {
         switch (sortMode)
         {
            case DiaOptions.SortingModeEnum.ByName:
               return src.OrderBy(str => str);
            case DiaOptions.SortingModeEnum.Random:
               return src.ShuffleIterator(new Random());
            default:
               return src;
         }
      }
   }
}
