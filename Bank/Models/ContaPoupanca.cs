using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models
{
    public class ContaPoupanca : Account
    {
        public ContaPoupanca(Users titular) : base(titular) { }
        public override string TipoConta => "Conta Poupança";

        public void Investimento()
        {
            Console.WriteLine($"Saldo esperado ao final de um ano utilizando a Taxa Básica de Juros (Selic): {Saldo * (decimal)Math.Pow(1.0116, 12)}");
        }
    }
}
