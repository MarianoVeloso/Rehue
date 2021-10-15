using Rehue.BE;
using Rehue.Interfaces;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rehue.DAL
{
    public class BackupDAL
    {
        private readonly Servicio _servicio = Servicio.Instancia;

        private static BackupDAL _instancia;

        public static BackupDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new BackupDAL();
                return _instancia;
            }
        }

        public void Crear(IBackup backup)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@Nombre", backup.Nombre),
                _servicio.CrearParametro("@FechaCreacion", DateTime.Now),
                _servicio.CrearParametro("@Ubicacion", backup.Ubicacion + "\\" + backup.Nombre + ".bak")
            };
            try
            {
                _servicio.RealizarOperacionSinTransaccion("registrar_backup", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public List<IBackup> ObtenerTodos()
        {
            try
            {
                List<IBackup> backups = new List<IBackup>();
                var response = _servicio.Leer("obtener_backups");
                foreach (DataRow item in response.Rows)
                {
                    backups.Add(MapearBackup(item));
                }

                return backups;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private IBackup MapearBackup(DataRow row)
        {
            return new Backup
            {
                Id = int.Parse(row["id"].ToString()),
                Nombre = row["Nombre"].ToString(),
                FechaCreacion = DateTime.Parse(row["FechaCreacion"].ToString()),
                Ubicacion = row["Ubicacion"].ToString()
            };
        }
    }
}
