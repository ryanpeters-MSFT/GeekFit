namespace GeekFit
{
    public static class NumericExtensions
    {
        public static string Cleaned(this decimal value)
        {
            return value.ToString("#.#");
        }
    }
}
