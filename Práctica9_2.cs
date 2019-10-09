using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica9
{
    class Práctica9_2
    {
        //Andrés Lemus 02/10/2019
        public struct Alumno
        {
            public string carnet;
            public string nombre;
            public string carrera;
            private decimal cum;

            public void setCum(decimal cum)
            {

                if (cum > 0 && cum <= 10)
                {
                    this.cum = cum;
                }
            }

            public decimal getCum()
            {
                return cum;
            }
        }

        public static Dictionary<string, Alumno> dicAlumno = new Dictionary<string, Alumno>();
        public static bool rep = false;

        static void Main(string[] args)
        {
            int op = 0;
            do
            {
                Console.Clear();
                rep = false;
                Console.WriteLine("INFORMACIÓN DE ALUMNOS DE LA UNIVERSIDAD CATÓLICA DE EL SALVADOR");
                Console.WriteLine("================================================================================");
                Console.WriteLine("1- Agregar Alumno");
                Console.WriteLine("2- Mostrar Alumnos");
                Console.WriteLine("3- Eliminar Alumno");
                Console.WriteLine("4- Buscar Alumno");
                Console.WriteLine("5- Vaciar Diccionario");
                Console.WriteLine("6- Salir");
                Console.WriteLine("================================================================================");
                Console.WriteLine("¿Qué opción desea realizar?");
                if (int.TryParse(Console.ReadLine(), out op) && op > 0 && op <= 6)
                {
                    Console.Clear();
                    rep = false;
                    switch (op)
                    {
                        case 1:
                            agregarAlumno();
                            break;
                        case 2:
                            mostrarAlumno();
                            break;
                        case 3:
                            eliminarAlumno();
                            break;
                        case 4:
                            buscarAlumno();
                            break;
                        case 5:
                            vaciarDic();
                            break;
                        case 6:
                            salir();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Tiene que ser un entero entre 1 y 6 :(");
                    Console.ReadKey();
                    rep = true;
                }
            } while (rep == true || op != 6);
            Console.ReadKey();
        }

        public static void agregarAlumno()
        {
            Alumno alumno = new Alumno();
            do
            {
                Console.Clear();
                rep = false;
                //REVISAR ESTO PARA QUE NO OBTENGA CARNET REPETIDO
                Console.Write("Carnet: ");
                alumno.carnet = Console.ReadLine();
                if (dicAlumno.ContainsKey(alumno.carnet))
                {
                    Console.WriteLine("Carnet no Valido, intentelo de nuevo :)");
                    Console.ReadKey();
                    rep = true;
                }
            } while (rep == true);
            Console.Write("Nombre: ");
            alumno.nombre = Console.ReadLine();
            Console.Write("Carrera: ");
            alumno.carrera = Console.ReadLine();
            Console.Write("CUM: ");
            alumno.setCum(Convert.ToDecimal(Console.ReadLine()));
            dicAlumno.Add(alumno.carnet, alumno);
            Console.WriteLine("¡Alumno agregado con exito!");
            Console.ReadKey();
        }

        public static void mostrarAlumno()
        {
            Console.WriteLine("LISTADO DE ALUMNOS ALMACENADOS");
            Console.WriteLine("================================================================================");
            Console.WriteLine();
            Console.WriteLine("{0,-12}    {1,-15}    {2,-32}    {3,-5}", "Carnet", "Nombre", "Carrera", "CUM");
            Console.WriteLine("================================================================================");
            foreach (KeyValuePair<string, Alumno> datos in dicAlumno)
            {
                Alumno alum = datos.Value;
                Console.WriteLine("{0,-12}    {1,-15}    {2,-32}    {3:N1}", alum.carnet, alum.nombre, alum.carrera, alum.getCum());
                Console.WriteLine();
            }
            Console.WriteLine("================================================================================");
            Console.ReadKey();
        }

        public static void eliminarAlumno()
        {
            Console.Write("Carnet del alumno a eliminar: ");
            string carnet = Console.ReadLine();
            if (dicAlumno.ContainsKey(carnet))
            {
                dicAlumno.Remove(carnet);
                Console.WriteLine("¡Alumno eliminado con exito!");
            }
            else
            {
                Console.WriteLine("Carnet no Valido, intentelo de nuevo :)");
            }
            Console.ReadKey();
        }

        public static void buscarAlumno()
        {
            Console.Write("Carnet del alumno a buscar: ");
            string carnet = Console.ReadLine();
            if (dicAlumno.ContainsKey(carnet))
            {
                List<Alumno> alm = new List<Alumno>();
                Console.WriteLine("Nombre: " + dicAlumno[carnet].nombre);
                Console.WriteLine("Carrera: " + dicAlumno[carnet].carrera);
                Console.WriteLine("CUM: " + dicAlumno[carnet].getCum());
            }
            else
            {
                Console.WriteLine("Carnet no Valido, intentelo de nuevo :)");
            }
            Console.ReadKey();
        }

        public static void vaciarDic()
        {
            Console.WriteLine("Se vaciará el Diccionario, presione cualquier tecla para continuar");
            Console.ReadKey();
            dicAlumno.Clear();
            Console.WriteLine("¡Diccionario vaciado con éxito!");
            Console.ReadKey();
        }

        public static void salir()
        {
            Console.WriteLine("¡Gracias por usar nuestro diccionario!");
            Console.WriteLine("**Presione cualquier tecla para salir**");
        }
    }
}
