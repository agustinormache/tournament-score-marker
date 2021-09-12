using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaTPFinal2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //atributos
        Torneo torneo = new Torneo();
        Form2 ventana = new Form2();
        int i = 0, puntos, r = 1, contadorX = 0;

        //botones
        private void buttonCarga_Click(object sender, EventArgs e)
        {
            torneo.Asignacion(textBoxNombre.Text, textBoxClub.Text, numericUpDownEdad.Value);
            textBoxNombre.Clear();
            textBoxClub.Clear();
            numericUpDownEdad.Value = 1;
            listBox1.Items.Add("Competidor Nº" + (i + 1)+":");
            listBox1.Items.Add("Nombre: " + torneo.vector[i].Nombre);
            listBox1.Items.Add("Club: " + torneo.vector[i].Club);
            listBox1.Items.Add("Edad: " + torneo.vector[i].Edad);
            listBox1.Items.Add("--------------------------");
            i++;
            if (i == Convert.ToInt32(numericUpDownCompetidor.Value))
            {
                groupBoxDatos.Enabled = false;
                groupBoxRondas.Enabled = true;
                i = 0;
                labelNombre.Text = torneo.vector[i].Nombre;
                labelEdad.Text = Convert.ToString(torneo.vector[i].Edad);
                labelClub.Text = torneo.vector[i].Club;
                groupBoxRondas.Text = "Ronda " + r;
            }
        }

        private void buttonCargarPuntaje_Click(object sender, EventArgs e)
        {
            if (r <= 5)
            {
                puntos = Convert.ToInt32(numericUpDownTiro1.Value) + Convert.ToInt32(numericUpDownTiro2.Value) + Convert.ToInt32(numericUpDownTiro3.Value);
                if(checkBoxX1.Checked == true)
                {
                    contadorX++;
                }
                else if (checkBoxX2.Checked == true)
                {
                    contadorX++;
                }
                else if (checkBoxX3.Checked == true)
                {
                    contadorX++;
                }
                torneo.SumarPuntos(i, puntos, contadorX);
                contadorX = 0;
                i++;

                if (i < torneo.CantCompetidores)
                {
                    labelNombre.Text = torneo.vector[i].Nombre;
                    labelEdad.Text = Convert.ToString(torneo.vector[i].Edad);
                    labelClub.Text = torneo.vector[i].Club;
                }

                if (i == torneo.CantCompetidores) // final ronda
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Posiciones - Ronda " + r + ":");
                    for (int f = 0; f < 3; f++)
                    {
                        listBox1.Items.Add("Puesto " + (f + 1) + ":" + " Nombre: " + torneo.Muestra(f).Nombre + " Puntaje: " + torneo.Muestra(f).MostrarPuntaje + " Centro: " + torneo.Muestra(f).MostrarCentro);
                    }
                    i = 0;
                    r++;
                    labelNombre.Text = torneo.vector[i].Nombre;
                    labelEdad.Text = Convert.ToString(torneo.vector[i].Edad);
                    labelClub.Text = torneo.vector[i].Club;
                }
                groupBoxRondas.Text = "Ronda " + r;
                numericUpDownTiro1.Value = 1;
                numericUpDownTiro2.Value = 1;
                numericUpDownTiro3.Value = 1;
                checkBoxX1.Enabled = false;
                checkBoxX2.Enabled = false;
                checkBoxX3.Enabled = false;
                checkBoxX1.Checked = false;
                checkBoxX2.Checked = false;
                checkBoxX3.Checked = false;
            }
            else
            {
                groupBoxRondas.Enabled = false;
                ventana.labelNombre.Text = torneo.Muestra(0).Nombre;
                ventana.labelNombre2º.Text = torneo.Muestra(1).Nombre;
                ventana.labelNombre3º.Text = torneo.Muestra(2).Nombre;
                ventana.labelClub.Text = torneo.Muestra(0).Club;
                ventana.labelClub2º.Text = torneo.Muestra(1).Club;
                ventana.labelClub3º.Text = torneo.Muestra(2).Club;
                ventana.labelPuntaje.Text = Convert.ToString(torneo.Muestra(0).MostrarPuntaje);
                ventana.labelPuntaje2º.Text = Convert.ToString(torneo.Muestra(1).MostrarPuntaje);
                ventana.labelPuntaje3º.Text = Convert.ToString(torneo.Muestra(2).MostrarPuntaje);
                ventana.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            torneo.CantCompetidores = Convert.ToInt32(numericUpDownCompetidor.Value);
            groupBoxCompetidores.Enabled = false;
            groupBoxDatos.Enabled = true;
        }
      
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDownTiro1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTiro1.Value == 10)
            {
                checkBoxX1.Enabled = true;
            }
        }

        private void numericUpDownTiro2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTiro2.Value == 10)
            {
                checkBoxX2.Enabled = true;
            }
        }

        private void numericUpDownTiro3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTiro3.Value == 10)
            {
                checkBoxX3.Enabled = true;
            }
        }
    }
}
