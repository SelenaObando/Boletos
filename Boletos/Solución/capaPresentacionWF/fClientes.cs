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
                    objetoClientes.Idruta = Convert.ToInt32(textBoxIdRuta.Text);
                    objetoClientes.Idboleto = Convert.ToInt32(textBoxIdBoleto.Text);

                    if (logicaNC.insertarClientes(objetoClientes) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewClientes.DataSource = logicaNC.listarClientes();
                        textBoxNombres.Text = "";
                        textBoxApellidos.Text = "";
                        textBoxCedula.Text = "";
                        textBoxTelefono.Text = "";
                        textBoxIdRuta.Text = "";
                        textBoxIdBoleto.Text = "";
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
                    objetoClientes.Idruta = Convert.ToInt32(textBoxIdRuta.Text);
                    objetoClientes.Idboleto = Convert.ToInt32(textBoxIdBoleto.Text);

                    if (logicaNC.EditarClientes(objetoClientes) > 0)
                    {
                        MessageBox.Show("actualizado con éxito");
                        dataGridViewClientes.DataSource = logicaNC.listarClientes();
                        textBoxNombres.Text = "";
                        textBoxApellidos.Text = "";
                        textBoxCedula.Text = "";
                        textBoxTelefono.Text = "";
                        textBoxIdRuta.Text = "";
                        textBoxIdBoleto.Text = "";
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
            labelId.Visible = false;
            dataGridViewClientes.DataSource = logicaNC.listarClientes();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            textBoxId.Text = dataGridViewClientes.CurrentRow.Cells["Idcliente"].Value.ToString();
            textBoxNombres.Text = dataGridViewClientes.CurrentRow.Cells["Nombres"].Value.ToString();
            textBoxApellidos.Text = dataGridViewClientes.CurrentRow.Cells["Apellidos"].Value.ToString();
            textBoxCedula.Text = dataGridViewClientes.CurrentRow.Cells["Cedula"].Value.ToString();
            textBoxTelefono.Text = dataGridViewClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            textBoxIdRuta.Text = dataGridViewClientes.CurrentRow.Cells["Idruta"].Value.ToString();
            textBoxIdBoleto.Text = dataGridViewClientes.CurrentRow.Cells["Idboleto"].Value.ToString();

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
