using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, string> contas = new Dictionary<string, string>();
        Dictionary<string , double> saldo = new Dictionary<string, double>();

        bool logado = false;
        int opc = 0;
        string usuarioLogado = "";
        while (opc != 3)
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║             BANCO VS            ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║               MENU              ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║1 - LOGIN                        ║");
            Console.WriteLine("║2 - CADASTRO                     ║");
            Console.WriteLine("║3 - ENCERRAR                     ║");
            Console.WriteLine("╚═════════════════════════════════╝");

            opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    usuarioLogado = loginConta(contas);
                    if (usuarioLogado != " ")
                    {
                        logado = true;
                    }
                    else
                    {
                        logado = false;
                    }
                    break;

                case 2:
                    cadastroConta(contas, saldo);
                    break;

                case 3:
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
                
            if (logado == true)
            {
                
                int opcL = 0;
                while (opcL != 4 && opcL != 5)
                {
                    Console.WriteLine("╔═════════════════════════════════╗");
                    Console.WriteLine("║1 - SALDO                        ║");
                    Console.WriteLine("║2 - DEPOSITO                     ║");
                    Console.WriteLine("║3 - SAQUE                        ║");
                    Console.WriteLine("║4 - LOGOUT                       ║");
                    Console.WriteLine("║5 - ENCERRAR                     ║");
                    Console.WriteLine("╚═════════════════════════════════╝");

                    opcL = int.Parse(Console.ReadLine());
                    
                    switch (opcL)
                    {
                        case 1:
                            SaldoConta(saldo, usuarioLogado);
                            break;

                        case 2:
                            Deposito(saldo, usuarioLogado);
                            break;

                        case 3:
                            Saque(saldo, usuarioLogado);
                            break;

                        case 4:
                            logado = false;
                            Console.WriteLine("Logout realizado com sucesso.");
                            break;

                        case 5:
                            opc = 3;
                            Console.WriteLine("Programa encerrado.");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }
        }
    }

    public static string loginConta(Dictionary<string, string> contas)
    {
        Console.WriteLine("╔═════════════════════════════════╗");
        Console.WriteLine("║INSIRA SEU NOME DE USUÁRIO       ║");
        Console.WriteLine("╚═════════════════════════════════╝");
        string contaLogin = Console.ReadLine();

        Console.WriteLine("╔═════════════════════════════════╗");
        Console.WriteLine("║INSIRA A SENHA                   ║");
        Console.WriteLine("╚═════════════════════════════════╝");
        string senhaLogin = Console.ReadLine();

        if (contas.ContainsKey(contaLogin) && contas[contaLogin] == senhaLogin)
        {
            Console.WriteLine("Login realizado com sucesso.");
            
            return contaLogin;
        }
        else
        {
            Console.WriteLine("Usuário ou senha incorretos.");
            return "";
        }
    }

    public static void cadastroConta(Dictionary<string, string> contas, Dictionary<string, double> saldo)
    {
        Console.WriteLine("╔═════════════════════════════════╗");
        Console.WriteLine("║INSIRA SEU NUMERO DE USUÁRIO     ║");
        Console.WriteLine("╚═════════════════════════════════╝");
        string contaCadastro = Console.ReadLine();

        Console.WriteLine("╔═════════════════════════════════╗");
        Console.WriteLine("║INSIRA A SENHA DESEJADA          ║");
        Console.WriteLine("╚═════════════════════════════════╝");
        string senhaCadastro = Console.ReadLine();

        contas.Add(contaCadastro, senhaCadastro);
        saldo.Add(contaCadastro, 0);

        Console.WriteLine("Conta cadastrada com sucesso.");
    }
    public static void SaldoConta(Dictionary<string, double> saldo, string usuarioLogado)
    {
        Console.WriteLine("Saldo do usuário {0}" ,usuarioLogado);
        Console.WriteLine("R${0:f2}" ,saldo[usuarioLogado]);
    }

    public static void Deposito(Dictionary<string, double> saldo, string usuarioLogado)
    {
        Console.WriteLine("Qual o valor do deposito?");
        double deposito = double.Parse(Console.ReadLine());
        saldo[usuarioLogado] += deposito;

        Console.WriteLine("Saldo do usuário {0}" ,usuarioLogado);
        Console.WriteLine("Após o deposito de R${0:f2}" ,deposito);
        Console.WriteLine("É de R${0:f2}", saldo[usuarioLogado]);
    }
    public static void Saque(Dictionary<string, double> saldo, string usuarioLogado)
    {
        Console.WriteLine("Qual o valor do saque?");
        double saque = double.Parse(Console.ReadLine());
        if (saque < saldo[usuarioLogado]){
        saldo[usuarioLogado] -= saque;

        Console.WriteLine("Saldo do usuário {0}" ,usuarioLogado);
        Console.WriteLine("Após o saque de R${0:f2}" ,saque);
        Console.WriteLine("É de R${0:f2}", saldo[usuarioLogado]);
        }
        else
        {
            Console.WriteLine("Valor de Saquei indisponível");
        }
    }
}