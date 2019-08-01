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
    public partial class fPropietario : Form
    {
        logicaNegocioPropietario logicaNP = new logicaNegocioPropietario();

        public fPropietario()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
             try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Propietario objetoPropietario = new Propietario();
                    objetoPropietario.Nombresp = textBoxNombresp.Text;
                    objetoPropietario.Apellidosp = textBoxApellidosp.Text;
                    objetoPropietario.Direccionp = textBoxDireccionp.Text;
                    objetoPropietario.Telefonop = textBoxTelefonop.Text;
                    objetoPropietario.Nombretransp = textBoxNombretransp.Text;

                    if (logicaNP.insertarPropietario(objetoPropietario) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewPropietario.DataSource = logicaNP.listarPropietario();
                        textBoxNombresp.Text = "";
                        textBoxApellidosp.Text = "";
                        textBoxDireccionp.Text = "";
                        textBoxTelefonop.Text = "";
                        textBoxNombretransp.Text = "";
                        tabPropietario.SelectedTab = tabPage2;
                    }
                    else
                    { MessageBox.Show("Error al agregar Propietario"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Propietario objetoPropietario = new Propietario();
                    objetoPropietario.Idpropietario = Convert.ToInt32(textBoxId.Text);
                    objetoPropietario.Nombresp = textBoxNombresp.Text;
                    objetoPropietario.Apellidosp = textBoxApellidosp.Text;
                    objetoPropietario.Direccionp = textBoxDireccionp.Text;
                    objetoPropietario.Telefonop = textBoxTelefonop.Text;
                    objetoPropietario.Nombretransp = textBoxNombretransp.Text;

                    if (logicaNP.EditarPropietario(objetoPropietario) > 0)
                    {
                        MessageBox.Show("actualizado con éxito");
                        dataGridViewPropietario.DataSource = logicaNP.listarPropietario();
                        textBoxNombresp.Text = "";
                        textBoxApellidosp.Text = "";
                        textBoxDireccionp.Text = "";
                        textBoxTelefonop.Text = "";
                        textBoxNombretransp.Text = "";
                        tabPropietario.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Propietario");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void fPropietario_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelId.Visible = false;
            dataGridViewPropietario.DataSource = logicaNP.listarPropietario();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            textBoxId.Text = dataGridViewPropietario.CurrentRow.Cells["IdPropietario"].Value.ToString();
            textBoxNombresp.Text = dataGridViewPropietario.CurrentRow.Cells["NombresP"].Value.ToString();
            textBoxApellidosp.Text = dataGridViewPropietario.CurrentRow.Cells["Apellidosp"].Value.ToString();
            textBoxDireccionp.Text = dataGridViewPropietario.CurrentRow.Cells["Direccionp"].Value.ToString();
            textBoxTelefonop.Text = dataGridViewPropietario.CurrentRow.Cells["Telefono"].Value.ToString();
            textBoxNombretransp.Text = dataGridViewPropietario.CurrentRow.Cells["Nombretransp"].Value.ToString();

            tabPropietario.SelectedTab = tabPage1;
            buttonGuardar.Text = "actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int codigP = Convert.ToInt32(dataGridViewPropietario.CurrentRow.Cells["IdPropietario"].Value.ToString());
            try
            {
                if (logicaNP.EliminarPropietario(codigP) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewPropietario.DataSource = logicaNP.listarPropietario();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al eliminar Propietario");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            List<Propietario> listaPropietario = logicaNP.BuscarPropietario(textBoxBuscar.Text);
            dataGridViewPropietario.DataSource = listaPropietario;
        }

        }
    }
