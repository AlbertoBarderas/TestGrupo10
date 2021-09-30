using Business.Services;
using Business.Services.BoeReading;
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
    public partial class frmCalendar : Form
    {

        private readonly IBoeReadingServices _boeReadingServices;
        private readonly IDocumentBormeServices _documentBormeServices;


        public frmCalendar(IBoeReadingServices boeReadingServices, IDocumentBormeServices documentBormeServices)
        {
            _boeReadingServices = boeReadingServices;
            _documentBormeServices = documentBormeServices;
            InitializeComponent();
        }

        private void FrmCalendar_Load(object sender, EventArgs e)
        {
            //TODO
            //Em este formulario deberíamos tener un control calendar bien tuneado y no un gridView
            //Al leer si elige un día ua leído preguntarle si quiere volver a leer 
            dgvReads.RowHeadersVisible = false;
            LoadDataGrid();
        }


        private void LoadDataGrid()
        {
            try
            {
                dgvReads.AutoGenerateColumns = true;
                var listDates = _boeReadingServices.GetListOfReadings();
                dgvReads.DataSource = listDates;
                dgvReads.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvReads.Columns[0].HeaderText = "Fecha";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CmdCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdLeerBoe_Click(object sender, EventArgs e)
        {
            try
            {
                _documentBormeServices.ReadDocumentsByDate(this.dtpRead.Value.Date);
                LoadDataGrid();
                MessageBox.Show("Lectura realizada correctamente", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
