using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejo_streams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtArchivo.Text = "c:/pruebas/secuencial.txt";
        }

        Modelo_secuencial modelo = new Modelo_secuencial();
        Vista_secuencial vista = new Vista_secuencial();

        private void btnEscribir_Click(object sender, EventArgs e)
        {
            datos data = new datos();
            data.nombre = txtNombre.Text;
            data.direccion = txtDireccion.Text;
            data.telefono = Convert.ToDouble(txtTelefono.Text);
            modelo.escribir(txtArchivo.Text,data);

            MessageBox.Show("Datos escritos en el archivo!!");
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            datos[] temp = new datos[100];
            temp=modelo.leer(txtArchivo.Text);
            int tam = modelo.pos;
            vista.imprime_lista(lvPersonas,temp,tam);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        
       


    }
}
