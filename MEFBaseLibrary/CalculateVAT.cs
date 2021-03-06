﻿
using System.Composition;

namespace MEFBaseLibrary
{
    [Export(typeof(ICalculateVAT))]
    public class CalculateVat : ICalculateVAT
    {
        public decimal CalcVAT(decimal amount)
        {
            return amount * (decimal)0.1;
        }
    }
}
