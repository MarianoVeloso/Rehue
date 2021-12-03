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
    public class MenuComponentBLL
    {
        private readonly MenuComponentDAL _servicio = new MenuComponentDAL();

        public IMenu ObtenerPorId(int id)
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
        public IList<IMenu> ObtenerTodos()
        {
            try
            {
                return _servicio.ObtenerTodos(Session.Instancia.Usuario.Id);
            }
            catch (OperacionDBException ex)
            {
                throw RiseException(ex, "ErrorBaseDeDatos");
            }
        }
        public void Guardar(IMenu entity)
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
        public void GuardarItem(IItem permiso)
        {
            try
            {
                _servicio.GuardarItem(permiso);
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
        public void Eliminar(IMenu entity)
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
        public void EliminarHijo(IItem entity)
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

        public void AgregarHijo(IItem entity)
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

        public IList<IMenu> ObtenerPorUsuario(int idUsuario)
        {
            return _servicio.ObtenerMenuesPorUsuario(idUsuario, Session.Instancia.Usuario.Id);
        }

        public void AsignarRolAUsuario(IUsuario usuario, IMenu rol)
        {
            try
            {
                _servicio.AsignarMenuAUsuario(usuario.Id, rol.Id);
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
        public void EliminarRolAUsuario(IUsuario usuario, IMenu rol)
        {
            try
            {
                _servicio.EliminarMenuAUsuario(usuario.Id, rol.Id);
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
                return new OperacionDBException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)[message].Texto);
            }
        }
    }
}
