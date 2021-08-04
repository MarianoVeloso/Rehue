using Rehue.BLL;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rehue.CitaForms
{
    public partial class GestionarDenunciaForm : Form
    {
        private readonly CitaBLL _citaBLL = new CitaBLL();
        private readonly DenunciaBLL _denunciaBLL = new DenunciaBLL();
        private int _idDenuncia;
        public GestionarDenunciaForm()
        {
            InitializeComponent();
        }
        private void FormLoad()
        {
            dtGridCitasConDenuncia.DataSource = null;
            try
            {
                dtGridCitasConDenuncia.DataSource = _citaBLL.ObtenerCitasConDenunciaSinGestion().Select(x => new
                {
                    NumeroDenuncia = x.Denuncia.Id,
                    NumeroCita = x.Id,
                    FechaCreacion = x.FechaCreacion,
                    FechaEncuentro = x.FechaEncuentro,
                    Empresa = x.Empresa.ObtenerNombre(),
                    Usuario = x.Persona.ObtenerNombre(),
                    CantidadDeComensales = x.CantidadComensales,
                    Motivo = x.Denuncia.Descripcion
                }).ToList();

                dtGridDenunciasGestionadas.DataSource = null;
                dtGridDenunciasGestionadas.DataSource = _denunciaBLL.ObtenerDenunciaPorIdAdministrador(Session.Instancia.Usuario.Id).Select(x => new
                {
                    Numero = x.Id,
                    FechaCreacion = x.FechaCreacion,
                    Administrador = x.Administrador.ObtenerNombre(),
                    FechaConfirmacion = x.FechaConfirmacion,
                    FechaCancelacion = x.FechaCancelacion,
                    Motivo = x.Descripcion
                }).ToList();
            }
            catch (OperacionDBException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DenunciasForm_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void dtGridCitasConDenuncia_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtGridCitasConDenuncia.ClearSelection();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarId();
                _denunciaBLL.ConfirmarDenuncia(_idDenuncia); 
                FormLoad();
            }
            catch (OperacionDBException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarId();
                _denunciaBLL.CancelarDenuncia(_idDenuncia);
                FormLoad();
            }
            catch (OperacionDBException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ControlarId()
        {
            if (_idDenuncia == 0)
            {
                throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["NoElementoEnGrilla"].Texto);
            }
        }

        private void dtGridCitasConDenuncia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGridCitasConDenuncia.Rows.Count > 0 && dtGridCitasConDenuncia.Rows[e.RowIndex].Cells[0].Value != null)
            {
                _idDenuncia = int.Parse(dtGridCitasConDenuncia.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
    }
}
