namespace Domain.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ConvertToDateTime(this string value)
        {
            var anoDaOperacao = int.Parse(value.Substring(0, 4));
            var mesDaOperacao = int.Parse(value.Substring(4, 2));
            var diaDaOperacao = int.Parse(value.Substring(6, 2));

            return new DateTime(anoDaOperacao, mesDaOperacao, diaDaOperacao);
        }

        public static int ConvertToInteger(this string value)
        {
            int.TryParse(value, out int result);
            return result;
        }

        public static decimal ConvertToDecimal(this string value)
        {
            decimal.TryParse(value, out decimal result);
            return result;
        }
        
        public static bool EhIgual(this string value, string comparacao)
        {
            return value.ToUpper().Trim().Equals(comparacao.ToUpper());
        }
    }
}
