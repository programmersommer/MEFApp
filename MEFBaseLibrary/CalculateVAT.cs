
using System.Composition;

namespace MEFBaseLibrary
{
    [Export(typeof(ICalculateVAT))]
    public class CalculateVAT : ICalculateVAT
    {
        public decimal CalcVAT(decimal amount)
        {
            return amount * (decimal)0.1;
        }
    }
}
