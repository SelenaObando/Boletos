using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio;
using CapaEntidades;

namespace capaPresentacionWF
{
    public partial class fRuta : Form
    {
        logicaNegocioRuta logicaNR = new logicaNegocioRuta();
        public fRuta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Ruta> listaRuta = logicaNR.BuscarRuta(textBoxBuscar.Text);
            dataGridViewRuta.DataSource = listaRuta;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Ruta objetoRuta = new Ruta();
                    objetoRuta.NombreR = textBoxNRuta.Text;
                    objetoRuta.Cant_asientos = Convert.ToInt32(textBoxCAsientos.Text);
                    objetoRuta.Hora_origen1 = Convert.ToDateTime(textBoxHorigen1.Text);
                    objetoRuta.Hora_destino1 = Convert.ToDateTime(textBoxHDestino1.Text);
                    objetoRuta.Hora_origen2 = Convert.ToDateTime(textBoxHOrigen2.Text);
                    objetoRuta.Hora_origen2 = Convert.ToDateTime(textBoxHOrigen2.Text);
                    objetoRuta.Idpropietario = Convert.ToInt32(textBoxIdPropietario.Text);

                    if (logicaNR.insertarRuta(objetoRuta) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewRuta.DataSource = logicaNR.listarRuta();
                        textBoxNRuta.Text = "";
                        textBoxCAsientos.Text = "";
                        textBoxHorigen1.Text = "";
                        textBoxHDestino1.Text = "";
                        textBoxHOrigen2.Text = "";
                        textBoxHDestino2.Text = "";
                        textBoxIdPropietario.Text = "";
                        tabRecursos.SelectedTab = tabPage2;
                    }
                    else
                    { MessageBox.Show("Error al agregar Ruta"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Ruta objetoRuta = new Ruta();
                    objetoRuta.Idruta = Convert.ToInt32(textBoxId.Text);
                    objetoRuta.NombreR = textBoxNRuta.Text;
                    objetoRuta.Cant_asientos = Convert.ToInt32(textBoxCAsientos);
                    objetoRuta.Hora_origen1 = Convert.ToDateTime(textBoxHorigen1);
                    objetoRuta.Hora_destino1 = Convert.ToDateTime(textBoxHDestino1);
                    objetoRuta.Hora_origen2 = Convert.ToDateTime(textBoxHOrigen2);
                    objetoRuta.Hora_destino2 = Convert.ToDateTime(textBoxHDestino2);
                    objetoRuta.Idpropietario = Convert.ToInt32(textBoxIdPropietario.Text);

                    if (logicaNR.EditarRuta(objetoRuta) > 0)
                    {
                        MessageBox.Show("actualizado con éxito");
                        dataGridViewRuta.DataSource = logicaNR.listarRuta();
                        textBoxNRuta.Text = "";
                        textBoxCAsientos.Text = "";
                        textBoxHorigen1.Text = "";
                        textBoxHDestino1.Text = "";
                        textBoxHOrigen2.Text = "";
                        textBoxHDestino2.Text = "";
                        textBoxIdPropietario.Text = "";
                        tabRecursos.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Recursos");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void fRuta_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelId.Visible = false;
            dataGridViewRuta.DataSource = logicaNR.listarRuta();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            textBoxId.Text = dataGridViewRuta.CurrentRow.Cells["Idruta"].Value.ToString();
            textBoxNRuta.Text = dataGridViewRuta.CurrentRow.Cells["NombreR"].Value.ToString();
            textBoxCAsientos.Text = dataGridViewRuta.CurrentRow.Cells["Cant_asientos"].Value.ToString();
            textBoxHorigen1.Text = dataGridViewRuta.CurrentRow.Cells["Hora_origen1"].Value.ToString();
            textBoxHorigen1.Text = dataGridViewRuta.CurrentRow.Cells["Hora_destino1"].Value.ToString();
            textBoxHorigen1.Text = dataGridViewRuta.CurrentRow.Cells["Hora_origen2"].Value.ToString();
            textBoxHorigen1.Text = dataGridViewRuta.CurrentRow.Cells["Hora_destino2"].Value.ToString();
            textBoxIdPropietario.Text = dataGridViewRuta.CurrentRow.Cells["Idpropietario"].Value.ToString();

            tabRecursos.SelectedTab = tabPage1;
            buttonGuardar.Text = "actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int codigR = Convert.ToInt32(dataGridViewRuta.CurrentRow.Cells["Idruta"].Value.ToString());
            try
            {
                if (logicaNR.EliminarRuta(codigR) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewRuta.DataSource = logicaNR.listarRuta();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al eliminar ruta");
            }
        }



    }
}

