using DevShop.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Services.Externo
{
    public class GitHub
    {
        public UsuarioGitHub ObterUsuario(string usuario)
        {
            try
            {
                var json = string.Empty;
                var request = WebRequest.Create($"https://api.github.com/users/{ usuario }") as HttpWebRequest;
                request.Method = "GET";
                request.Proxy = null;
                request.UserAgent = "edubalf";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        json = reader.ReadToEnd();
                    }
                }

                return JsonConvert.DeserializeObject<UsuarioGitHub>(json);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
