using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaballerosYDragonesClassLibrary;

namespace CaballerosYDragonesNivel2ClassLibrary
{
    public class CaballerosYDragonesNivel2: CaballerosYDragonesBasico
    {
        protected ArrayList elementos = new ArrayList();

        public int CantidadElementos
        {
            get { return elementos.Count;}
        }

        public ArrayList Elementos { get { return elementos; } }

        public CaballerosYDragonesNivel2(string nombre, int cantJugadores) : base(nombre, cantJugadores)
        {

        }

        protected override void InicializarTablero(string nombre, int cantJugadores)
        {
            //base.InicializarTablero(nombre, cantJugadores);
            jugadores.Add(new JugadorNivel2(nombre));

            for(int n = 2; n <= cantJugadores; n++)
            {
                jugadores.Add(new JugadorNivel2("Máquina " + n));

            }

            for(int i = 0; i< cantJugadores; i++)
            {
                elementos.Add(new Dragon(((JugadorNivel2)jugadores[i]).Id));
                elementos.Add(new Dragon(((JugadorNivel2)jugadores[i]).Id));
            }
        }

        public override void Jugar()
        {
            base.Jugar();

            foreach (Dragon elemento in elementos)
            {
                if (elemento is Dragon dragon)
                {
                    dragon.Mover();
                }
                
            }

            foreach (JugadorNivel2 jugador in jugadores)
            {
                foreach (Elemento elemento in elementos)
                {
                   
                    elemento.Evaluar(jugador);
                }
            }
        }

        public Elemento VerElemento(int index)
        {
            return (Elemento)elementos[index];
        }


    }
}
