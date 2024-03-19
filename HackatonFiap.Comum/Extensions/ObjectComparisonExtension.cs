using System.Collections.Generic;
using System.Reflection;


namespace Common.Extensions
{
    public static class ObjectComparisonExtension
    {
        public static List<Variance> DetailedCompare<T>(this T atual, T novo)
        {
            var bindingFlags = BindingFlags.Instance |
                                BindingFlags.NonPublic |
                                BindingFlags.Public;

            List<Variance> variances = new List<Variance>();
            var fi = atual.GetType().GetFields(bindingFlags);
            foreach (var f in fi)
            {
                Variance v = new Variance();
                v.Dado = f.Name.Replace(">k__BackingField", "").Replace("<", "");
                v.ValorAtual = f.GetValue(atual);
                v.NovoValor = f.GetValue(novo);
                if (!Equals(v.ValorAtual, v.NovoValor))
                    variances.Add(v);

            }
            return variances;
        }
    }

    public class Variance
    {
        public string Dado { get; set; }
        public object ValorAtual { get; set; }
        public object NovoValor { get; set; }
    }
}
