using Rehue.DAL;
using Rehue.Interfaces;
using Rehue.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class SubscripcionBLL
    {
        private readonly SubscripcionDAL _servicio = new SubscripcionDAL();

        public void CrearSubscripcion(ISubscripcion subscripcion)
        {
            _servicio.CrearSubscripcion(subscripcion);
        }

        public List<ISubscripcion> ObtenerTodos()
        {
            return _servicio.ObtenerTodos();
        }

        public ISubscripcion ObtenerPorId(int idSubscripcion)
        {
            return _servicio.ObtenerPorId(idSubscripcion);
        }

        public void PagarSubscripcion(int idEmpresa, int idSubscripcion)
        {
            _servicio.PagarSubscripcion(idEmpresa, idSubscripcion);
            ((IEmpresa)Session.Instancia.Usuario).AgregarSubscripcion(ObtenerPorId(idSubscripcion));
        }
    }
}
