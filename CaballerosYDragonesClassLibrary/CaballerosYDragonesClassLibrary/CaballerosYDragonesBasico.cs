using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CaballerosYDragonesClassLibrary
{
    public class CaballerosYDragonesBasico
    {
        protected ArrayList jugadores = new ArrayList();

        public int CantidadJugadores { get { return jugadores.Count; } }

        public CaballerosYDragonesBasico(string nombre, int cantJugadores)
        {
            InicializarTablero(nombre, cantJugadores);
        }

        virtual protected void InicializarTablero(string nombre, int cantJugadores)
        {
            jugadores.Add(new Jugador(nombre));

            for(int n = 2; n <= cantJugadores; n++)
            {
                jugadores.Add(new Jugador("Máquina " + n));
            }
        }

        virtual public void Jugar()
        {
            foreach (Jugador jugador in jugadores)
            {
                jugador.Mover();
            }
        }

        public Jugador VerJugador(int index)
        {
            return (Jugador)jugadores[index];
        }

        public bool HaFinalizado()
        {
            bool haFinalizado = false;

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.HaLLegado == true)
                {
                    haFinalizado |= true;
                }
            }
            return haFinalizado;
        }
        
    }
}
