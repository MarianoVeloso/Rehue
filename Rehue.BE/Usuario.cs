﻿using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BE
{
    public abstract class Usuario : Entity, IUsuario
    {
        public Usuario()
        {
            _roles = new List<IRol>();
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateTime _fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _reputacion;

        public int Reputacion
        {
            get { return _reputacion; }
            set { _reputacion = value; }
        }


        private IList<IRol> _roles;
        public IList<IRol> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        private string _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
    }
}
