using System;
using System.Collections.Generic;

class Producto
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public Producto(int codigo, string nombre, int cantidad, decimal precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Cantidad = cantidad;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"Código: {Codigo}, Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio:C}";
    }
}

class Program
{
    static List<Producto> inventario = new List<Producto>();

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("\nMenú de Inventario:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto();
                    break;
                case 2:
                    EliminarProducto();
                    break;
                case 3:
                    ModificarProducto();
                    break;
                case 4:
                    ConsultarProducto();
                    break;
                case 5:
                    MostrarTodosLosProductos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 6);
    }

    static void AgregarProducto()
    {
        Console.Write("Ingrese el código del producto: ");
        int codigo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la cantidad del producto: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el precio del producto: ");
        decimal precio = Convert.ToDecimal(Console.ReadLine());

        Producto nuevoProducto = new Producto(codigo, nombre, cantidad, precio);
        inventario.Add(nuevoProducto);
        Console.WriteLine("Producto agregado exitosamente.");
    }

    static void EliminarProducto()
    {
        Console.Write("Ingrese el código del producto a eliminar: ");
        int codigo = Convert.ToInt32(Console.ReadLine());

        Producto producto = inventario.Find(p => p.Codigo == codigo);

        if (producto != null)
        {
            inventario.Remove(producto);
            Console.WriteLine("Producto eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ModificarProducto()
    {
        Console.Write("Ingrese el código del producto a modificar: ");
        int codigo = Convert.ToInt32(Console.ReadLine());

        Producto producto = inventario.Find(p => p.Codigo == codigo);

        if (producto != null)
        {
            Console.Write("Ingrese el nuevo nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.Write("Ingrese la nueva cantidad del producto: ");
            producto.Cantidad = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el nuevo precio del producto: ");
            producto.Precio = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Producto modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ConsultarProducto()
    {
        Console.Write("Ingrese el código del producto a consultar: ");
        int codigo = Convert.ToInt32(Console.ReadLine());

        Producto producto = inventario.Find(p => p.Codigo == codigo);

        if (producto != null)
        {
            Console.WriteLine(producto);
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void MostrarTodosLosProductos()
    {
        if (inventario.Count > 0)
        {
            Console.WriteLine("\nListado de productos en inventario:");
            foreach (var producto in inventario)
            {
                Console.WriteLine(producto);
            }
        }
        else
        {
            Console.WriteLine("El inventario está vacío.");
        }
    }
}

