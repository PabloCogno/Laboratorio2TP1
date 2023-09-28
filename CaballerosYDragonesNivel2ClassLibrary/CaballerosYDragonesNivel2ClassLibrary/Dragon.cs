using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaballerosYDragonesNivel2ClassLibrary
{
    public class Dragon: Elemento
    {
        public int PosicionActual { get;  set; }

        public int PosicionAnterior { get;  set; }

        public int IdJugador { get {  return idJugador; } }

        bool perdio = false;

        public bool HaPerdido
        {
            get
            { return perdio; }
            set
            { perdio = value; }

        }


        int idJugador;
        public Dragon(int id) 
        {
            idJugador = id;
        }

        public override void Evaluar(JugadorNivel2 jugador)
        {
            if (jugador.PosicionActual == PosicionActual)
            {
                if (jugador.Id == idJugador)
                {
                    jugador.PosicionActual = jugador.PosicionActual + 5;

                }
                else
                {
                    jugador.PosicionActual = jugador.PosicionActual - 5;
                }
                if (jugador is JugadorNivel2 legacy)
                {
                    legacy.AgregarAfectador(this);
                }
            }
        }

        public override string VerDescripcion()
        {
            string descripcion = "";

            descripcion = $"Dragon - Id: {idJugador}, Posicion Anterior:{PosicionAnterior} , Posicion Actual:{PosicionActual}";
            return descripcion;
        }

        public void Mover()
        {
            PosicionAnterior = PosicionActual;
            PosicionActual = Dado.Next(2, 48);

        }


    }
}
