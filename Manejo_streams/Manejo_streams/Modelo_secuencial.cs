using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Manejo_streams
{
    class datos
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public double telefono { get; set; }

        public datos()
        {
            nombre = null;
            direccion = null;
            telefono = 0;
        }

        public datos(string n, string d, double t)
        {
            nombre = null;
            direccion = null;
            telefono = 0;
        }
    }
    class Modelo_secuencial
    {
        BinaryWriter bw;
        BinaryReader br;
        FileStream fs;

        public int pos { get; set; }
        public Modelo_secuencial()
        {
            bw = null;
            br=null;
            fs = null;
        }
        public void abrir_escritura(string archivo) 
        {
            fs = new FileStream(archivo, FileMode.Append,FileAccess.Write);
            bw = new BinaryWriter(fs);
        }
        public void abrir_lectura(string archivo) 
        {
            fs = new FileStream(archivo,FileMode.Open,FileAccess.Read);
            br = new BinaryReader(fs);
        }

        public void escribir(string archivo,datos d) 
        {
            abrir_escritura(archivo);
            bw.Write(d.nombre);
            bw.Write(d.direccion);
            bw.Write(d.telefono);
            bw.Close();
        }

        public datos[] leer(string archivo) 
        {
            datos[] objeto = new datos[100];
            pos=0;
            if (bw != null) bw.Close();
            try
            {
                if (File.Exists(archivo))
                {
                    abrir_lectura(archivo);
                    do
                    {
                        objeto[pos] = new datos();
                        objeto[pos].nombre = br.ReadString();
                        objeto[pos].direccion = br.ReadString();
                        objeto[pos].telefono = br.ReadDouble();
                        pos++;
                    } while (true);
                }
                else
                    MessageBox.Show("Fin del archivo");
            }
            catch (EndOfStreamException)
            {
                MessageBox.Show("Fin del archivo");
            }
            finally 
            {
                if (br != null) br.Close();
            }
            return objeto;
        }
    }
}
