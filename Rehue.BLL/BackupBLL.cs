using Microsoft.Win32;
using Rehue.DAL;
using Rehue.Interfaces;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class BackupBLL
    {
        private readonly BackupDAL _servicio = BackupDAL.Instancia;

        public void Crear(IBackup backup)
        {
            _servicio.Crear(backup);
        }

        public List<IBackup> ObtenerTodos()
        {
            return _servicio.ObtenerTodos();
        }

        public IBackup ObtenerPorId(int id)
        {
            return _servicio.ObtenerPorId(id);
        }

        public void RestaturarBackup(string ubicacion)
        {
            _servicio.RestaturarBackup(ubicacion);
        }

        public void VerificarRegistroYConexion()
        {
            RegistryKey RK = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MICROSOFT\Microsoft SQL Server");
            if (RK == null)
            {
                throw new Exception("No se encontró el SQL Instalado en la máquina, por favor procure instalarlo antes de continuar.");
            }

            if (!_servicio.VerificarConexion())
            {
                throw new ConexionDBException("Base de datos no encontrada, restaure un backup para poder proseguir.");
            }

        }
    }
}
