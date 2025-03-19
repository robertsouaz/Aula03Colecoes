using System;
using System.ComponentModel;
using Aula03Colecoes.Models;
 using Aula03Colecoes.Models.Enuns;
 namespace Aula03Colecoes
 {
     public class Program
     {
        
        static List<Funcionario> lista = new List<Funcionario>();
        static void Main(string[] args)
        {
            CriarLista();
            // ExibirLista();
            ObterPorId();
            ExemplosListasColecoes();
        }

        public static void ExemplosListasColecoes()
        {
        Console.WriteLine("==================================================");  
        Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");  
        Console.WriteLine("==================================================");  
        CriarLista();
        int opcaoEscolhida = 0;
        do
        {
        Console.WriteLine("\n===== MENU =====");
        Console.WriteLine("1 - Obter Funcionário por Nome");
        Console.WriteLine("2 - Obter Funcionários Recentes");
        Console.WriteLine("3 - Obter Estatísticas");
        Console.WriteLine("4 - Validar Salário e Admissão");
        Console.WriteLine("5 - Validar Nome");
        Console.WriteLine("6 - Obter Funcionários por Tipo");
        Console.WriteLine("0 - Sair");
        Console.Write("\nEscolha uma opção: ");  
        if (!int.TryParse(Console.ReadLine(), out opcaoEscolhida))
        {
            Console.WriteLine("Entrada inválida! Por favor, insira um número.");
            opcaoEscolhida = -1; // Define um valor inválido para evitar execução de opções.
        }
        string mensagem = string.Empty;
        switch (opcaoEscolhida)
        {
        case 1: ObterPorNome(); break;
        case 2: ObterFuncionariosRecentes(); break;
        case 3: ObterEstatisticas(); break;
        case 4: ValidarSalarioAdmissao(); break;
        case 5: ValidarNome(); break;
        case 6: ObterPorTipo(); break;
        case 0: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida!"); break;
        }
        } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);
        Console.WriteLine("==================================================");  
        Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");  
        Console.WriteLine("==================================================");  
        }
        public static void ObterPorNome()
        {
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine() ?? string.Empty;
            var funcionario = lista.FirstOrDefault(f => f.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (funcionario != null)
                Console.WriteLine($"Funcionário encontrado: {funcionario.Nome}, Salário: {funcionario.Salario:C}");
            else
                Console.WriteLine("Funcionário não encontrado.");
        }
        public static void ObterFuncionariosRecentes()
        {
            lista = lista.Where(f => f.Id >= 4).OrderByDescending(f => f.Salario).ToList();
            ExibirLista();
        }

        public static void ObterEstatisticas()
        {
            Console.WriteLine($"Quantidade de funcionários: {lista.Count}");
            Console.WriteLine($"Soma total dos salários: {lista.Sum(f => f.Salario):C}");
        }

        public static void ValidarSalarioAdmissao()
        {
            foreach (var f in lista)
            {
                if (f.Salario <= 0 || f.DataAdmissao > DateTime.Now)
                {
                    Console.WriteLine($"Erro no funcionário {f.Nome}: Salário inválido ou Data de Admissão incorreta.");
                }
            }
        }

        public static void ValidarNome()
        {
            foreach (var f in lista)
            {
                if (f.Nome.Length < 2)
                {
                    Console.WriteLine($"Erro: Nome do funcionário {f.Nome} tem menos de 2 caracteres!");
                }
            }
        }

        public static void ObterPorTipo()
        {
            Console.Write("Digite o tipo de funcionário (CLT = 1, Aprendiz = 2, Estagiário = 3): ");
            Console.Write("Digite o tipo de funcionário (CLT = 1, Aprendiz = 2, Estagiário = 3): ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int tipo))
            {
                Console.WriteLine("Entrada inválida! Por favor, insira um número válido.");
                return;
            }

            var funcionariosFiltrados = lista.Where(f => (int)f.TipoFuncionarios == tipo).ToList();

            if (funcionariosFiltrados.Any())
            {
                Console.WriteLine("\nFuncionários Encontrados:");
                foreach (var f in funcionariosFiltrados)
                {
                    Console.WriteLine($"{f.Nome} - {f.TipoFuncionarios}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum funcionário encontrado para esse tipo.");
            }
        }

        public static void ObterPorId()
        {
            lista = lista.FindAll(x => x.Id > 0);
            ExibirLista();
        }

        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionarios);
                dados += "===============================\n";                
            }
            Console.WriteLine(dados);
        }
    
    public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 150.000M;
            f1.TipoFuncionarios = TipoFuncionariosEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionarios = TipoFuncionariosEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionarios = TipoFuncionariosEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionarios = TipoFuncionariosEnum.Aprendiz;
            lista.Add(f4);
            
            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionarios = TipoFuncionariosEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Rodrigo Garro";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionarios = TipoFuncionariosEnum.CLT;
            lista.Add(f6);
        }
            
 }
}