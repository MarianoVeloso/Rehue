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
    public class EmpresaDAL : Servicio, ICrud<IEmpresa>
    {
        public IEmpresa ObtenerPorId(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@id", id)
            };

            try
            {
                var resultado = Leer("obtener_empresa_por_id", parametros);

                IEmpresa empresa = new Empresa();

                foreach (DataRow item in resultado.Rows)
                {
                    empresa = MapearEmpresa(item);
                }

                return empresa;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public IList<IEmpresa> ObtenerTodos()
        {
            try
            {
                var resultado = Leer("obtener_empresas");

                List<IEmpresa> empresa = new List<IEmpresa>();

                foreach (DataRow item in resultado.Rows)
                {
                    empresa.Add(MapearEmpresa(item));
                }

                return empresa;
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void Guardar(IEmpresa entity)
        {
            string encryptPassword = Encriptador.Hash(entity.Contraseña);
            int id = 0;

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@email", entity.Email),
                CrearParametro("@password", encryptPassword),
                CrearParametro("@razonSocial", entity.RazonSocial),
                CrearParametro("@cuitCuil", entity.Documento),
                CrearParametro("@fechaNacimiento", entity.FechaNacimiento),
                CrearParametro("@ubicacion", entity.Ubicacion),
                CrearParametro("@telefono", entity.Telefono),
                CrearParametro("@id", id, ParameterDirection.Output)
            };

            try
            {
                RealizarOperacion("registar_empresa", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }

            entity.Id = int.Parse(parametros[7].Value.ToString());
        }

        public void Eliminar(IEmpresa entity)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                CrearParametro("@id", entity.Id)
            };

            try
            {
                RealizarOperacion("usuario_eliminar", parametros);
            }
            catch (OperacionDBException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        private IEmpresa MapearEmpresa(DataRow row)
        {
            return new Empresa()
            {
                Id = int.Parse(row["id"].ToString()),
                RazonSocial = row["razonSocial"].ToString(),
                Documento = int.Parse(row["documento"].ToString()),
                Email = row["email"].ToString(),
                FechaNacimiento = DateTime.Parse(row["fechaNacimiento"].ToString()),
                Ubicacion = row["ubicacion"].ToString()
            };
        }
    }
}
