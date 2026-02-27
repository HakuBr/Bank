using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models
{
    public class Users
    {
        //Campos - Representam o estado brutos do objeto
        public string Nome { get; private set; } // Propriedades são métodos especiais para ler, gravar e calcular o valor dos campos da classe (get e set)
        public string Cpf { get; private set; }
        public string Email { get; set; }
        public string Senha { get; private set; }
        public decimal? RendaMensal { get; set; }
        public int Idade { get; set; }
        public string? Cnpj { get; private set; }
        public decimal Saldo { get; set; }

        // atributos (não presente no código) são diretrizes extras que você dá ao compilador ou ao framework de como trabalhar com aquele dado (classe)


        public Users(string nome, string cpf, string email, string senha, decimal? rendamensal, int idade, string? cnpj) // constructor é o método que é chamado quando o objeto precisa ser criado
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Senha = senha;
            RendaMensal = rendamensal;
            Idade = idade;
            Cnpj = cnpj;
        }
    }
}