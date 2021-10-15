using Rehue.DAL;
using Rehue.Interfaces;
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
    }
}
