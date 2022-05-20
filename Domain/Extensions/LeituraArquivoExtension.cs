namespace Domain.Extensions
{
    public static class LeituraArquivoExtension
    {
        public static bool IsHeader(this string line) => line.StartsWith("0#RV");
        public static bool IsFooter(this string line) => line.StartsWith("99#RV");
    }
}
