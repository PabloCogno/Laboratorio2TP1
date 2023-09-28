using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaballerosYDragonesClassLibrary;
using CaballerosYDragonesNivel2ClassLibrary;

namespace CaballerosYDragonesNivel3ClassLibrary
{
    public class JugadorNivel3: JugadorNivel2
    {
        string descripcion = "";

        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public JugadorNivel3(string nombre) : base(nombre)
        {

        }

        public bool TurnoSuspendido { get;  set ; }



        public override void Mover()
        {
            //if (TurnoSuspendido == true)
            //{

            //    TurnoSuspendido = false;

            //}
            //else
            //{

            //    base.Mover();
            //}

            if (TurnoSuspendido != true)
            {
                base.Mover();
            }

        }

        //public string VerDescripcion()
        //{
        //    return descripcion;
        //}
    }
}
