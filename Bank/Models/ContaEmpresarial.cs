using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models
{
    public class ContaEmpresarial : Account
    {

        public ContaEmpresarial(Users titular) : base(titular) { }

        public override void Emprestimo(decimal valor)
        {
            decimal renda;
            renda = Titular.RendaMensal ?? 0;

            if (valor <= 0 || valor > renda * (1.50m)) throw new ArgumentException("Valor inválido ou supeior ao limite de crédito");
            Saldo += valor;
        }
    }
}
