using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTPFinal2
{
    class Competidor
    {
        string nombre, club;
        decimal edad;
        int puntaje, centro;

        //constructor
        public Competidor(string nombre, string club, decimal edad)
        {
            this.nombre = nombre;
            this.club = club;
            this.edad = edad;
        }

        //propiedades
        public string Nombre
        {
            get { return nombre; }
        }
        public decimal Edad
        {
            get { return edad; }
        }
        public string Club
        {
            get { return club; }
        }
        public int MostrarPuntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }
        public int MostrarCentro
        {
            get { return centro; }
            set { centro = value; }
        }
        //metodos
        public void Puntaje(int puntos)
        {
            puntaje += puntos;
        }

        public void Centro(int x)
        {
            centro += x;
        }
    }
}
