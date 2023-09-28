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

                        ((JugadorNivel3)jugador).Descripcion = $"Caballero: Id: {((JugadorNivel3)jugador).Id} Posicion Actual:{((JugadorNivel3)jugador).PosicionActual} ({((JugadorNivel3)jugador).Avance}) Cayo en calabozo C: {contador}";
                        descripcion = $"Calabozo: Posicion Actual:{PosicionActual} Cayo en calabozo C: {contador}";
                    }
                    else if (nivel3.TurnoSuspendido == true && nivel3.porQuienesFueAfectado.Contains(this) == true)
                    {

                        nivel3.TurnoSuspendido = false;
                        ((JugadorNivel3)jugador).Descripcion = $"Caballero: Id: {((JugadorNivel3)jugador).Id} Posicion Actual:{((JugadorNivel3)jugador).PosicionActual} ({((JugadorNivel3)jugador).Avance}) Turno Suspendido C: {contador}";
                        descripcion = $"Calabozo: Posicion Actual:{PosicionActual} --- Turno Suspendido --- C: {contador}";
                    }
                    //nivel3.TurnoSuspendido = true;


                }

            
            }
            else
            {
                //descripcion = $"Calabozo: Posicion Actual:{PosicionActual}  C: {contador}";
            }
        }

        

        public override string VerDescripcion()
        {
            //descripcion = $"Calabozo: Posicion Actual:{PosicionActual}";
            return descripcion;
        }

    }
}
