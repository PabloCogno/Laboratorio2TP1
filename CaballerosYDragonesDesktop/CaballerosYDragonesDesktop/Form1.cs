using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using CaballerosYDragonesClassLibrary;
using System.Security.Cryptography.X509Certificates;

namespace CaballerosYDragonesDesktop
{
    public partial class FormPrincipal : Form
    {
        CaballerosYDragonesBasico nuevo;

        ArrayList partidas = new ArrayList();
        
        
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDatos fDatos = new FormDatos();

            if (fDatos.ShowDialog() == DialogResult.OK)
            {
                
                lbResultados.Items.Clear();

                string jugador = fDatos.tbNombre.Text;
                int cantidad = Convert.ToInt32(fDatos.nudCantJugadores.Value);
                int nivel = fDatos.cbNivel.SelectedIndex + 1;

                if (nivel == 1)
                {
                    nuevo = new CaballerosYDragonesBasico(jugador, cantidad);
                }

                lbResultados.Items.Add("---");

                btnJugar.Enabled = true;
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (nuevo.HaFinalizado() == false)
            {
                nuevo.Jugar();

                for(int n = 0; n < nuevo.CantidadJugadores; n++)
                {
                    Jugador jugador = nuevo.VerJugador(n);

                    string linea = $">{jugador.Nombre} se movió desde la posición: {jugador.PosicionAnterior}" +
                                    $"a la posición {jugador.PosicionActual} ({jugador.Avance})";

                    lbResultados.Items.Add(linea);
                    lbResultados.SelectedIndex = lbResultados.Items.Count - 1; ;

                }

                lbResultados.Items.Add("------");
            }
            else
            {
                MessageBox.Show("Finalizó!");

                for(int n = 0; n < nuevo.CantidadJugadores; n++)
                {
                    Jugador jug = nuevo.VerJugador(n);
                    if (jug.HaLLegado)
                    {
                        AgregarPartida(jug.Nombre);
                    }
                }
                btnJugar.Enabled = false;
            }
        }

        public ArrayList ListarPartidasOrdenadas()
        {
            for(int n = 0; n < partidas.Count-1; n++)
            {
                for(int m = n + 1; m < partidas.Count; m++)
                {
                    Partida p = (Partida)partidas[n];
                    Partida q = (Partida)partidas[m];

                    if (p.Ganadas < q.Ganadas)
                    {
                        object aux = partidas[n];
                        partidas[n] = partidas[m];
                        partidas[m] = aux;

                    }
                }
            }
            return partidas;
        }

        public void AgregarPartida(string nombre)
        {
            #region buscar el registro primero!
            Partida buscado = null;
            for (int n = 0; n < partidas.Count && buscado == null; n++)
            {
                Partida p = (Partida)partidas[n];
                if (p.Ganador.Trim().ToUpper() == nombre.Trim().ToUpper())
                    buscado = p;
            }
            #endregion

            #region lo actualizo silo encuentro sono lo agrego 
            if (buscado != null)
                buscado.Ganadas++;
            else
                partidas.Add(new Partida(nombre, 1));
            #endregion
        }

        private void btnListarHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial fHistorial = new FormHistorial();

            foreach (Partida p in ListarPartidasOrdenadas())
            {
                fHistorial.lbHistorial.Items.Add($"{p.Ganador}  {p.Ganadas}");
                
            }
            fHistorial.ShowDialog();
            fHistorial.Dispose();
        }
    }
}
