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
    public partial class fCompra_Boletos : Form
    {
        logicaNegocioCompra_boleto logicaNCB = new logicaNegocioCompra_boleto();
        logicaNegocioRuta logicaRT = new logicaNegocioRuta();

        public fCompra_Boletos()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Compra_boleto objetoCompraBoleto = new Compra_boleto();
                    objetoCompraBoleto.Nmero_asiento = Convert.ToInt32(textBoxNumeroAsiento.Text);
                    objetoCompraBoleto.Precio = Convert.ToInt32(textBoxPrecio.Text);
                    objetoCompraBoleto.Fecha = textBoxFecha.Text;
                    objetoCompraBoleto.Idruta = Convert.ToInt32(comboBoxIdRuta.SelectedValue.ToString());

                    if (logicaNCB.insertarCompra_boleto(objetoCompraBoleto) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewCompraBoleto.DataSource = logicaNCB.listarCompra_boleto();
                        textBoxNumeroAsiento.Text = "";
                        textBoxPrecio.Text = "";
                        textBoxFecha.Text = "";
                        comboBoxIdRuta.Text = "";
                        tabCompraBoleto.SelectedTab = tabPage2;
                    }
                    else
                    { MessageBox.Show("Error al agregar Compra de Boleto"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Compra_boleto objetoCompraBoleto = new Compra_boleto();
                    objetoCompraBoleto.Idboleto = Convert.ToInt32(textBoxId.Text);
                    objetoCompraBoleto.Nmero_asiento = Convert.ToInt32(textBoxNumeroAsiento.Text);
                    objetoCompraBoleto.Precio = Convert.ToInt32(textBoxPrecio.Text);
                    objetoCompraBoleto.Fecha = textBoxFecha.Text;
                    objetoCompraBoleto.Idruta = Convert.ToInt32(comboBoxIdRuta.Text);

                    if (logicaNCB.EditarCompra_boleto(objetoCompraBoleto) > 0)
                    {
                        MessageBox.Show("actualizado con éxito");
                        dataGridViewCompraBoleto.DataSource = logicaNCB.listarCompra_boleto();
                        textBoxNumeroAsiento.Text = "";
                        textBoxPrecio.Text = "";
                        textBoxFecha.Text = "";
                        comboBoxIdRuta.Text = "";
                        tabCompraBoleto.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Compra de Boleto");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void fCompra_Boletos_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelId.Visible = false;

            var datos = logicaRT.listarRuta();
            comboBoxIdRuta.DataSource = (
                from rutas in datos
                select new
                {
                    rutas.Idruta,
                    nombreruta = rutas.NombreR
                }
            ).ToList();

            comboBoxIdRuta.ValueMember = "Idruta";
            comboBoxIdRuta.DisplayMember = "nombreruta";

            dataGridViewCompraBoleto.DataSource = logicaNCB.listarCompra_boleto();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;
            comboBoxIdRuta.Visible = true;
            comboBoxIdRuta.Enabled = false;
            labelIdRuta.Visible = true;

            textBoxId.Text = dataGridViewCompraBoleto.CurrentRow.Cells["Idboleto"].Value.ToString();
            textBoxNumeroAsiento.Text = dataGridViewCompraBoleto.CurrentRow.Cells["Nmero_asiento"].Value.ToString();
            textBoxPrecio.Text = dataGridViewCompraBoleto.CurrentRow.Cells["Precio"].Value.ToString();
            textBoxFecha.Text = dataGridViewCompraBoleto.CurrentRow.Cells["Fecha"].Value.ToString();
            comboBoxIdRuta.Text = dataGridViewCompraBoleto.CurrentRow.Cells["Idruta"].Value.ToString();

            tabCompraBoleto.SelectedTab = tabPage1;
            buttonGuardar.Text = "actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int codigCB = Convert.ToInt32(dataGridViewCompraBoleto.CurrentRow.Cells["Idboleto"].Value.ToString());
            try
            {
                if (logicaNCB.EliminarCompra_boleto(codigCB) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewCompraBoleto.DataSource = logicaNCB.listarCompra_boleto();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al eliminar Compra de Boleto");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            List<Compra_boleto> listaCompraBoleto = logicaNCB.BuscarCompra_boleto(textBoxBuscar.Text);
            dataGridViewCompraBoleto.DataSource = listaCompraBoleto;
        }

    }
}
