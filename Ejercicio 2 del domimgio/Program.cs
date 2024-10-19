using System;

class CuentaBancaria
{
    private decimal saldo;

    public CuentaBancaria(decimal saldoInicial)
    {
        saldo = saldoInicial;
    }

    public void ConsultarSaldo()
    {
        Console.WriteLine($"Su saldo actual es: {saldo:C}");
    }

    public void Depositar(decimal cantidad)
    {
        if (cantidad > 0)
        {
            saldo += cantidad;
            Console.WriteLine($"Has depositado {cantidad:C}. Tu nuevo saldo es {saldo:C}");
        }
        else
        {
            Console.WriteLine("No se puede depositar una cantidad negativa o cero.");
        }
    }

    public void Retirar(decimal cantidad)
    {
        if (cantidad > 0 && cantidad <= saldo)
        {
            saldo -= cantidad;
            Console.WriteLine($"Has retirado {cantidad:C}. Tu nuevo saldo es {saldo:C}");
        }
        else if (cantidad > saldo)
        {
            Console.WriteLine("Fondos insuficientes para esta operación.");
        }
        else
        {
            Console.WriteLine("No se puede retirar una cantidad negativa o cero.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CuentaBancaria cuenta = new CuentaBancaria(1000); // Saldo inicial de 1000
        int opcion;

        do
        {
            Console.WriteLine("\nMenú de Cuenta Bancaria:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    cuenta.ConsultarSaldo();
                    break;
                case 2:
                    Console.Write("Ingrese la cantidad a depositar: ");
                    decimal deposito = Convert.ToDecimal(Console.ReadLine());
                    cuenta.Depositar(deposito);
                    break;
                case 3:
                    Console.Write("Ingrese la cantidad a retirar: ");
                    decimal retiro = Convert.ToDecimal(Console.ReadLine());
                    cuenta.Retirar(retiro);
                    break;
                case 4:
                    Console.WriteLine("Gracias por utilizar el sistema bancario. ¡Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 4);
    }
}
