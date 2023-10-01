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
        
        public JugadorNivel3(string nombre) : base(nombre)
        {

        }

        public bool TurnoSuspendido { get;  set ; }



        public override void Mover()
        {
            

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
