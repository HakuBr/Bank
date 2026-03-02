using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank.Models
{
    public abstract class Account
    {
        public Users Titular { get; private set; }
        public decimal Saldo { get; protected set; }
        public decimal Saldo_devedor { get; protected set; }
        public abstract string TipoConta { get; }

        public Account(Users titular)
        {
            Titular = titular;
            Saldo = 0;
            Saldo_devedor = 0;
        }

        public void Dados()
        {
            //Gere o número da conta usando Geradores Congruentes Lineares
            Console.WriteLine($"Número da Conta: ");
            Console.WriteLine($"Titular da Conta: {Titular.Nome}");
            Console.WriteLine($"Saldo: {Saldo}");
            Console.WriteLine($"Saldo Devedor: {Saldo_devedor}");
            Console.WriteLine($"CPF: {Titular.Cpf}");
            Console.WriteLine($"Email: {Titular.Email}");
            Console.WriteLine($"Tipo de Conta: {TipoConta}");
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido");
            }
            else
            {

                Saldo += valor;
                Console.WriteLine($"Saldo: {Saldo}");
            }
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= 0 || valor > Saldo)
            {
                Console.WriteLine("Valor inválido ou saldo insuficiente");
            }
            else
            {
                Saldo -= valor;
                Console.WriteLine($"Saldo: {Saldo}");
            }
            
        }

        public virtual void TransferirPara(Account destino, decimal valor)
        {
            if (destino == null)
            {
                Console.WriteLine("Usuário inexistente");
            }
            else
            {

                Sacar(valor);
                destino.Depositar(valor);
            }

        }

        public virtual void Emprestimo(decimal valor) // É void pq, apesar de tomar uma ação, o método, por definição, não retorna nada
        {

            decimal renda;

            renda = Titular.RendaMensal ?? 0; // a renda pode ser nula então deve-se tratar esse erro
           
            if (valor <= 0 || valor > renda * (1.30m))
            {
                Console.WriteLine("Valor inválido ou superior ao limtie de crédito mensal");
            }
            else
            {
                Saldo += valor;
                Saldo_devedor += valor * 1.12m; // O valor do empréstimo mais os juros de 12% (valor * 1.12)
                Console.WriteLine($"Empréstimo concedido no valor de {valor:C}. \nSaldo atual: {Saldo:C}. \nSaldo devedor: {valor * 1.12m:C}");
            }
            
        }
    }
}