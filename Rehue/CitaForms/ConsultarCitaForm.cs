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
                    Session.Instancia.Usuario.HasPermisson("Confirmar Cita"))
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

            Dictionary<string, Type> columns = new Dictionary<string, Type> {
                { "NumeroCN", typeof(int) },
                { "FechaCreacionCN", typeof(DateTime) },
                { "FechaEncuentroCN", typeof(DateTime) },
                { "MesaCN", typeof(string) },
                { "CantidadComensalesCN", typeof(int) },
                { "UsuarioCN", typeof(string) }
            };

            GrillaHelper.CrearColumnasGridCita(columns,
                new List<string> { "Id", "FechaCreacion", "FechaEncuentro", "Mesa.Descripcion", "CantidadComensales", "Persona.ObtenerNombre()" },
                Session.Instancia.Usuario.ObtenerCitasPendienteConfirmacion(),
                dtGridPendienteConfirmacion
                );

            GrillaHelper.CrearColumnasGridCita(columns,
                new List<string> { "Id", "FechaCreacion", "FechaEncuentro", "Mesa.Descripcion", "CantidadComensales", "Persona.ObtenerNombre()" },
                Session.Instancia.Usuario.ObtenerCitasConfirmadas(),
                dtGridCitasConfirmadas
                );

            columns = new Dictionary<string, Type> {
                { "NumeroCN", typeof(int) },
                { "FechaCreacionCN", typeof(DateTime) },
                { "FechaCancelacionCN", typeof(DateTime) },
                { "MesaCN", typeof(string) },
                { "CantidadComensalesCN", typeof(int) },
                { "UsuarioCN", typeof(string) }
            };

            GrillaHelper.CrearColumnasGridCita(columns,
                new List<string> { "Id", "FechaCreacion", "FechaCancelacion", "Mesa.Descripcion", "CantidadComensales", "Persona.ObtenerNombre()" },
                Session.Instancia.Usuario.ObtenerCitasCanceladas(),
                dtGridCanceladas
                );

            columns = new Dictionary<string, Type> {
                { "NumeroCN", typeof(int) },
                { "FechaCreacionCN", typeof(DateTime) },
                { "MesaCN", typeof(string) },
                { "DetalleDenunciaCN", typeof(string) },
                { "UsuarioCN", typeof(string) }
            };

            GrillaHelper.CrearColumnasGridCita(columns,
                new List<string> { "Id", "FechaCreacion", "Mesa.Descripcion", "Denuncia.Descripcion", "Persona.ObtenerNombre()" },
                Session.Instancia.Usuario.ObtenerCitaPendienteResolucion(),
                dtGridCanceladas
                );

            _idCitaPendienteConfirmacion = 0;
            _idCitaADenunciar = 0;
        }

        private void btnDenunciar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarId(dtGridCitasConfirmadas, _idCitaADenunciar);
                DenunciaForm form = new DenunciaForm(_citaBLL.ObtenerCitaPorId(_idCitaADenunciar));
                form.ShowDialog();
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
            if (dtGridPendienteConfirmacion.Rows.Count > 0 && dtGridPendienteConfirmacion.Rows[e.RowIndex].Cells[0] != null)
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