using Rehue.DAL;
using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class RolComponentBLL : ICrud<IRol>
    {
        private readonly RolComponentDAL _servicio = new RolComponentDAL();

        public IRol ObtenerPorId(int id)
        {
            try
            {
                return _servicio.ObtenerPorId(id);
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }
        public IList<IRol> ObtenerTodos()
        {
            try
            {
                return _servicio.ObtenerTodos();
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }
        public void Guardar(IRol entity)
        {
            try
            {
                _servicio.Guardar(entity);
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
            catch (Exception ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }
        public void GuardarPermiso(IPermiso permiso)
        {
            _servicio.GuardarPermiso(permiso);
        }
        public void Eliminar(IRol entity)
        {
            try
            {
                _servicio.Eliminar(entity);
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
            catch (Exception ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }
        public void EliminarHijo(IPermiso entity)
        {
            try
            {
                _servicio.EliminarHijo(entity);
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
            catch (Exception ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }

        public void AgregarHijo(IPermiso entity)
        {
            try
            {
                _servicio.AgregarHijo(entity);
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
            catch (Exception ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }

        public IList<IRol> ObtenerPorUsuario(int idUsuario)
        {
            return _servicio.ObtenerRolesYPermisosPorUsuario(idUsuario);
        }

        public void AsignarRolAUsuario(IUsuario usuario, IRol rol)
        {
            try
            {
                _servicio.AsignarRolAUsuario(usuario.Id, rol.Id);
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
            catch (Exception ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }
        public void EliminarRolAUsuario(IUsuario usuario, IRol rol)
        {
            try
            {
                _servicio.EliminarRolAUsuario(usuario.Id, rol.Id);
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }

        private Exception RiseException(Exception ex, string message)
        {
            if (ex.GetType().Equals(typeof(OperacionDBException)))
            {
                return new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)[message].Texto);
            }
            else
            {
                return new Exception(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)[message].Texto);
            }
        }
    }
}
