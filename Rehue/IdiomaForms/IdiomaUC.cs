using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rehue.IdiomaForms
{
    public partial class IdiomaUC : UserControl
    {
        private IEtiqueta _etiqueta;

        public IEtiqueta Etiqueta
        {
            get { return _etiqueta; }
            set { _etiqueta = value; }
        }

        private ITraduccion _traduccion;

        public ITraduccion Traduccion
        {
            get { return _traduccion; }
            set { _traduccion = value; }
        }

        public IdiomaUC()
        {
            InitializeComponent();
        }

        private void IdiomaUC_Load(object sender, EventArgs e)
        {
            lblEtiqueta.Text = _etiqueta.Nombre;
            txtTraduccion.Text = _traduccion.Texto;
        }

        private void txtTraduccion_Leave(object sender, EventArgs e)
        {
            Traduccion.Texto = txtTraduccion.Text;
        }
    }
}
