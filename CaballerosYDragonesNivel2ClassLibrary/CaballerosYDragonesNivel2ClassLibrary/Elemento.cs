using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaballerosYDragonesClassLibrary;

namespace CaballerosYDragonesNivel2ClassLibrary
{
    abstract public class Elemento
    {
        static protected Random Dado = new Random();
        abstract public void Evaluar(JugadorNivel2 jugador);
        abstract public string VerDescripcion();

    }
}
