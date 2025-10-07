using controleContas;
using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        Conta conta1 = new Conta(123456, 1500.00m);
        Conta conta2 = new Conta(654321, 2341.42m);

        // Criando clientes associados às contas
        Cliente cliente1 = new Cliente("João Silva", "12345678901", 30, conta1);
        Cliente cliente2 = new Cliente("Maria Souza", "98765432100", 25, conta2);

        Console.WriteLine("=== CONTAS CADASTRADAS ===");
        Console.WriteLine(cliente1);
        Console.WriteLine(cliente2);
        Console.WriteLine();

        // Entrada do usuário para depósito
        Console.Write("Digite o valor a depositar na conta 1: R$");
        decimal valorDeposito = decimal.Parse(Console.ReadLine()!); // Use TryParse se quiser validar
        conta1.deposito(valorDeposito);
        Console.WriteLine($"Depósito de {valorDeposito:C} realizado na conta {conta1.Numero}. Saldo atual: {conta1.Saldo:C}");

        // Entrada do usuário para saque
        Console.Write("Digite o valor a sacar da conta 2: R$");
        decimal valorSaque = decimal.Parse(Console.ReadLine()!);
        decimal novoSaldo = conta2.saque(valorSaque);
        Console.WriteLine($"Saque de {valorSaque:C} realizado na conta {conta2.Numero}. Saldo atual: {novoSaldo:C}");

        Console.WriteLine();

        // Saldo total das duas contas
        decimal saldoTotal = conta1.Saldo + conta2.Saldo;
        Console.WriteLine($"Saldo total das duas contas: {saldoTotal:C}");

        // Conta com maior saldo
        Conta maior = Conta.ContaComMaiorSaldo(conta1, conta2);
        Console.WriteLine($"Conta com maior saldo: {maior.Numero}");

        decimal valor;
        while (!decimal.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Valor inválido, digite novamente:");
        }

    }

}
