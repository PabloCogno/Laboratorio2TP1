using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaballerosYDragonesClassLibrary;
using CaballerosYDragonesNivel3ClassLibrary;


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
            ((Dragon)elementos[0]).ReiniciarContador();
        }

        public override void Jugar()
        {
            base.Jugar();

            foreach (JugadorNivel2 jugador in jugadores)
            {
                // Verificar si el jugador ha perdido
                if (!jugador.HaPerdido)
                {
                    // Obtener los dragones del jugador actual
                    foreach (Dragon dragon in elementos)
                    {
                        // Verificar si el dragón pertenece al jugador actual
                        if (dragon.IdJugador == jugador.Id)
                        {
                            // Mover el dragón
                            dragon.Mover();
                        }
                    }
                }
            }

            //foreach (Elemento elemento in elementos)
            //{
            //    if (elemento is Dragon dragon)
            //    {
            //        dragon.Mover();
            //    }

            //}


        }

        virtual public void EvaluarJuego()
        {
            foreach (JugadorNivel2 jugador in jugadores)
            {
                if (jugador.HaPerdido == false)
                {
                    foreach (Elemento elemento in elementos)
                    {
                        if (((Dragon)elemento).HaPerdido == false)
                        {
                            if (!(jugador is JugadorNivel3 jugadorNivel3) || !jugadorNivel3.TurnoSuspendido)
                            {
                                elemento.Evaluar(jugador);
                            }

                            //elemento.Evaluar(jugador);
                        }
                    }
                }
                
            }
        }

        public Elemento VerElemento(int index)
        {
            return (Elemento)elementos[index];
        }


    }
}
