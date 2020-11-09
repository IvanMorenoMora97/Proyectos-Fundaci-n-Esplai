using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagochi
{

    class Tamagochi
    {
        static int contadorTamagochi = 0;


        //Constructor del Tamagochi y la configuración de sus atributos
        public Tamagochi(string name, Tipo t, int atq, int hp, int def, int h, int c, int a, Evoluciones evo) {
            this.nombreTamagochi = name;
            this.tipo = t;
            this.ataque = atq;
            this.vida = hp;
            this.defensa = def;
            this.hambre = h;
            this.cansancio = c;
            this.aburrimiento = a;
            this.ev = evo;
        }


        internal void Comer() {
            this.hambre -= 2;
            this.cansancio += 1;
            this.aburrimiento += 1;
        }

        internal void Jugar() {
            this.hambre += 1;
            this.cansancio += 1;
            this.aburrimiento -= 2;
        }

        internal void Dormir() {
            this.hambre += 1;
            this.cansancio -= 2;
            this.aburrimiento += 1;
        }

        internal void Datos() {
            Console.WriteLine(@"Hambre: " + this.hambre
                + ", Cansancio: " + this.cansancio
                + ", Aburrimiento: " + this.aburrimiento
                + ", Tipo: " + this.tipo
                + ", Ataque: " + this.ataque
                + ", Vida: " + this.vida
                + ", Defensa: " + this.defensa
                + ", Evolucion: " + this.ev);
        }

        public string nombreTamagochi { get; set; }

        public Tipo tipo { get; set; }

        public int ataque { get; set; }

        public int vida { get; set; }

        public int defensa { get; set; }

        public int hambre { get; set; }

        public int cansancio { get; set; }

        public int aburrimiento { get; set; }

        public Evoluciones ev { get; set; }

        public enum Evoluciones
        {
            Child,
            Campeon,
            Mega,
            MegaCampeon,
            Ultimate
        }

        public enum Tipo
        {
            Agua,
            Fuego,
            Planta
        }

    }
}
