using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Tamagochi;

namespace Tamagochi
{
    class TestTamagochi
    {
        static void Main(string[] args) {

            /*Variables para seleccionar una opción del menú*/
            int opcion = 0;
            Boolean salida = false;
            Boolean salidaWhile = false;
            Boolean seleccionado;
            Boolean seleccionadoDos;

            /*Instancias de los tamagochis*/
            /* public Tamagochi(string name, Tipo t, int atq, int hp, int def, int h, int c, int a, Evoluciones evo) {*/
            Tamagochi t1 = new Tamagochi("Agumon", Tamagochi.Tipo.Fuego, 100, 1500, 55, 3, 3, 3, Tamagochi.Evoluciones.Child);
            Tamagochi t2 = new Tamagochi("Devimon", Tamagochi.Tipo.Agua, 50, 3100, 65, 3, 3, 3, Tamagochi.Evoluciones.Child);
            Tamagochi t3 = new Tamagochi("Greymon", Tamagochi.Tipo.Planta, 95, 2700, 95, 3, 3, 3, Tamagochi.Evoluciones.Campeon);
            Tamagochi t4 = new Tamagochi("Angewomon", Tamagochi.Tipo.Planta, 100, 2000, 110, 3, 3, 3, Tamagochi.Evoluciones.Mega);
            Tamagochi t5 = new Tamagochi("Belzeemon", Tamagochi.Tipo.Fuego, 80, 2500, 105, 3, 3, 3, Tamagochi.Evoluciones.Mega);
            Tamagochi t6 = new Tamagochi("Omegamon", Tamagochi.Tipo.Agua, 700, 5000, 150, 3, 3, 3, Tamagochi.Evoluciones.Ultimate);


            List<Tamagochi> tamagochis = new List<Tamagochi>();
            tamagochis.Add(t1);
            tamagochis.Add(t2);
            tamagochis.Add(t3);
            tamagochis.Add(t4);
            tamagochis.Add(t5);
            tamagochis.Add(t6);

            /*HACER UN MINIJUEGO DE PELEAS Y EVOLUCIONES*/

            do
            {
                seleccionado = false;
                seleccionadoDos = false;
                salidaWhile = false;
                Console.WriteLine();
                Console.WriteLine("Selecciona uno de los siguientes tamagochis o introduce cualquier otro numero para salir: ");
                
                int seleccion = 0;
                int contador = 1;
                /*MOSTRAR LA LISTA DE LOS TAMAGOCHIS*/
                foreach (Tamagochi t in tamagochis) {
                    Console.WriteLine(contador + " - " + t.nombreTamagochi);
                    contador++;
                }

                //CONTROLAR QUE INTRODUZCA UN NUMERO Y NO UN CARACTER
                while (!seleccionado) {

                    try
                    {
                        seleccion = int.Parse(Console.ReadLine());
                        seleccion -= 1;
                        seleccionado = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Los caracteres no estan permitidos, por favor introduce un número valido.");
                        seleccionado = false;
                    }

                }
                
                


                if (seleccion >= 0 && seleccion <= tamagochis.Count - 1)
                {
                    while (!salidaWhile) {

                        seleccionadoDos = false;
                        Console.WriteLine();
                        Console.WriteLine("Has seleccionado el tamagochi: " + tamagochis[seleccion].nombreTamagochi);
                        Console.WriteLine();
                        Console.WriteLine("Selecciona una de las siguientes opciones: ");
                        Console.WriteLine("1) Dar de comer al tamagochi.");
                        Console.WriteLine("2) Jugar con el tamagochi.");
                        Console.WriteLine("3) Dormir al tamagochi.");
                        Console.WriteLine("Presiona cualquier otro número para seleccionar otro tamagochi.");

                        while (!seleccionadoDos) {

                            try
                            {
                                opcion = int.Parse(Console.ReadLine());
                                seleccionadoDos = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Has seleccionado un caracter, por favor selecciona un número valido.");
                            }

                        }

                        switch (opcion)
                        {

                            case 1:
                                //Dar de comer al tamagochi
                                tamagochis[seleccion].Comer();
                                //Mostrar los datos del tamagochi
                                tamagochis[seleccion].Datos();
                                break;

                            case 2:
                                //Poner a dormir al tamagochi
                                tamagochis[seleccion].Dormir();
                                //Mostrar los datos del tamagochi
                                tamagochis[seleccion].Datos();
                                break;

                            case 3:
                                //El tamagochi se pone a jugar
                                tamagochis[seleccion].Jugar();
                                //Mostrar los datos del tamagochi
                                tamagochis[seleccion].Datos();
                                break;

                            default:
                                salidaWhile = true;
                                break;

                        }

                        //Si el tamagochi llega a 5 o sobrepasa ese valor en hambre o cansancio morira y no podremos usarlo más.
                        if (tamagochis[seleccion].hambre >= 5 || tamagochis[seleccion].cansancio >= 5) {
                            //Eliminamos al tamagochi de la lista
                            tamagochis.Remove(tamagochis[seleccion]);
                            salidaWhile = true;
                        }

                        //Si el tamagochi llega a aburrimiento 1 si llegar a 5 en hambre y cansancio habremos llegado al objetivo
                        if (tamagochis[seleccion].aburrimiento <= 1 && tamagochis[seleccion].hambre < 5 || tamagochis[seleccion].aburrimiento <= 1 && tamagochis[seleccion].cansancio < 5) {

                            Console.WriteLine("Objetivo alcanzado.");
                            salidaWhile = true;
                        }

                    }

                    //Comprobamos si ya no quedan tamagochis en la lista, si es así se acabara el programa y saldra del menú
                    if (tamagochis.Count == 0) {

                        Console.WriteLine("Ya no quedan tamagochis con los que interactuar, saliendo del programa.");
                        salida = true;

                    }


                }
                else {
                    Console.WriteLine("¿Seguro que quieres salir? (\"S\" para sí y \"N\" para no.)");
                    char confirmacion = Char.Parse(Console.ReadLine());

                    if (confirmacion == 'S' || confirmacion == 's') {
                        salida = true;
                    }
                    else if (confirmacion == 'N' || confirmacion == 'n') {
                        Console.WriteLine("Redirigiendo al menú principal.");
                    }
                    else {
                        Console.WriteLine("Redirigiendo al menú principal.");
                    }

                    
                }

            } while (salida!=true);

            Console.WriteLine("Has salido del menú.");

        }

    }
}
