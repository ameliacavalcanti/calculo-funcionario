using System;
using System.Collections.Generic;

// CLASSE BASE ABSTRATA
public abstract class Funcionario
{
    public string Nome { get; set; }
    public decimal SalarioBase { get; set; }
    public abstract string Categoria { get; }

    public Funcionario(string nome, decimal salarioBase)
    {
        Nome = nome;
        SalarioBase = salarioBase;
    }

    public abstract decimal CalcularSalario();

    public void ExibirDados()
    {
        decimal salarioFinal = CalcularSalario();

        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Tipo: {Categoria}");
        Console.WriteLine($"Salário Base: R$ {SalarioBase:N2}");
        Console.WriteLine($"Salário FINAL: R$ {salarioFinal:N2}");
        Console.WriteLine(new string('-', 30));
    }
}

// CLASSE DERIVADA 1: Administrativo
public class Administrativo : Funcionario
{
    public override string Categoria => "Administrativo";

    public Administrativo(string nome, decimal salarioBase) : base(nome, salarioBase)
    {
    }

    public override decimal CalcularSalario()
    {
        return SalarioBase * 1.10m;
    }
}

// CLASSE DERIVADA 2: Técnico
public class Tecnico : Funcionario
{
    public override string Categoria => "Técnico";

    public Tecnico(string nome, decimal salarioBase) : base(nome, salarioBase)
    {
    }

    public override decimal CalcularSalario()
    {
        return SalarioBase * 1.20m;
    }
}

// CLASSE DERIVADA 3: Estagiário
public class Estagiario : Funcionario
{
    public override string Categoria => "Estagiário";

    public Estagiario(string nome, decimal salarioBase) : base(nome, salarioBase)
    {
    }

    public override decimal CalcularSalario()
    {
        return SalarioBase / 2m;
    }
}

// PROGRAMA PRINCIPAL
public class Programa
{
    public static void Main(string[] args)
    {
        List<Funcionario> listaFuncionarios = new List<Funcionario>();
        bool continuar = true;

        Console.WriteLine("--- Sistema de Cadastro e Cálculo Salarial de Funcionários ---");

        while (continuar)
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("Selecione o tipo de funcionário para cadastro:");
            Console.WriteLine("1 - Administrativo");
            Console.WriteLine("2 - Técnico");
            Console.WriteLine("3 - Estagiário");
            Console.WriteLine("4 - FINALIZAR CADASTRO e Gerar Relatório");
            Console.Write("Opção: ");

            if (!int.TryParse(Console.ReadLine(), out int opcaoNumerica))
            {
                Console.WriteLine("\n*** ERRO: Digite apenas o NÚMERO da categoria (1 a 4). ***");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            if (opcaoNumerica == 4)
            {
                continuar = false;
                break;
            }

            if (opcaoNumerica < 1 || opcaoNumerica > 3)
            {
                Console.WriteLine("\n*** ERRO: Opção inválida. Digite um número entre 1 e 4. ***");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            Console.Write("Digite o Nome do funcionário: ");
            string nome = Console.ReadLine();

            decimal salarioBase = 0;
            bool salarioValido = false;
            while (!salarioValido)
            {
                Console.Write("Digite o Salário Base (ex: 2500,50): R$ ");
                string inputSalario = Console.ReadLine().Replace('.', ',');
                if (decimal.TryParse(inputSalario, out salarioBase) && salarioBase >= 0)
                {
                    salarioValido = true;
                }
                else
                {
                    Console.WriteLine("Salário inválido ou formato incorreto. Tente novamente.");
                }
            }

            Funcionario novoFuncionario = null;
            switch (opcaoNumerica)
            {
                case 1:
                    novoFuncionario = new Administrativo(nome, salarioBase);
                    break;
                case 2:
                    novoFuncionario = new Tecnico(nome, salarioBase);
                    break;
                case 3:
                    novoFuncionario = new Estagiario(nome, salarioBase);
                    break;
            }

            if (novoFuncionario != null)
            {
                listaFuncionarios.Add(novoFuncionario);
                Console.WriteLine($"\n** {nome} (Categoria {novoFuncionario.Categoria}) cadastrado com sucesso! **");
            }
        }

        Console.WriteLine("\n\n==================================================");
        Console.WriteLine("               RELATÓRIO DE SALÁRIOS");
        Console.WriteLine("==================================================");

        if (listaFuncionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
        }
        else
        {
            foreach (var func in listaFuncionarios)
            {
                func.ExibirDados();
            }
        }

        Console.WriteLine($"Total de Funcionários Processados: {listaFuncionarios.Count}");
        Console.WriteLine("==================================================");
    }
}