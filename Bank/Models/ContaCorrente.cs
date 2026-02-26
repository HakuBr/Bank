using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models
{
    public class ContaCorrente : Account
    {
        private const decimal taxa_saque = 0.05m;

        public ContaCorrente(Users titular) : base(titular) { } // Usa um campo (titular) do constructor da classe-mãe como campo da classe filha

        public override void Sacar(decimal valor)
        {
            if (valor <= 0 || valor * (1 + taxa_saque) > Saldo) throw new ArgumentException("Valor inválido ou saldo insuficiente"); // o throw lança um erro
            Saldo -= valor * (1 + taxa_saque);
        }
    }
}
