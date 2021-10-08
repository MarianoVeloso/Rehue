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
    public class RehueBLL
    {
        private readonly RehueDAL _rehueDAL = new RehueDAL();

        public void ValidarEmail(string email, IIdioma idioma)
        {
            try
            {
                bool inValido = _rehueDAL.ValidarEmail(email);

                if (inValido)
                    throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(idioma)["MailRegistrado"].Texto);
            }
            catch (ErrorLogInException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public void ValidarUsuarioContraseña(IUsuario entity, IIdioma idioma)
        {
            string hash = Encriptador.GenerarHashMD5(entity.Contraseña);
            try
            {
                bool inValido = _rehueDAL.ObtenerIdUsuario(entity, hash) == 0;

                if (inValido)
                    throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(idioma)["MailYContrateñaErroneos"].Texto);
            }
            catch (ErrorLogInException ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ErrorLogInException(ex.Message);
            }
        }

        public List<IUsuario> ObtenerIdEmailUsuarios()
        {
            try
            {
                var usuarios= _rehueDAL.ObtenerIdEmailUsuarios();

                return usuarios;

            }
            catch (ErrorLogInException ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorBaseDeDatos"].Texto);
            }
            catch (Exception ex)
            {
                throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(Session.Instancia.Usuario.Idioma)["ErrorBaseDeDatos"].Texto);
            }
        }

        public void LogIn(IUsuario entity, IIdioma idioma)
        {
            EmpresaBLL _empresaBLL = new EmpresaBLL();

            string hash = Encriptador.GenerarHashMD5(entity.Contraseña);
            int entityId = _rehueDAL.ObtenerIdUsuario(entity, hash);

            IEmpresa empresa = _empresaBLL.ObtenerPorId(entityId);

            if (empresa.Id != 0)
            {
                Session.Instancia.Login(empresa);
            }
            else
            {
                PersonaBLL _personaBLL = new PersonaBLL();
                IPersona persona = _personaBLL.ObtenerPorId(entityId);

                if (persona.Id != 0)
                {
                    Session.Instancia.Login(persona);
                }
                else
                {
                    AdministradorBLL _administradorBLL = new AdministradorBLL();
                    IAdministrador administrador = _administradorBLL.ObtenerPorId(entityId);

                    if(administrador.Id == 0)
                        throw new ErrorLogInException(TraductorBLL.ObtenerTraducciones(idioma)["MailYContrateñaErroneos"].Texto);

                    Session.Instancia.Login(administrador);
                }
            }
        }
    }
}
