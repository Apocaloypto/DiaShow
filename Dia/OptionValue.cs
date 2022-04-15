namespace Dia
{
   internal class OptionValue<T>
   {
      private readonly T _defaultValue;
      
      public T CurrentValue { get; set; }

      public OptionValue(T defaultValue)
      {
         _defaultValue = defaultValue;
         CurrentValue = defaultValue;
      }

      public void Reset()
      {
         CurrentValue = _defaultValue;
      }
   }
}
