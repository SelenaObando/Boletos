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
    public partial class fClientes : Form
    {
        logicaNegocioClientes logicaNC = new logicaNegocioClientes();
        logicaNegocioRuta logicaRT = new logicaNegocioRuta();
        logicaNegocioCompra_boleto logicaCB = new logicaNegocioCompra_boleto();

        public fClientes()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Clientes objetoClientes = new Clientes();
                    objetoClientes.Nombres = textBoxNombres.Text;
                    objetoClientes.Apellidos = textBoxApellidos.Text;
                    objetoClientes.Cedula = textBoxCedula.Text;
                    objetoClientes.Telefono = textBoxTelefono.Text;
                    objetoClientes.Idruta = Convert.ToInt32(comboBoxIdRuta.SelectedValue.ToString());
                    objetoClientes.Idboleto = Convert.ToInt32(comboBoxIdBoleto.SelectedValue.ToString());

                    if (logicaNC.insertarClientes(objetoClientes) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewClientes.DataSource = logicaNC.listarClientes();
                        textBoxNombres.Text = "";
                        textBoxApellidos.Text = "";
                        textBoxCedula.Text = "";
                        textBoxTelefono.Text = "";
                        comboBoxIdRuta.Text = "";
                        comboBoxIdBoleto.Text = "";
                        tabClientes.SelectedTab = tabPage2;
                    }
                    else
                    { MessageBox.Show("Error al agregar Cliente"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Clientes objetoClientes = new Clientes();
                    objetoClientes.Idcliente = Convert.ToInt32(textBoxId.Text);
                    objetoClientes.Nombres = textBoxNombres.Text;
                    objetoClientes.Apellidos= textBoxApellidos.Text;
                    objetoClientes.Cedula = textBoxCedula.Text;
                    objetoClientes.Telefono = textBoxTelefono.Text;
                    objetoClientes.Idruta = Convert.ToInt32(comboBoxIdRuta.Text);
                    objetoClientes.Idboleto = Convert.ToInt32(comboBoxIdBoleto.Text);

                    if (logicaNC.EditarClientes(objetoClientes) > 0)
                    {
                        MessageBox.Show("actualizado con éxito");
                        dataGridViewClientes.DataSource = logicaNC.listarClientes();
                        textBoxNombres.Text = "";
                        textBoxApellidos.Text = "";
                        textBoxCedula.Text = "";
                        textBoxTelefono.Text = "";
                        comboBoxIdRuta.Text = "";
                        comboBoxIdBoleto.Text = "";
                        tabClientes.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Cliente");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void fClientes_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelIdcliente.Visible = false;

            var datos = logicaRT.listarRuta();
            comboBoxIdRuta.DataSource = (
                from ruta in datos
                select new
                {
                    ruta.Idruta,
                    nombreruta = ruta.NombreR
                }
            ).ToList();

            comboBoxIdRuta.ValueMember = "Idruta";
            comboBoxIdRuta.DisplayMember = "nombreruta";

            var dato = logicaCB.listarCompra_boleto();
            comboBoxIdBoleto.DataSource = (
                from boleto in dato
                select new
                {
                    boleto.Idboleto,
                    compraboleto = boleto.Idboleto
                }
            ).ToList();

            comboBoxIdBoleto.ValueMember = "Idboleto";
            comboBoxIdBoleto.DisplayMember = "Idboleto";
            
            dataGridViewClientes.DataSource = logicaNC.listarClientes();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelIdcliente.Visible = true;
            comboBoxIdRuta.Visible = true;
            comboBoxIdRuta.Enabled = false;
            labelIdRuta.Visible = true;
            comboBoxIdBoleto.Visible = true;
            comboBoxIdBoleto.Enabled = true;
            labelIdBoleto.Visible = true;

            textBoxId.Text = dataGridViewClientes.CurrentRow.Cells["Idcliente"].Value.ToString();
            textBoxNombres.Text = dataGridViewClientes.CurrentRow.Cells["Nombres"].Value.ToString();
            textBoxApellidos.Text = dataGridViewClientes.CurrentRow.Cells["Apellidos"].Value.ToString();
            textBoxCedula.Text = dataGridViewClientes.CurrentRow.Cells["Cedula"].Value.ToString();
            textBoxTelefono.Text = dataGridViewClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            comboBoxIdRuta.Text = dataGridViewClientes.CurrentRow.Cells["Idruta"].Value.ToString();
            comboBoxIdBoleto.Text = dataGridViewClientes.CurrentRow.Cells["Idboleto"].Value.ToString();

            tabClientes.SelectedTab = tabPage1;
            buttonGuardar.Text = "actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int codigC = Convert.ToInt32(dataGridViewClientes.CurrentRow.Cells["Idcliente"].Value.ToString());
            try
            {
                if (logicaNC.EliminarClientes(codigC) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewClientes.DataSource = logicaNC.listarClientes();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al eliminar Cliente");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            List<Clientes> listaClientes = logicaNC.BuscarClientes(textBoxBuscar.Text);
            dataGridViewClientes.DataSource = listaClientes;
        }

    }
}
