using Business.Services;
using Business.Services.CompanyServ;
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
    public partial class frmListadoEmpresas : Form
    {
        private readonly ICompanyServices _companyServices;
        public frmListadoEmpresas(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
            InitializeComponent();
        }

        private void FrmListadoEmpresas_Load(object sender, EventArgs e)
        {
            //En el combo de provincias habría que rellenar solamente las provincias de las que tengamos empresas. Ahora lo he rellenado a pelo.
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                dgvCompanies.AutoGenerateColumns = true;
                dgvCompanies.DataSource = _companyServices.GetListOfCompanies(this.cmbProvincias.Text, this.txtFilterCompanyName.Text);
                dgvCompanies.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CmdBuscar_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void CmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
