using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models
{
    public abstract class Account
    {
        public Users Titular { get; private set; }
        public decimal Saldo { get; protected set; }

        public Account(Users titular)
        {
            Titular = titular;
            Saldo = 0;
        }

        public void Dados()
        {
            //Gere o número da conta usando Geradores Congruentes Lineares
            Console.WriteLine($"Número da Conta: ");
            Console.WriteLine($"Titular da Conta: {Titular.Nome}");
            Console.WriteLine($"Saldo: {Saldo}");
            Console.WriteLine($"CPF: {Titular.Cpf}");
            Console.WriteLine($"email: {Titular.Email}");
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("Valor inválido");
            Saldo += valor;
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= 0 || valor > Saldo) throw new ArgumentException("Valor inválido ou saldo insuficiente");
            Saldo -= valor;
        }

        public virtual void TransferirPara(Account destino, decimal valor)
        {
            if (destino == null) throw new ArgumentNullException("Usuário inexistente");
            Sacar(valor);
            destino.Depositar(valor);

        }

        public virtual void Emprestimo(decimal valor) // É void pq, apesar de tomar uma ação, o método, por definição, não retorna nada
        {

            decimal renda;

            renda = Titular.RendaMensal ?? 0; // a renda pode ser nula então deve-se tratar esse erro

            if (valor <= 0 || valor > renda * (1.30m)) throw new ArgumentException("Valor inválido ou superior ao limtie de crédito mensal");
            Saldo += renda * (1.30m);
        }
    }
}
