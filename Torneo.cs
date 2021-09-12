using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTPFinal2
{
    class Torneo
    {
        //atributos
        public int contador = 0;
        int tiro, x = 1, i, cantidad;
        Competidor competidor;
        Random rdm = new Random();
        public Competidor[] vector = new Competidor[10];
        Competidor[] clone;

        //propiedad
        public int CantCompetidores
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        //metodos
        public void Asignacion(string nombre, string club, decimal edad)
        {
            competidor = new Competidor(nombre, club, edad);
            if (i < cantidad)
            {
                vector[i] = competidor;
                i++;
            }
        }

        public void SumarPuntos(int i, int tiro, int x)
        {
            vector[i].Puntaje(tiro);
            vector[i].Centro(x);

            if (i == CantCompetidores - 1 )
            {
                clone = (Competidor[])vector.Clone();
                int k, j;
                Competidor aux;
                for (k = 0; k < CantCompetidores - 1; k++)
                {
                    for (j = k + 1; j < CantCompetidores; j++)
                    {
                        if (clone[k].MostrarPuntaje < clone[j].MostrarPuntaje)
                        {
                            aux = clone[k];
                            clone[k] = clone[j];
                            clone[j] = aux;
                        }
                        else if (clone[k].MostrarPuntaje == clone[j].MostrarPuntaje)
                        {
                            if (clone[k].MostrarCentro < clone[j].MostrarCentro) // desempate
                            {
                                aux = clone[k];
                                clone[k] = clone[j];
                                clone[j] = aux;
                            }
                        }
                    }
                }
            }
        }

        public Competidor Muestra(int orden)
        {
            return clone[orden];
        }
    }
}
