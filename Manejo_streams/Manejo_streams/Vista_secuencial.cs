using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejo_streams
{
    class Vista_secuencial
    {
        public void imprime_lista(ListView lv, datos[] data, int tam) 
        {
            ListViewItem item;
            lv.Items.Clear();

            for (int x = 0; x < tam; x++ )
            {
                item = lv.Items.Add(data[x].nombre);
                item.SubItems.Add(data[x].direccion);
                item.SubItems.Add(data[x].telefono.ToString());
            }
        }
    }
}
