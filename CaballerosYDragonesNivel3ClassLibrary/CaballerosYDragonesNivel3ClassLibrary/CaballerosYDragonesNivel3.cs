using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaballerosYDragonesClassLibrary;
using CaballerosYDragonesNivel2ClassLibrary;

namespace CaballerosYDragonesNivel3ClassLibrary
{
    public class CaballerosYDragonesNivel3: CaballerosYDragonesNivel2
    {
        

        //protected ArrayList perdedores = new ArrayList();

        

        //public ArrayList Perdedores { get { return perdedores; } }


        public bool PropJuegoFinalizado { get { return juegoFinalizado; } }



        bool juegoFinalizado = false;

        

        protected ArrayList calabozos = new ArrayList();

        public ArrayList Calabozos { get { return calabozos; } }

        public CaballerosYDragonesNivel3(string nombre, int cantJugadores) : base(nombre, cantJugadores)
        {

        }

        override protected void InicializarTablero(string nombre, int cantJugadores)
        {
            jugadores.Add(new JugadorNivel3(nombre));

            for (int n = 2; n <= cantJugadores; n++)
            {
                jugadores.Add(new JugadorNivel3("Máquina " + n));
            }

            for (int i = 0; i < cantJugadores; i++)
            {
                elementos.Add(new Dragon(((JugadorNivel2)jugadores[i]).Id));
                elementos.Add(new Dragon(((JugadorNivel2)jugadores[i]).Id));
            }

            calabozos.Add(new Calabozos());
            calabozos.Add(new Calabozos());
            calabozos.Add(new Calabozos());
        }

        public override void Jugar()
        {
            
            base.Jugar();


            //((Calabozos)calabozos[0]).PosicionActual = ((JugadorNivel3)jugadores[0]).PosicionActual;
            //((Dragon)elementos[3]).PosicionActual = ((JugadorNivel3)jugadores[0]).PosicionActual;
            //OJO CON ESTO PARA PROBAR CONTUNIAR JUEGO!!!!
            //((Calabozos)calabozos[0]).PosicionActual = ((JugadorNivel3)jugadores[0]).PosicionActual;
            //((Dragon)elementos[0]).PosicionActual = ((JugadorNivel3)jugadores[0]).PosicionActual;
            //OJO CON ESTO
        }

        public void AgregarPerdedor(JugadorNivel2 jugador)
        {
            jugador.HaPerdido = true;
            //perdedores.Add(jugador);
            
            juegoFinalizado = true;
            jugador.Perdedor = jugador;

            foreach (Dragon elemento in elementos)
            {
                if (jugador.Id == elemento.IdJugador)
                {
                    elemento.HaPerdido = true;
                }
            }


        }

        override public void EvaluarJuego()
        {
            bool hayDragon = false;

            foreach (JugadorNivel3 jugador in jugadores)
            {
                if (jugador.HaPerdido == false)
                {
                    foreach (Calabozos calabozo in calabozos)
                    {
                        if (jugador.PosicionActual == calabozo.PosicionActual)
                        {
                            foreach (Dragon dragon in elementos)
                            {
                                if (dragon.HaPerdido == false)
                                {
                                    if (dragon.PosicionActual == calabozo.PosicionActual)
                                    {
                                        hayDragon = true;
                                        if (dragon.IdJugador != jugador.Id)
                                        {
                                            AgregarPerdedor(jugador);


                                        }
                                        
                                    }
                                }
                                

                            }
                            if (hayDragon == false)
                            {
                                calabozo.Evaluar(jugador);
                            }

                        }

                    }
                }


            }
            base.EvaluarJuego();




        }


        public Jugador EvaluarGanador()
        {
            int jugadoresNoPerdieron = 0;
            JugadorNivel2 posibleGanador = null;

            foreach (JugadorNivel2 jugador in jugadores)
            {
                if (!jugador.HaPerdido)
                {
                    jugadoresNoPerdieron++;
                    posibleGanador = jugador;
                }
            }

            if (jugadoresNoPerdieron == 1)
            {
                return posibleGanador; // Si solo queda un jugador que no ha perdido, ese es el ganador
            }
            else
            {
                return null; // No hay un ganador aún
            }
        }


        
    }

}

