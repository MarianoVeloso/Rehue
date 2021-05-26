using Rehue.BE;
using Rehue.BLL;
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

namespace Rehue.LogIn
{
    public partial class RegistrarPersona : RegistroForm
    {
        private readonly PersonaBLL _usuarioBLL = new PersonaBLL();
        public RegistrarPersona()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            _usuarioBLL.Save(new Persona());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
