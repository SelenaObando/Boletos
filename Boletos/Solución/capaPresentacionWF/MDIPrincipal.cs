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

namespace capaPresentacionWF
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        logicaNegocioRespaldo LN = new logicaNegocioRespaldo();

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {

            if (Application.OpenForms["fClientes"] != null)
            {
                Application.OpenForms["fClientes"].Activate();
            }
            else 
            {
                fClientes fc = new fClientes();
                fc.MdiParent = this;
                fc.Show();
            }
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Ventana " + childFormNumber++;
            //childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = AcercadeBarToolStripMenuItem.Checked;
        }

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("¿Esta seguro de que quiere cerrar la aplicación?",
                                                                     "Cerrar la aplicación", MessageBoxButtons.YesNo,
                                                                     MessageBoxIcon.Question);

            return res;
        }

        private void RespaldoBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (LN.respaldarBD() > 0)
                {
                    MessageBox.Show("Respaldo realizado con éxito");
                }
            }
            catch
            {
                MessageBox.Show("Error al realizar el respaldo");
            }
        }

      

        private void PropietarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["fPropietario"] != null)
            {
                Application.OpenForms["fPropietario"].Activate();
            }
            else
            {
                fPropietario fr = new fPropietario();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void RutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["fRuta"] != null)
            {
                Application.OpenForms["fRuta"].Activate();
            }
            else
            {
                fRuta fr = new fRuta();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void CompraASBoletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["fCompra_Boletos"] != null)
            {
                Application.OpenForms["fCompra_Boletos"].Activate();
            }
            else
            {
                fCompra_Boletos fr = new fCompra_Boletos();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["fUsuario"] != null)
            {
                Application.OpenForms["fUsuario"].Activate();
            }
            else
            {
                fUsuario fr = new fUsuario();
                fr.MdiParent = this;
                fr.Show();
            }
        }


    }
}
