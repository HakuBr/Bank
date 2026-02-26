using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Services
{
    public class BankSystem
    {

        public Users? UsuarioLogado { get; private set; }


        public List<Account> Contas { get; } = new();
        private List<Users> usuarios = new();


        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("Bem-vinde ao sistema que roubará seus anos de vida. Escolha as opções:");
                Console.WriteLine("1- Login");
                Console.WriteLine("2- Cadastro");
                Console.WriteLine("0- Sair");
                Console.WriteLine("Escolha uma das opções: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Login();
                        break; // o break para a execução do bloco de código especifico (for, switch, if e while)
                    case "2":
                        Cadastro();
                        break;
                    case "0":
                        Console.WriteLine("Programa encerrado");
                        return; // o return encerra a excecução do método/função inteiro 
                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
                Console.Clear();
            }
        }

        public void MenuLogado()
        {
            Console.WriteLine("Você está logado, o que deseja fazer?");
            Console.WriteLine("1- Ver dados da conta");
            Console.WriteLine("2- Transferir");
            Console.WriteLine("3- Depositar");
            Console.WriteLine("4- Empréstimo");
            Console.WriteLine("5- Sacar");
            Console.WriteLine("6- Sair da conta");
            Console.WriteLine("0- Deletar a conta");
            Console.WriteLine("Escolha uma das opções: ");

            string op = Console.ReadLine();

            while (true)
            {
                switch (op)
                {
                    case "1":
                        Account conta = Contas.Find(c => c.Titular == UsuarioLogado);
                        if (conta != null)
                        {
                            conta.Dados();
                        }
                        break;
                    case "2":
                        decimal value;
                        Console.WriteLine("Quanto você deseja transferir?");
                        Console.WriteLine("Valor: ");
                        do // executa primeiro e pergunta depois enquanto a condição não for satisfeita
                        {
                            Console.WriteLine("Valor inválido, digite novamente");

                        } while (!decimal.TryParse(Console.ReadLine(), out value)); // Tenta converter o input em decimal (ou qualquer outro tipo) e retorna um bool armazenando o input na variável, 
                                                                                    // se retornar false quer dizer que não foi possivel transformar, então não é um decimal, então não é um número, inverter o valor (true) faz o while funcionar

                        Console.WriteLine("Digite o CPF do recebedor: ");
                        string recedor = Console.ReadLine();
                        Account conta_destino = Contas.Find(c => c.Titular.Cpf == recedor);
                        Account conta_origem = Contas.Find(c => c.Titular == UsuarioLogado);
                        conta_origem.TransferirPara(conta_destino, value);
                        break;
                    case "3":
                        decimal deposit_value;
                        Console.WriteLine("Quanto você deseja depositar?");
                        Console.WriteLine("Valor: ");
                        do
                        {
                            Console.WriteLine("Valor inválido, digite novamente");

                        } while (!decimal.TryParse(Console.ReadLine(), out deposit_value));
                        Account origin_deposit_account = Contas.Find(c => c.Titular == UsuarioLogado);
                        origin_deposit_account.Depositar(deposit_value);
                        break;
                    case "4":
                        decimal loan_value;
                        Console.WriteLine("Quanto você deseja de empréstimo?");
                        Console.WriteLine("Valor: ");
                        do
                        {
                            Console.WriteLine("Valor inválido, digite novamente");

                        } while (!decimal.TryParse(Console.ReadLine(), out loan_value));
                        Account origin_loan_account = Contas.Find(c => c.Titular == UsuarioLogado);
                        origin_loan_account.Emprestimo(loan_value);
                        break;
                    case "5":
                        decimal take_out_value;
                        Console.WriteLine("Quanto você deseja sacar?");
                        Console.WriteLine("Valor: ");
                        do
                        {
                            Console.WriteLine("Valor inválido, digite novamente");

                        } while (!decimal.TryParse(Console.ReadLine(), out take_out_value));
                        Account origin_take_out_account = Contas.Find(c => c.Titular == UsuarioLogado);
                        origin_take_out_account.Sacar(take_out_value);
                        break;
                    case "6":
                        Menu();
                        break;
                    case "0":
                        DeletarConta();
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;


                }
            }


        }


        public void Cadastro()
        {

            // O usuário deve decidir qual tipo de conta ele quer
            // Ele deve poder voltar para o login
            Console.WriteLine("Cadastro");
            string nome = ValidarNome();
            string cpf = ValidarCPF();
            string email = ValidarEmail();
            string senha = ValidarSenha();
            decimal rendamensal = ValidarRenda();
            int idade = ValidarIdade();
            string cnpj = ValidarCNPJ();

            Users novo = new Users(nome, cpf, email, senha, rendamensal, idade, cnpj);
            Account conta = new ContaCorrente(novo);
            Console.WriteLine("Cadastro realizado com sucesso");
            Console.Clear();
            Login();
        }

        public Users Login()
        {
            Users user = null;
            bool autenticado = false;

            do
            {
                Console.WriteLine("Login");
                Console.WriteLine("CPF: ");
                string cpf = Console.ReadLine();

                Console.WriteLine("Senha: ");
                string senha = Console.ReadLine();

                user = usuarios.Find(u => u.Cpf == cpf && u.Senha == senha);

                if (user == null)
                {
                    Console.WriteLine("CPF ou senha incorreta");
                }
                else
                {
                    autenticado = true;
                    UsuarioLogado = user;
                    Console.WriteLine("Login realizado com sucesso");
                    MenuLogado();
                }
            } while (!autenticado);
            Console.Clear();
            return user;
        }

        public void DeletarConta()
        {
            //Se a pessoa escreveu errado e quiser voltar?
            Console.Clear();
            Users user = null;
            bool authentication = false;
            Console.WriteLine("Digite seu cpf: ");
            string cpf = Console.ReadLine();
            user = usuarios.Find(u => u.Cpf == cpf);

            do
            {
                Console.WriteLine("Digite sua senha: ");
                string senha = Console.ReadLine();


                if (user.Senha == senha)
                    authentication = true;
                else
                    Console.WriteLine("Senha incorreta. Tente novamente");
            } while (!authentication);

            usuarios.Remove(user);
            Console.Clear();
            Console.WriteLine("Conta apagada com sucesso");
        }

        private string ValidarNome()
        {
            string nome;
            bool nomeValido;
            do
            {
                Console.WriteLine("Nome: ");
                //nome não pode ser vazio, não pode ter número e não pode ter sinal de pontuação
                nome = Console.ReadLine() ?? "";
                nomeValido = !string.IsNullOrWhiteSpace(nome) && nome.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
                if (!nomeValido) Console.WriteLine("Nome inválido");
            } while (!nomeValido);
            Console.Clear();
            return nome;
        }

        private string ValidarCPF()
        {
            string CPF;
            bool CPFValido;
            do
            {
                Console.WriteLine("Digite seu CPF: ");
                CPF = Console.ReadLine();
                CPFValido = CPF.Length == 11 && CPF.All(char.IsDigit) && !usuarios.Any(u => u.Cpf == CPF);
                if (!CPFValido) Console.WriteLine("CPF inválido ou já cadastrado");
            } while (!CPFValido);
            Console.Clear();
            return CPF;
        }

        private string ValidarEmail()
        {
            string email;
            bool emailValido;
            do
            {
                Console.WriteLine("Digite seu email: ");
                email = Console.ReadLine();
                emailValido = !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".");
                if (!emailValido) Console.WriteLine("Email inválido");
            } while (!emailValido);
            Console.Clear();
            return email;
        }

        private decimal ValidarRenda()
        {
            decimal renda;
            bool rendaValida;
            do
            {
                Console.WriteLine("Digite sua renda mensal: ");
                rendaValida = decimal.TryParse(Console.ReadLine(), out renda) && renda >= 0;
                if (!rendaValida) Console.WriteLine("Renda inválida");
            } while (!rendaValida);
            Console.Clear();
            return renda;
        }

        private int ValidarIdade()
        {
            int idade;
            bool idadeValida;
            do
            {
                Console.WriteLine("Digite sua idade: ");
                idadeValida = int.TryParse(Console.ReadLine(), out idade) && idade >= 18;
                if (!idadeValida) Console.WriteLine("Você deve ser maior de idade para acessar o sistema");
            } while (!idadeValida);
            Console.Clear();
            return idade;
        }
        private string ValidarCNPJ()
        {
            string cnpj;
            bool cnpjValido;
            do
            {
                Console.WriteLine("Digite seu CNPJ (Se tiver): ");
                cnpj = Console.ReadLine();
                if (string.IsNullOrEmpty(cnpj)) cnpjValido = true;
                else cnpjValido = cnpj.Length == 14 && cnpj.All(char.IsDigit);
                if (!cnpjValido) Console.Write("CNPJ inválido");

            } while (!cnpjValido);
            return cnpj;
        }

        private string ValidarSenha()
        {
            string senha;
            bool senhaValida;
            do
            {
                Console.WriteLine("Crie uma senha: ");
                senha = Console.ReadLine();
                senhaValida = !string.IsNullOrWhiteSpace(senha);
                if (senhaValida) Console.WriteLine("A senha não pode ser vazia");
            } while (!senhaValida);

            return senha;
        }
    }
}
