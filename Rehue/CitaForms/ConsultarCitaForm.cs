using Rehue.BLL;
using Rehue.Interfaces;
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
    public partial class ConsultarCitaForm : Form, IIdiomaObserver
    {
        private readonly CitaBLL _citaBLL = new CitaBLL();
        private int _idCitaPendienteConfirmacion;
        private int _idCitaADenunciar;
        public ConsultarCitaForm()
        {
            InitializeComponent();
        }

        private void ConsultarCitaForm_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarIdioma(Session.Instancia.Usuario.Idioma);
                TraductorBLL.SuscribirForm(this);
                LoadForm();
                MostrarDatos();
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

        private void LoadForm()
        {
            if (Session.Instancia.Usuario.IsInRol("Empresa") &&
                    Session.Instancia.Usuario.HasPermisson("Confirmar cita"))
            {
                btnConfirmar.Visible = true;
            }
            else
            {
                btnConfirmar.Visible = false;
            }
        }

        private void MostrarDatos()
        {
            _citaBLL.ObtenerCitasDeUsuarioLogeado();

            dtGridPendienteConfirmacion.DataSource = null;
            dtGridPendienteConfirmacion.DataSource = Session.Instancia.Usuario.ObtenerCitasPendienteConfirmacion().Select(x => new
            {
                Numero = x.Id,
                FechaCreacion = x.FechaCreacion,
                FechaEncuentro = x.FechaEncuentro,
                Empresa = x.Empresa.ObtenerNombre(),
                Usuario = x.Persona.ObtenerNombre(),
                CantidadDeComensales = x.CantidadComensales
            }).ToList();

            dtGridCitasConfirmadas.DataSource = null;
            dtGridCitasConfirmadas.DataSource = Session.Instancia.Usuario.ObtenerCitasConfirmadas().Select(x => new
            {
                Numero = x.Id,
                FechaCreacion = x.FechaCreacion,
                FechaEncuentro = x.FechaEncuentro,
                Empresa = x.Empresa.ObtenerNombre(),
                Usuario = x.Persona.ObtenerNombre(),
                CantidadDeComensales = x.CantidadComensales
            }).ToList();

            dtGridCanceladas.DataSource = null;
            dtGridCanceladas.DataSource = Session.Instancia.Usuario.ObtenerCitasCanceladas().Select(x => new
            {
                Numero = x.Id,
                FechaCreacion = x.FechaCreacion,
                FechaCancelacion = x.FechaCancelacion,
                Empresa = x.Empresa.ObtenerNombre(),
                Usuario = x.Persona.ObtenerNombre(),
                CantidadDeComensales = x.CantidadComensales
            }).ToList();

            dtGridViewCitasPendienteResolucion.DataSource = null;
            dtGridViewCitasPendienteResolucion.DataSource = Session.Instancia.Usuario.ObtenerCitasConDenuncia().Select(x => new
            {
                Numero = x.Id,
                FechaCreacion = x.FechaCreacion,
                Empresa = x.Empresa.ObtenerNombre(),
                Usuario = x.Persona.ObtenerNombre(),
                CantidadDeComensales = x.CantidadComensales,
                DetalleDenuncia = x.Denuncia?.Descripcion
            }).ToList();
        }

        private void btnDenunciar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarId(dtGridCitasConfirmadas, _idCitaADenunciar);
                DenunciaForm form = new DenunciaForm(_citaBLL.ObtenerCitaPorId(_idCitaADenunciar));
                form.ShowDialog();
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarId(dtGridPendienteConfirmacion, _idCitaPendienteConfirmacion);

                _citaBLL.ConfirmarCita(_idCitaPendienteConfirmacion);
                MostrarDatos();

                MessageBox.Show(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["CitaConfirmada"].Texto);
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
                ControlarId(dtGridPendienteConfirmacion, _idCitaPendienteConfirmacion);

                _citaBLL.CancelarCita(_idCitaPendienteConfirmacion);
                MostrarDatos();

                MessageBox.Show(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["CitaCancelada"].Texto);
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

        private void dtGridCitasConfirmadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGridCitasConfirmadas.Rows.Count > 0 && dtGridCitasConfirmadas.Rows[e.RowIndex].Cells[0].Value != null)
            {
                _idCitaADenunciar = int.Parse(dtGridCitasConfirmadas.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void dtGridPendienteConfirmacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGridPendienteConfirmacion.Rows.Count > 0 && dtGridPendienteConfirmacion.Rows[e.RowIndex].Cells[0].Value != null)
            {
                _idCitaPendienteConfirmacion = int.Parse(dtGridPendienteConfirmacion.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ControlarId(DataGridView dataGrid, int id)
        {
            if (dataGrid.Rows.Count == 0 || id == 0)
            {
                throw new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["NoElementoEnGrilla"].Texto);
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            var traducciones = TraductorBLL.ObtenerTraducciones(idioma);

            btnCancelar.Text = traducciones["btnCancelar"].Texto;
            btnConfirmar.Text = traducciones["btnConfirmar"].Texto;
            btnDenunciar.Text = traducciones["btnDenunciar"].Texto;
            lblCitasCanceladas.Text = traducciones["lblCitasCanceladas"].Texto;
            lblCitasConfirmadas.Text = traducciones["lblCitasConfirmadas"].Texto;
            lblCitasPendientes.Text = traducciones["lblCitasPendientes"].Texto;
            lblCitasPendientesDeResolucion.Text = traducciones["lblCitasPendientesDeResolucion"].Texto;
        }

        private void ConsultarCitaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraductorBLL.DesuscribirForm(this);
        }

        private void dtGridPendienteConfirmacion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtGridPendienteConfirmacion.ClearSelection();
        }

        private void dtGridCitasConfirmadas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtGridCitasConfirmadas.ClearSelection();
        }
    }
}
