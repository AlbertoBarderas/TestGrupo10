using Business.Services.BoeReading;
using Business.Services.CompanyServ;
using Business.Services.DocumentBorme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaGrupo10
{
    public partial class PrincipalMDI : Form
    {

        private readonly IBoeReadingServices _boeReadingServices;

        private readonly IDocumentBormeServices _documentBormeServices;

        private readonly ICompanyServices _companyServices;
        public PrincipalMDI(IBoeReadingServices boeReadingServices, IDocumentBormeServices documentBormeServices, ICompanyServices companyServices)
        {
            _boeReadingServices = boeReadingServices;
            _documentBormeServices = documentBormeServices;
            _companyServices = companyServices;
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmCalendar childForm = new frmCalendar(_boeReadingServices, _documentBormeServices);
            childForm.MdiParent = this;
            childForm.Text = "Cargas del BOE";
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            frmListadoEmpresas childForm = new frmListadoEmpresas(_companyServices);
            childForm.MdiParent = this;
            childForm.Text = "Listado Empresas ";
            childForm.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     


        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}
