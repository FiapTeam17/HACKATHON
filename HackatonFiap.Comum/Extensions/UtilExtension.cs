using System.Globalization;

namespace Common.Extensions
{
    public static class UtilExtension
    {
        public static DateTime GetData(string sData)
        {
            try
            {
                return DateTime.ParseExact(sData.Trim()[..10], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
            catch (Exception)
            {

                return DateTime.ParseExact(sData.Trim()[..10], "MM/dd/yyyy", CultureInfo.InvariantCulture);

            }
        }

        public static string GetDecodedEnvironmentVariable(string chaveConfiguracao)
        {
            chaveConfiguracao = chaveConfiguracao.Replace("<", "").Replace(">", "");
            var valor = Environment.GetEnvironmentVariable(chaveConfiguracao) ?? chaveConfiguracao;

            try
            {
                return valor.Base64Decode();
            }
            catch
            {
                return valor;
            }
        }
    }
}    