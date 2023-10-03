using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<User> users = new List<User>();
    static int nextId = 1; // Variável para controlar o próximo ID disponível

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Sistema de Cadastro de Usuários");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Editar Usuário");
            Console.WriteLine("4 - Excluir Usuário");
            Console.WriteLine("5 - Sair");
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
                    EditarUsuario();
                    break;
                case "4":
                    ExcluirUsuario();
                    break;
                case "5":
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

        User newUser = new User(nextId++, nome, dataNascimento, salario, sexo, estadoCivil);
        users.Add(newUser);

        Console.WriteLine("Usuário cadastrado com sucesso!");
    }

    static void ListarUsuarios()
    {
        Console.WriteLine("Lista de Usuários:");
        foreach (var user in users)
        {
            int idade = CalcularIdade(user.DataNascimento);
            Console.WriteLine($"ID: {user.Id}, Nome: {user.Nome}, Idade: {idade}, Salário: {user.Salario}, Sexo: {user.Sexo}, Estado Civil: {user.EstadoCivil}");
        }
    }

    static void EditarUsuario()
    {
        Console.Write("Digite o ID do usuário que deseja editar: ");
        int id = int.Parse(Console.ReadLine());

        User user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            Console.WriteLine("Usuário não encontrado.");
            return;
        }

        Console.Write("Digite o novo nome do usuário: ");
        user.Nome = Console.ReadLine();
        Console.Write("Digite a nova data de nascimento do usuário (formato: dd/mm/yyyy): ");
        user.DataNascimento = DateTime.Parse(Console.ReadLine());
        Console.Write("Digite o novo salário do usuário: ");
        user.Salario = double.Parse(Console.ReadLine());
        Console.Write("Digite o novo sexo do usuário (F para feminino, M para masculino): ");
        user.Sexo = char.Parse(Console.ReadLine());
        Console.Write("Digite o novo estado civil do usuário: ");
        user.EstadoCivil = Console.ReadLine();

        Console.WriteLine("Usuário editado com sucesso!");
    }

    static void ExcluirUsuario()
    {
        Console.Write("Digite o ID do usuário que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        User user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            Console.WriteLine("Usuário não encontrado.");
            return;
        }

        users.Remove(user);
        Console.WriteLine("Usuário excluído com sucesso!");
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
    public int Id { get; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public double Salario { get; set; }
    public char Sexo { get; set; }
    public string EstadoCivil { get; set; }

    public User(int id, string nome, DateTime dataNascimento, double salario, char sexo, string estadoCivil)
    {
        Id = id;
        Nome = nome;
        DataNascimento = dataNascimento;
        Salario = salario;
        Sexo = sexo;
        EstadoCivil = estadoCivil;
    }
}
