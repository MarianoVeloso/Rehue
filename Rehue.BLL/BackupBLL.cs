using Microsoft.Win32;
using Rehue.DAL;
using Rehue.Interfaces;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MICROSOFT\Microsoft SQL Server");
                if (rk == null)
                {
                    throw new InstaladorException("No se encontró el SQL Server Instalado en la máquina. Cerraremos el programa y ejecutaremos el instalador. Finalice la ínstalación e intente nuevamente.");
                }

                if (!_servicio.VerificarConexion())
                {
                    throw new ConexionDBException("Base de datos no encontrada, restaure un backup para poder proseguir.");
                }
            }
            catch (ConexionDBException ex)
            {
                XMLWriterException.Escribir(ex);
                throw;
            }
            catch (InstaladorException ex)
            {
                XMLWriterException.Escribir(ex);
                throw;
            }
            catch (Exception ex)
            {
                XMLWriterException.Escribir(ex);
                throw;
            }
        }
    }
}
