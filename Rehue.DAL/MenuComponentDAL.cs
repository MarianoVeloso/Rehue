using Rehue.BE;
using Rehue.Interfaces;
using Rehue.Servicios;
using Rehue.Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.DAL
{
    public class MenuComponentDAL
    {
        private readonly Servicio _servicio = Servicio.Instancia;

        private static MenuComponentDAL _instancia;
        public static MenuComponentDAL Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new MenuComponentDAL();
                return _instancia;
            }
        }
        public IMenu ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", id)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_menu_por_id", parametros);

                IMenu permiso = new Menu();

                foreach (DataRow item in resultado.Rows)
                {
                    permiso = MapearMenu(item);
                }

                return permiso;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public IList<IMenu> ObtenerTodos(int idEmpresa)
        {
            try
            {
                var resultado = _servicio.Leer("obtener_menues");

                return MapearMenues(resultado.Rows, idEmpresa);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void Guardar(IMenu entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@Nombre", entity.Nombre),

            };

            try
            {
                _servicio.RealizarOperacion("registrar_menu", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void GuardarItem(IItem entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idPadre", entity.IdPadre),
                _servicio.CrearParametro("@idHijo", entity.Id),
                _servicio.CrearParametro("@costo", entity.Costo)

            };

            try
            {
                _servicio.RealizarOperacion("registrar_menu_padre_hijo", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void Eliminar(IMenu entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", entity.Id)
            };

            try
            {
                _servicio.RealizarOperacion("menu_eliminar", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }
        public void EliminarHijo(IItem entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idHijo", entity.Id),
                _servicio.CrearParametro("@idPadre", entity.IdPadre)
            };

            try
            {
                _servicio.RealizarOperacion("eliminar_item_padre_hijo", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void AgregarHijo(IItem entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idPadre", entity.IdPadre),
                _servicio.CrearParametro("@idEmpresa", Session.Instancia.Usuario.Id),
                _servicio.CrearParametro("@Descripcion", entity.Descripcion),
                _servicio.CrearParametro("@Costo", entity.Costo),
                _servicio.CrearParametro("@idReferencia", entity.Id)
            };

            try
            {
                _servicio.RealizarOperacion("registrar_item_padre_hijo", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }


        public IList<IMenu> ObtenerMenuesPorUsuario(int idUsuario, int idEmpresa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@id", idUsuario)
            };

            var resultado = _servicio.Leer("Obtener_menues_por_usuario", parametros);

            return MapearMenues(resultado.Rows, idEmpresa);
        }

        public void AsignarMenuAUsuario(int idUsuario, int idMenu)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idUsuario", idUsuario),
                _servicio.CrearParametro("@idMenu", idMenu)
            };
            try
            {
                _servicio.RealizarOperacion("registrar_menu_usuario", parametros);

            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void EliminarMenuAUsuario(int idUsuario, int idMenu)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idUsuario", idUsuario),
                _servicio.CrearParametro("@idMenu", idMenu)
            };
            try
            {
                _servicio.RealizarOperacion("eliminar_menu_usuario", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        private IList<IItem> ObtenerItemsPorIdPadre(int idPadre, int idEmpresa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                _servicio.CrearParametro("@idPadre", idPadre),
                _servicio.CrearParametro("@idEmpresa", idEmpresa)
            };

            try
            {
                var resultado = _servicio.Leer("obtener_items_por_idPadre", parametros);

                List<IItem> items = new List<IItem>();

                foreach (DataRow item in resultado.Rows)
                {
                    items.Add(MapearItem(item));
                }

                return items;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        private IMenu MapearMenu(DataRow row)
        {
            return new Menu()
            {
                Id = int.Parse(row["id"].ToString()),
                Nombre = row["Nombre"].ToString()
            };
        }

        private IItem MapearItem(DataRow row)
        {
            return new Item()
            {
                Id = int.Parse(row["id"].ToString()),
                IdPadre = int.Parse(row["idPadre"].ToString()),
                Nombre = row["Nombre"].ToString(),
                Costo = decimal.Parse(row["costo"].ToString()),
                Descripcion = row["descripcion"].ToString()
            };
        }

        private List<IMenu> MapearMenues(DataRowCollection rows, int idEmpresa)
        {
            List<IMenu> menues = new List<IMenu>();

            foreach (DataRow itemData in rows)
            {
                var menu = MapearMenu(itemData);

                var items = ObtenerItemsPorIdPadre(menu.ObtenerId(), idEmpresa);

                foreach (IItem item in items)
                {
                    menu.AgregarItem(item);
                }
                menues.Add(menu);
            }

            return menues;
        }
    }
}
