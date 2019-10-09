using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica9
{
    class Program
    {
        public static bool rep = false;
        public static List<string> listaFrutas = new List<string>();
        static void Main(string[] args)
        {
            int op;
            do
            {
                rep = false;
                Console.Clear();
                Console.WriteLine("MENÚ LISTA DE FRUTAS");
                Console.WriteLine("===============================================");
                Console.WriteLine("1- Agregar fruta a la lista");
                Console.WriteLine("2- Mostrar lista de frutas");
                Console.WriteLine("3- Insertar fruta en la lista");
                Console.WriteLine("4- Eliminar fruta de la lista");
                Console.WriteLine("5- Buscar fruta en la lista");
                Console.WriteLine("6- Vaciar lista de frutas");
                Console.WriteLine("7- Salir");
                Console.WriteLine("===============================================");
                Console.Write("Opción de desea realizar: ");
                if (int.TryParse(Console.ReadLine(), out op) && op > 0 && op <= 7)
                {
                    Console.Clear();
                    switch (op)
                    {
                        case 1:
                            agregarFruta();
                            break;
                        case 2:
                            mostrarLista();
                            break;
                        case 3:
                            insertarFruta();
                            break;
                        case 4:
                            eliminarFruta();
                            break;
                        case 5:
                            buscarFruta();
                            break;
                        case 6:
                            vaciarLista();
                            break;
                        case 7:
                            salir();
                            break;
                        default:
                            break;
                    }
                }
                Console.ReadKey();
            } while (rep == true || op != 7);
        }

        public static void agregarFruta()
        {
            Console.WriteLine("Fruta a agregar:");
            string fruta = Console.ReadLine();
            listaFrutas.Add(fruta);
            Console.WriteLine("¡Fruta agregada con éxito!");
        }

        public static void mostrarLista()
        {
            Console.WriteLine("LISTADO DE FRUTAS");
            Console.WriteLine("===============================================");
            foreach (string fruta in listaFrutas)
            {
                int pos = listaFrutas.IndexOf(fruta);
                Console.WriteLine((pos + 1) + "- " + fruta);
            }
        }

        public static void insertarFruta()
        {
            do
            {
                Console.Clear();
                rep = false;
                Console.WriteLine("Posición en de la fruta que desea insertar:");
                if (int.TryParse(Console.ReadLine(), out int pos) && pos > 0 && pos <= listaFrutas.Count())
                {
                    Console.WriteLine("Fruta a insertar en la posición " + pos);
                    string fruta = Console.ReadLine();
                    listaFrutas.Insert((pos - 1), fruta);
                    Console.WriteLine("¡Fruta insertada con éxito!");
                }
                else
                {
                    Console.WriteLine("La posición tiene que estar entre los elementos de la lista y ser un entero positivo");
                    Console.ReadKey();
                }
            } while (rep == true);
        }

        public static void eliminarFruta()
        {
            Console.WriteLine("Fruta que desea eliminar:");
            string fruta = Console.ReadLine();
            if (listaFrutas.Contains(fruta))
            {
                listaFrutas.Remove(fruta);
                Console.WriteLine("¡Fruta eliminada con éxito!");
            }
            else
            {
                Console.WriteLine("No existe esta fruta en la lista");
            }
        }

        public static void buscarFruta()
        {
            Console.WriteLine("Fruta que desea buscar:");
            string fruta = Console.ReadLine();
            if (listaFrutas.Contains(fruta))
            {
                Console.WriteLine("La fruta {0} si está en la lista", fruta);
            }
            else
            {
                Console.WriteLine("La fruta {0} no está en la lista", fruta);
            }
        }

        public static void vaciarLista()
        {
            Console.WriteLine("Presione <enter> para vaciar toda la lista");
            Console.ReadKey();
            listaFrutas.RemoveRange(0, listaFrutas.Count());
            Console.WriteLine("¡Lista vaciada con éxito!");
        }

        public static void salir()
        {
            Console.WriteLine("¡Gracias por usar nuestra lista de frutas!");
            Console.WriteLine("**Presione cualquier tecla para salir**");
        }
    }
}
