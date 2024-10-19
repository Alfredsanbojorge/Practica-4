using System;
using System.Collections.Generic;
using System.Linq;

class Estudiante
{
    // Propiedades del estudiante
    public string Nombre { get; set; }
    public List<double> Calificaciones { get; set; }

    // Constructor para inicializar un estudiante con sus calificaciones
    public Estudiante(string nombre, List<double> calificaciones)
    {
        Nombre = nombre;
        Calificaciones = calificaciones;
    }

    // Función para calcular el promedio de calificaciones
    public double CalcularPromedio()
    {
        return Calificaciones.Average();
    }
}

class Program
{
    // Función para agregar un estudiante a la lista
    static void AgregarEstudiante(List<Estudiante> estudiantes, string nombre, List<double> calificaciones)
    {
        Estudiante estudiante = new Estudiante(nombre, calificaciones);
        estudiantes.Add(estudiante);
        Console.WriteLine($"Estudiante {nombre} agregado exitosamente.");
    }

    // Función para determinar el estudiante con el promedio más alto y el más bajo
    static void DeterminarMejorPeorEstudiante(List<Estudiante> estudiantes)
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes en la lista.");
            return;
        }

        // Buscar el estudiante con el promedio más alto y el más bajo
        Estudiante mejorEstudiante = estudiantes.OrderByDescending(e => e.CalcularPromedio()).First();
        Estudiante peorEstudiante = estudiantes.OrderBy(e => e.CalcularPromedio()).First();

        Console.WriteLine($"El estudiante con el mejor promedio es: {mejorEstudiante.Nombre} con un promedio de {mejorEstudiante.CalcularPromedio():F2}");
        Console.WriteLine($"El estudiante con el peor promedio es: {peorEstudiante.Nombre} con un promedio de {peorEstudiante.CalcularPromedio():F2}");
    }

    static void Main(string[] args)
    {
        List<Estudiante> estudiantes = new List<Estudiante>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- Menú de Gestión de Calificaciones ---");
            Console.WriteLine("1. Agregar un nuevo estudiante");
            Console.WriteLine("2. Calcular promedios y mostrar mejor y peor estudiante");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Agregar un nuevo estudiante
                    Console.Write("Ingrese el nombre del estudiante: ");
                    string nombre = Console.ReadLine();

                    List<double> calificaciones = new List<double>();
                    Console.WriteLine("Ingrese las calificaciones del estudiante (escriba 'fin' para terminar):");

                    while (true)
                    {
                        string entrada = Console.ReadLine();
                        if (entrada.ToLower() == "fin")
                            break;

                        if (double.TryParse(entrada, out double calificacion))
                        {
                            calificaciones.Add(calificacion);
                        }
                        else
                        {
                            Console.WriteLine("Por favor, ingrese una calificación válida o 'fin' para terminar.");
                        }
                    }

                    AgregarEstudiante(estudiantes, nombre, calificaciones);
                    break;

                case 2:
                    // Mostrar el mejor y peor estudiante
                    DeterminarMejorPeorEstudiante(estudiantes);
                    break;

                case 3:
                    // Salir del programa
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }
}

