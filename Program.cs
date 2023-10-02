using System;
using System.Collections.Generic;

class Program
{
    static List<User> users = new List<User>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Sistema de Cadastro de Usuários");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CadastrarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarUsuario()
    {
        Console.Write("Digite o nome do usuário: ");
        string nome = Console.ReadLine();
        Console.Write("Digite a data de nascimento do usuário (formato: dd/mm/yyyy): ");
        DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
        Console.Write("Digite o salário do usuário: ");
        double salario = double.Parse(Console.ReadLine());
        Console.Write("Digite o sexo do usuário (F para feminino, M para masculino): ");
        char sexo = char.Parse(Console.ReadLine());
        Console.Write("Digite o estado civil do usuário: ");
        string estadoCivil = Console.ReadLine();

        User newUser = new User(nome, dataNascimento, salario, sexo, estadoCivil);
        users.Add(newUser);

        Console.WriteLine("Usuário cadastrado com sucesso!");
    }

    static void ListarUsuarios()
    {
        Console.WriteLine("Lista de Usuários:");
        foreach (var user in users)
        {
            int idade = CalcularIdade(user.DataNascimento);
            Console.WriteLine($"Nome: {user.Nome}, Idade: {idade}, Salário: {user.Salario}, Sexo: {user.Sexo}, Estado Civil: {user.EstadoCivil}");
        }
    }

    static int CalcularIdade(DateTime dataNascimento)
    {
        DateTime dataAtual = DateTime.Today;
        int idade = dataAtual.Year - dataNascimento.Year;
        if (dataNascimento > dataAtual.AddYears(-idade))
        {
            idade--;
        }
        return idade;
    }
}

class User
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public double Salario { get; set; }
    public char Sexo { get; set; }
    public string EstadoCivil { get; set; }

    public User(string nome, DateTime dataNascimento, double salario, char sexo, string estadoCivil)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Salario = salario;
        Sexo = sexo;
        EstadoCivil = estadoCivil;
    }
}
