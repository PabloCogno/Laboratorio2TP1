using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaballerosYDragonesClassLibrary;
using CaballerosYDragonesNivel2ClassLibrary;

namespace CaballerosYDragonesNivel3ClassLibrary
{
    public class Calabozos: Elemento
    {
        string descripcion = "";
        public int PosicionActual { get;  set; }

        public static int contador = 0;

        public Calabozos()
        {
            this.PosicionActual = Dado.Next(2, 48);
        }

       

        public override void Evaluar(JugadorNivel2 jugador)
        {
            contador++;
            if (jugador.PosicionActual == PosicionActual)
            {

                if (jugador is JugadorNivel3 nivel3)
                {


                    if (nivel3.TurnoSuspendido == false && nivel3.porQuienesFueAfectado.Contains(this) == false)
                    {

                        nivel3.TurnoSuspendido = true;
                        nivel3.AgregarAfectador(this);

                        
                        descripcion = $"Calabozo: Posicion Actual:{PosicionActual} --- Cayo en calabozo ---";
                    }
                    else if (nivel3.TurnoSuspendido == true && nivel3.porQuienesFueAfectado.Contains(this) == true)
                    {

                        nivel3.TurnoSuspendido = false;
                        
                        descripcion = $"Calabozo: Posicion Actual:{PosicionActual} --- Turno Suspendido ---";
                    }
                    


                }

            
            }
            
        }

        

        public override string VerDescripcion()
        {
            //descripcion = $"Calabozo: Posicion Actual:{PosicionActual}";
            return descripcion;
        }

    }
}
