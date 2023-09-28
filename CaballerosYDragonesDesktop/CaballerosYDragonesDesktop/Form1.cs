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
using CaballerosYDragonesNivel2ClassLibrary;
using CaballerosYDragonesNivel3ClassLibrary;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace CaballerosYDragonesDesktop
{
    public partial class FormPrincipal : Form
    {
        CaballerosYDragonesBasico nuevo;

        ArrayList partidas = new ArrayList();

        int c; //columnas
        int f; //filas

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDatos fDatos = new FormDatos();

            if (fDatos.ShowDialog() == DialogResult.OK)
            {
                Iniciar();
                VisibilityChange();
                lbResultados.Items.Clear();

                string jugador = fDatos.tbNombre.Text;
                int cantidad = Convert.ToInt32(fDatos.nudCantJugadores.Value);
                int nivel = fDatos.cbNivel.SelectedIndex + 1;

                if (nivel == 1)
                {
                    nuevo = new CaballerosYDragonesBasico(jugador, cantidad);
                }
                else if (nivel == 2)
                {
                    nuevo = new CaballerosYDragonesNivel2(jugador, cantidad);
                    
                }
                else if (nivel == 3)
                {
                    nuevo = new CaballerosYDragonesNivel3(jugador, cantidad);
                }

                for (int i = 1; i<=nuevo.CantidadJugadores; i++)
                {
                    if (i == 1)
                    {
                        if (nuevo is CaballerosYDragonesNivel2)
                        {
                            pbDragon1a.Visible = true;
                            pbDragon1b.Visible = true;
                        }

                    }
                    else if (i == 2)
                    {
                        pBjugador2.Visible = true;
                        if (nuevo is CaballerosYDragonesNivel2)
                            {
                                pbDragon2a.Visible = true;
                                pbDragon2b.Visible = true;
                            }
                        

                    }
                    else if (i == 3)
                    {
                        pBjugador3.Visible = true;
                        if (nuevo is CaballerosYDragonesNivel2)
                        {
                            pbDragon3a.Visible = true;
                            pbDragon3b.Visible = true;
                        }

                    }
                }
                if (nuevo is CaballerosYDragonesNivel3)
                {
                    
                    pbCalabozo1.Visible = true;
                    pbCalabozo2.Visible = true;
                    pbCalabozo3.Visible = true;

                    ArrayList ListaCalabozos = ((CaballerosYDragonesNivel3)nuevo).Calabozos;

                    for (int i =  0; i < ListaCalabozos.Count; i++)
                    {
                        if (i == 0)
                        {
                            pbCalabozo1.Left = 25 + ((((Calabozos)ListaCalabozos[i]).PosicionActual % 10) * 90);
                            pbCalabozo1.Top = 45 + ((((Calabozos)ListaCalabozos[i]).PosicionActual / 10) * 90);
                        }
                        if (i == 1)
                        {
                            pbCalabozo2.Left = 25 + ((((Calabozos)ListaCalabozos[i]).PosicionActual % 10) * 90);
                            pbCalabozo2.Top = 45 + ((((Calabozos)ListaCalabozos[i]).PosicionActual / 10) * 90);

                        }
                        if (i == 2)
                        {
                            pbCalabozo3.Left = 25 + ((((Calabozos)ListaCalabozos[i]).PosicionActual % 10) * 90);
                            pbCalabozo3.Top = 45 + ((((Calabozos)ListaCalabozos[i]).PosicionActual / 10) * 90);
                        }

                        
                    }
                }

                //if (nuevo is CaballerosYDragonesNivel2 nivel2)
                //{
                //    for(int m = 0; m < nivel2.CantidadElementos; m++)
                //    {
                //        Elemento elemento = nivel2.VerElemento(m);
                //        string linea = $"   {elemento.VerDescripcion()} ";

                //        lbResultados.Items.Add(linea);
                //        lbResultados.SelectedIndex = lbResultados.Items.Count - 1;
                //    }
                //}

                lbResultados.Items.Add("---");

                btnJugar.Enabled = true;
                
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            //(nuevo.HaFinalizado() == false)   && (((CaballerosYDragonesNivel3)nuevo).EvaluarGanador() == null)
            //(nuevo.HaFinalizado() == false) || ((nuevo is CaballerosYDragonesNivel3) && (((CaballerosYDragonesNivel3)nuevo).EvaluarGanador() == null))
            if ((nuevo.HaFinalizado() == false) && (!(nuevo is CaballerosYDragonesNivel3) || (((CaballerosYDragonesNivel3)nuevo).EvaluarGanador() == null)))
            {

                nuevo.Jugar();
                
                if (nuevo is CaballerosYDragonesNivel2 nivel2)
                {
                    nivel2.EvaluarJuego();
                    
                }
                else if (nuevo is CaballerosYDragonesNivel3 nivel3)
                {
                    nivel3.EvaluarJuego();
                    
                }

                for (int n = 0; n < nuevo.CantidadJugadores; n++)
                {
                    Jugador jugador = nuevo.VerJugador(n);
                    c = (jugador.PosicionActual % 10) * 90;
                    f = (jugador.PosicionActual / 10) * 90;

                    string linea;

                   

                    linea = $">{jugador.Nombre} se movió desde la posición: {jugador.PosicionAnterior}" +
                                    $"a la posición {jugador.PosicionActual} ({jugador.Avance})";

                    lbResultados.Items.Add(linea);
                    lbResultados.SelectedIndex = lbResultados.Items.Count - 1;

                    if (n == 0)
                    {
                        
                        pBjugador1.Left = 2 + c;
                        pBjugador1.Top = 45 + f;

                        

                    }
                    else if(n == 1)
                    {

                        pBjugador2.Left = 50 + c;
                        pBjugador2.Top = 45 + f;

                    }
                    else if(n == 2)
                    {
                        
                        pBjugador3.Left = 35 + c;
                        pBjugador3.Top = 12 + f;
                    }

                    if (nuevo is CaballerosYDragonesNivel2)
                    {
                        if (jugador is JugadorNivel2 jugadornivel2)
                        {
                            foreach (Dragon elemento in ((CaballerosYDragonesNivel2)nuevo).Elementos)
                            {
                                
                                c = (elemento.PosicionActual % 10) * 90;
                                f = (elemento.PosicionActual / 10) * 90;

                                if (jugadornivel2.Id == elemento.IdJugador)
                                {
                                    if (n == 0)
                                    {
                                        if (elemento.ImagenId == 0)
                                        {
                                            pbDragon1a.Left = 50 + c;
                                            pbDragon1a.Top = 45 + f;

                                        }

                                        else if (elemento.ImagenId == 1)
                                        {
                                            pbDragon1b.Left = 50 + c;
                                            pbDragon1b.Top = 45 + f;
                                        }
                                       

                                    }
                                    else if (n == 1)
                                    {
                                        if (elemento.ImagenId == 2)
                                        {
                                            pbDragon2a.Left = 2 + c;
                                            pbDragon2a.Top = 45 + f;
                                        }
                                        else if (elemento.ImagenId == 3)
                                        {
                                            pbDragon2b.Left = 2 + c;
                                            pbDragon2b.Top = 45 + f;
                                        }
                                        

                                    }
                                    else if (n == 2)
                                    {
                                        if (elemento.ImagenId == 4)
                                        {
                                            
                                            pbDragon3a.Left = 35 + c;
                                            pbDragon3a.Top = 0 + f;
                                        }
                                        else if (elemento.ImagenId == 5)
                                        {
                                            pbDragon3b.Left = 35 + c;
                                            pbDragon3b.Top = 0 + f;
                                        }
                                        

                                    }
                                }
                            }
                        }
                    }

                    if (jugador is JugadorNivel2 legacy)
                    {
                        for(int m = 0; m <legacy.CantidadAfectadores; m++)
                        {
                            Elemento quien = legacy.VerPorQuien(m);
                            
                            linea = $"   Afectado por: {quien.VerDescripcion()} ";
                            

                            lbResultados.Items.Add(linea);
                            lbResultados.SelectedIndex = lbResultados.Items.Count - 1;
                        }
                    }

                }

                lbResultados.Items.Add("------");
                if (nuevo is CaballerosYDragonesNivel2)
                {
                    foreach (Elemento elemento in ((CaballerosYDragonesNivel2)nuevo).Elementos)
                    {
                        if (elemento is Dragon)
                        {
                            lbResultados.Items.Add("Dragon: " + ((Dragon)elemento).IdJugador + "---" + " Posicion Anterior: " + ((Dragon)elemento).PosicionAnterior + "---" + " Posicion Actual: " + ((Dragon)elemento).PosicionActual);
                            lbResultados.SelectedIndex = lbResultados.Items.Count - 1;
                        }

                    }
                }

                if (nuevo is CaballerosYDragonesNivel3)
                {
                    foreach (Calabozos calabozo in ((CaballerosYDragonesNivel3)nuevo).Calabozos)
                    {
                        if (calabozo is Calabozos)
                        {
                            lbResultados.Items.Add("Calabozo -- Posicion Actual: " + ((Calabozos)calabozo).PosicionActual);
                            lbResultados.SelectedIndex = lbResultados.Items.Count - 1;
                        }

                    }

                    
                }

                //if (nuevo is CaballerosYDragonesNivel3 nivel4)
                //{
                //    for (int m = 0; m < nivel4.CantidadElementos; m++)
                //    {
                //        Jugador jugador = nuevo.VerJugador(m);

                //        if (jugador is JugadorNivel3)
                //        {
                //            if (((JugadorNivel3)jugador).HaPerdido)
                //            {
                //                MessageBox.Show("Jugador perdedor: " + nivel4.Perdedor.Nombre);
                //            }
                //        }
                //    }
                //}



            }
            else
            {
                MessageBox.Show("Finalizó!");

                

                

                for (int n = 0; n < nuevo.CantidadJugadores; n++)
                {
                    Jugador jug = nuevo.VerJugador(n);
                    if (jug.HaLLegado)
                    {
                        AgregarPartida(jug.Nombre);
                    }
                }
                if ((nuevo is CaballerosYDragonesNivel3))
                {
                    if (((CaballerosYDragonesNivel3)nuevo).EvaluarGanador() != null)
                    {
                        Jugador jug = ((CaballerosYDragonesNivel3)nuevo).EvaluarGanador();
                        AgregarPartida(jug.Nombre);
                        MessageBox.Show("Ganador del nivel 3: " + jug.Nombre+ ". Los demás fueron comidos");
                    }
                }
                
                btnJugar.Enabled = false;
                Iniciar();
                VisibilityChange();
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

        private void btnDemo_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            int nivel;
            for (nivel = 1; nivel < 4; nivel++)
            {
                switch (nivel)
                {
                    case 1:
                        lbResultados.Items.Add("=======nivel 1========");
                        nuevo = new CaballerosYDragonesBasico("Pablo", 2);
                        break;
                    case 2:
                        lbResultados.Items.Add("=======nivel 2========");
                        nuevo = new CaballerosYDragonesNivel2("Pablo", 2);
                        break;
                    case 3:
                        lbResultados.Items.Add("=======nivel 3========");
                        nuevo = new CaballerosYDragonesNivel3("Pablo", 2);
                        break;
                }

                while ((nuevo.HaFinalizado() == false) && (!(nuevo is CaballerosYDragonesNivel3) || (((CaballerosYDragonesNivel3)nuevo).EvaluarGanador() == null)))
                {
                    nuevo.Jugar();

                    if (nuevo is CaballerosYDragonesNivel2 nivel2)
                    {
                        nivel2.EvaluarJuego();
                    }
                    else if (nuevo is CaballerosYDragonesNivel3 nivel3)
                    {
                        nivel3.EvaluarJuego();

                    }

                    for (int n = 0; n < nuevo.CantidadJugadores; n++)
                    {
                        Jugador jugador = nuevo.VerJugador(n);

                        string linea;



                        linea = $">{jugador.Nombre} se movió desde la posición: {jugador.PosicionAnterior}" +
                                        $"a la posición {jugador.PosicionActual} ({jugador.Avance})";

                        lbResultados.Items.Add(linea);
                        lbResultados.SelectedIndex = lbResultados.Items.Count - 1;

                        if (jugador is JugadorNivel2 legacy)
                        {
                            for (int m = 0; m < legacy.CantidadAfectadores; m++)
                            {
                                Elemento quien = legacy.VerPorQuien(m);

                                linea = $"   Afectado por: {quien.VerDescripcion()} ";


                                lbResultados.Items.Add(linea);
                                lbResultados.SelectedIndex = lbResultados.Items.Count - 1;
                            }
                        }

                    }

                    lbResultados.Items.Add("------");
                    if (nuevo is CaballerosYDragonesNivel2)
                    {
                        foreach (Elemento elemento in ((CaballerosYDragonesNivel2)nuevo).Elementos)
                        {
                            if (elemento is Dragon)
                            {
                                lbResultados.Items.Add("Dragon: " + ((Dragon)elemento).IdJugador + "---" + " Posicion Anterior: " + ((Dragon)elemento).PosicionAnterior + "---" + " Posicion Actual: " + ((Dragon)elemento).PosicionActual);
                            }

                        }
                    }

                    if (nuevo is CaballerosYDragonesNivel3)
                    {
                        foreach (Calabozos calabozo in ((CaballerosYDragonesNivel3)nuevo).Calabozos)
                        {
                            if (calabozo is Calabozos)
                            {
                                lbResultados.Items.Add("Calabozo -- Posicion Actual: " + ((Calabozos)calabozo).PosicionActual);
                                lbResultados.SelectedIndex = lbResultados.Items.Count - 1;
                            }

                        }


                    }
                }
                MessageBox.Show("Finalizó!");

                for (int n = 0; n < nuevo.CantidadJugadores; n++)
                {
                    Jugador jug = nuevo.VerJugador(n);
                    if (jug.HaLLegado)
                    {
                        AgregarPartida(jug.Nombre);
                    }
                }
                if ((nuevo is CaballerosYDragonesNivel3))
                {
                    if (((CaballerosYDragonesNivel3)nuevo).EvaluarGanador() != null)
                    {
                        Jugador jug = ((CaballerosYDragonesNivel3)nuevo).EvaluarGanador();
                        AgregarPartida(jug.Nombre);
                        MessageBox.Show(jug.Nombre);
                    }
                }

                btnJugar.Enabled = false;
                Iniciar();
                VisibilityChange();
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FSplash fSplash = new FSplash(5);
            fSplash.ShowDialog();

            pBtablero.Controls.Add(pBjugador1);
            pBtablero.Controls.Add(pBjugador2);
            pBtablero.Controls.Add(pBjugador3);

            pBtablero.Controls.Add(pbDragon1a);
            pBtablero.Controls.Add(pbDragon1b);

            pBtablero.Controls.Add(pbDragon2a);
            pBtablero.Controls.Add(pbDragon2b);

            pBtablero.Controls.Add(pbDragon3a);
            pBtablero.Controls.Add(pbDragon3b);

            

        }

        public void Iniciar()
        {

            pBjugador1.Left = 5;
            pBjugador1.Top = 45;
            pBjugador2.Left = 50;
            pBjugador2.Top = 45;
            pBjugador3.Left = 35;//35; 12
            pBjugador3.Top = 12;
            pbDragon1a.Left = 1149; //1149; 45
            pbDragon1a.Top = 45;
            pbDragon1b.Left = 785;  //785; 285
            pbDragon1b.Top = 285;
            pbDragon2a.Left = 603; //603; 519
            pbDragon2a.Top = 519;
            pbDragon2b.Left = 363;//363; 285
            pbDragon2b.Top = 285;
            pbDragon3a.Left = 155; //155; 363
            pbDragon3a.Top = 363;
            pbDragon3b.Left = 1001; //1001; 482
            pbDragon3b.Top = 482;
            pbCalabozo1.Left = 734;
            pbCalabozo1.Top = 188;
            pbCalabozo2.Left = 603;
            pbCalabozo2.Top = 428;
            pbCalabozo3.Left = 1084;
            pbCalabozo3.Top = 428;
        }

        public void VisibilityChange()
        {
            
           
            pBjugador2.Visible = false;
            
            pBjugador3.Visible = false;//35; 12
            
            pbDragon1a.Visible = false; //1149; 45
            
            pbDragon1b.Visible = false;  //785; 285
            
            pbDragon2a.Visible = false; //603; 519
            
            pbDragon2b.Visible = false;//363; 285
            
            pbDragon3a.Visible = false; //155; 363
            
            pbDragon3b.Visible = false; //1001; 482
            
            pbCalabozo1.Visible = false;
            
            pbCalabozo2.Visible = false;
            
            pbCalabozo3.Visible = false;
            
        }
    }
}
