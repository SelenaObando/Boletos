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
    public partial class fUsuario : Form
    {
        logicaNegocioUsuario logicaNU = new logicaNegocioUsuario();

        public fUsuario()
        {
            InitializeComponent();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Usuario objetoUsuario = new Usuario();
                    objetoUsuario.Nombre = textBoxNombre.Text;
                    objetoUsuario.Apellido = textBoxApellido.Text;
                    objetoUsuario.Direccion = textBoxDireccion.Text;
                    objetoUsuario.Correo = textBoxCorreo.Text;
                    objetoUsuario.TelefonoU = textBoxTelefono.Text;

                    if (logicaNU.insertarUsuario(objetoUsuario) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewUsuario.DataSource = logicaNU.listarUsuario();
                        textBoxNombre.Text = "";
                        textBoxApellido.Text = "";
                        textBoxDireccion.Text = "";
                        textBoxCorreo.Text = "";
                        textBoxTelefono.Text = "";
                        tabUsuario.SelectedTab = tabPage2;
                    }
                    else
                    { MessageBox.Show("Error al agregar Usuario"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Usuario objetoUsuario = new Usuario();
                    objetoUsuario.Idusuario = Convert.ToInt32(textBoxId.Text);
                    objetoUsuario.Nombre = textBoxNombre.Text;
                    objetoUsuario.Apellido = textBoxApellido.Text;
                    objetoUsuario.Direccion = textBoxDireccion.Text;
                    objetoUsuario.Correo = textBoxCorreo.Text;
                    objetoUsuario.TelefonoU = textBoxTelefono.Text;

                    if (logicaNU.EditarUsuario(objetoUsuario) > 0)
                    {
                        MessageBox.Show("actualizado con éxito");
                        dataGridViewUsuario.DataSource = logicaNU.listarUsuario();
                        textBoxNombre.Text = "";
                        textBoxApellido.Text = "";
                        textBoxDireccion.Text = "";
                        textBoxCorreo.Text = "";
                        textBoxTelefono.Text = "";
                        tabUsuario.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Usuario");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void fUsuario_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelId.Visible = false;
            dataGridViewUsuario.DataSource = logicaNU.listarUsuario();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            textBoxId.Text = dataGridViewUsuario.CurrentRow.Cells["Idusuario"].Value.ToString();
            textBoxNombre.Text = dataGridViewUsuario.CurrentRow.Cells["Nombres"].Value.ToString();
            textBoxApellido.Text = dataGridViewUsuario.CurrentRow.Cells["Apellidos"].Value.ToString();
            textBoxDireccion.Text = dataGridViewUsuario.CurrentRow.Cells["Direccion"].Value.ToString();
            textBoxCorreo.Text = dataGridViewUsuario.CurrentRow.Cells["Correo"].Value.ToString();
            textBoxTelefono.Text = dataGridViewUsuario.CurrentRow.Cells["Telefono"].Value.ToString();

            tabUsuario.SelectedTab = tabPage1;
            buttonGuardar.Text = "Actualizar";
        }

        private void buttonEliminar_Click_1(object sender, EventArgs e)
        {
            int codigU = Convert.ToInt32(dataGridViewUsuario.CurrentRow.Cells["Idusuario"].Value.ToString());
            try
            {
                if (logicaNU.EliminarUsuario(codigU) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewUsuario.DataSource = logicaNU.listarUsuario();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al eliminar Usuario");
            }
        }

        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            List<Usuario> listaUsuario = logicaNU.BuscarUsuario(textBoxBuscar.Text);
            dataGridViewUsuario.DataSource = listaUsuario;
        }
    }
}
