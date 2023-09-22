using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaballerosYDragonesClassLibrary
{
    public class Jugador
    {
        static int id = 0;
        static Random dado = new Random();

        public string Nombre { get; private set; }

        int posicion;
        int idJugador;

        public int PosicionActual
        {
            get { return posicion; }
            set 
            {
                if (value<=50)
                {
                    posicion = value;
                }
                else
                {
                    posicion = 50;
                }
            }
        }

        public int PosicionAnterior
        {
            get;
            private set;
        }

        public int Avance
        {
            get;
            private set;
        }

        public bool HaLLegado
        { get
            {
                return PosicionActual >= 50;
            }
        }

        public int Id { get { return idJugador; } }

        public Jugador(string nombre) 
        {
            Nombre = nombre;
            id++;
            idJugador = id;
        }

        virtual public void Mover()
        {
            Avance = dado.Next(1, 7);

            PosicionAnterior = PosicionActual;
            PosicionActual += Avance;
        }

        public void ReiniciarPosicion()
        {
            PosicionActual = 0;
        }

       
    }
}
