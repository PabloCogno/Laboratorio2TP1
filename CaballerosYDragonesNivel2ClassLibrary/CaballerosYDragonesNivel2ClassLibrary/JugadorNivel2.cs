﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using CaballerosYDragonesClassLibrary;

namespace CaballerosYDragonesNivel2ClassLibrary
{
    public class JugadorNivel2: Jugador
    {
        public JugadorNivel2(string nombre): base(nombre)
        {
            porQuienesFueAfectado = new ArrayList();

        }

        public ArrayList porQuienesFueAfectado
        {
            get; private set;
        }

        public int CantidadAfectadores
        {
            get
            {
                return porQuienesFueAfectado.Count;
            }
        }

        public Elemento VerPorQuien(int index)
        {
            Elemento quien = null;

            if (index >= 0 && index < porQuienesFueAfectado.Count)
            {
                quien = (Elemento)porQuienesFueAfectado[index];
            }
            return quien;

        }

        public void AgregarAfectador(Elemento e)
        {
            porQuienesFueAfectado.Add(e);
        }

        public override void Mover()
        {
            base.Mover();
            porQuienesFueAfectado = new ArrayList();
        }
    }
}
