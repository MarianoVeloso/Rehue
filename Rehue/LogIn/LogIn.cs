﻿using System;
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
    public partial class LogIn : RehueDefaultForm
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            RegistrarPersona form = new RegistrarPersona();

            form.ShowDialog();

        }

        private void btnRegistrarEmpresa_Click(object sender, EventArgs e)
        {
            RegistrarEmpresa form = new RegistrarEmpresa();

            form.ShowDialog();
        }
    }
}