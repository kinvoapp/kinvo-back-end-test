using KinvoTeste.Models;
using KinvoTesteConsole.Helper;
using System;
using System.Collections.Generic;

namespace KinvoTesteConsole.Service
{
    public class UsuarioService
    {
        public bool NovoUsuario(string login, string senha)
        {
            var client = new HttpClientHelper();
            try
            {
                var param = new Dictionary<string, object>();
                param.Add("usuario", (new Usuario{ Login = login, Senha = senha}).ToJson());
                var retorno = client.Post("Usuario", param).Result;
                if (!string.IsNullOrWhiteSpace(retorno))
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public Usuario Login(string login, string senha)
        {
            var client = new HttpClientHelper();
            try
            {
                var param = new Dictionary<string, object>();
                param.Add("loginusuario", login);
                param.Add("senha", senha);
                param.Add("login", "login");
                var retorno = client.Get("Usuario", param).Result;
                if (!string.IsNullOrWhiteSpace(retorno))
                {
                    var usuario = retorno.To<Usuario>();
                    HttpClientHelper.token = usuario.Token;
                    return usuario;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Usuario Obter(int id)
        {
            var client = new HttpClientHelper();
            try
            {
                var param = new Dictionary<string, object>();
                param.Add("id", id);
                var retorno = client.Get("Usuario", param).Result;
                if (!string.IsNullOrWhiteSpace(retorno))
                {
                    var usuario = retorno.To<Usuario>();
                    return usuario;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
