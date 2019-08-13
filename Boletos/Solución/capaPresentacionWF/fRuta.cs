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
using CapaDatos;

namespace capaPresentacionWF
{
    public partial class fRuta : Form
    {
        logicaNegocioRuta logicaNR = new logicaNegocioRuta();
        logicaNegocioPropietario logicaPR = new logicaNegocioPropietario();
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
                    objetoRuta.Idbus = Convert.ToInt32(textBoxIdbus.Text);
                    objetoRuta.Cant_asientos = Convert.ToInt32(textBoxCant_asientos.Text);
                    objetoRuta.Hora_origen1 = Convert.ToDateTime(dateTimePickerHoraOrigen1.Text);
                    objetoRuta.Hora_destino1 = Convert.ToDateTime(dateTimePickerHoraDestino1.Text);
                    objetoRuta.Hora_origen2 = Convert.ToDateTime(dateTimePickerHoraOrigen2.Text);
                    objetoRuta.Hora_origen2 = Convert.ToDateTime(dateTimePickerHoraOrigen2.Text);
                    objetoRuta.Idpropietario = Convert.ToInt32(comboBoxIdpropietario.Text);

                    if (logicaNR.insertarRuta(objetoRuta) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewRuta.DataSource = logicaNR.listarRuta();
                        textBoxNRuta.Text = "";
                        textBoxIdbus.Text = "";
                        textBoxCant_asientos.Text = "";
                        dateTimePickerHoraOrigen1.Text = "";
                        dateTimePickerHoraDestino1.Text = "";
                        dateTimePickerHoraOrigen2.Text = "";
                        dateTimePickerHoraDestino2.Text = "";
                        comboBoxIdpropietario.Text = "";
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
                    objetoRuta.Idbus = Convert.ToInt32(textBoxIdbus.Text);
                    objetoRuta.Cant_asientos = Convert.ToInt32(textBoxCant_asientos);
                    objetoRuta.Hora_origen1 = Convert.ToDateTime(dateTimePickerHoraOrigen1);
                    objetoRuta.Hora_destino1 = Convert.ToDateTime(dateTimePickerHoraDestino1);
                    objetoRuta.Hora_origen2 = Convert.ToDateTime(dateTimePickerHoraOrigen2);
                    objetoRuta.Hora_destino2 = Convert.ToDateTime(dateTimePickerHoraDestino2);
                    objetoRuta.Idpropietario = Convert.ToInt32(comboBoxIdpropietario.Text);

                    if (logicaNR.EditarRuta(objetoRuta) > 0)
                    {
                        MessageBox.Show("actualizado con éxito");
                        dataGridViewRuta.DataSource = logicaNR.listarRuta();
                        textBoxNRuta.Text = "";
                        textBoxIdbus.Text = "";
                        textBoxCant_asientos.Text = "";
                        dateTimePickerHoraOrigen1.Text = "";
                        dateTimePickerHoraDestino1.Text = "";
                        dateTimePickerHoraOrigen2.Text = "";
                        dateTimePickerHoraDestino2.Text = "";
                        comboBoxIdpropietario.Text = "";
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
            List<int> propietar = new List<int>();
            propietar = logicaPR.listarPropietario().Select(x => x.Idpropietario).ToList();

            comboBoxIdpropietario.DataSource = propietar;
           
            dataGridViewRuta.DataSource = logicaNR.listarRuta();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;
            comboBoxIdpropietario.Visible = true;
            comboBoxIdpropietario.Enabled = false;
            labelIdpropietario.Visible = true;

            textBoxId.Text = dataGridViewRuta.CurrentRow.Cells["Idruta"].Value.ToString();
            textBoxNRuta.Text = dataGridViewRuta.CurrentRow.Cells["NombreR"].Value.ToString();
            textBoxIdbus.Text = dataGridViewRuta.CurrentRow.Cells["Idbus"].Value.ToString();
            textBoxCant_asientos.Text = dataGridViewRuta.CurrentRow.Cells["Cant_asientos"].Value.ToString();
            dateTimePickerHoraOrigen1.Text = dataGridViewRuta.CurrentRow.Cells["Hora_origen1"].Value.ToString();
            dateTimePickerHoraDestino1.Text = dataGridViewRuta.CurrentRow.Cells["Hora_destino1"].Value.ToString();
            dateTimePickerHoraOrigen2.Text = dataGridViewRuta.CurrentRow.Cells["Hora_origen2"].Value.ToString();
            dateTimePickerHoraDestino2.Text = dataGridViewRuta.CurrentRow.Cells["Hora_destino2"].Value.ToString();
            comboBoxIdpropietario.Text = dataGridViewRuta.CurrentRow.Cells["Idpropietario"].Value.ToString();

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Ruta> listaRuta = logicaNR.BuscarRuta(textBoxBuscar.Text);
            dataGridViewRuta.DataSource = listaRuta;

        }



    }
}

