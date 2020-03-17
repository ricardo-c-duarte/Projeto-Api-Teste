using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Prova_WebAPI.Negocio
{
    public class Contato
    {

        string baseAPi = WebConfigurationManager.AppSettings["apiSwaggerBase"];
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public async Task<Models.Contato> Get(int idContato) {

            Models.Contato contato = new Models.Contato();
            
            try {

                if (idContato < 1 || idContato > 10 )
                    return null; // adicionado para teste


                var client = new RestClient(baseAPi);
                var request = new RestRequest("/" + idContato.ToString());
                var response = await client.ExecuteAsync<Models.Contato>(request , cancellationTokenSource.Token);
                if (response.IsSuccessful)
                    contato = response.Data;

            }
            catch (Exception ex) {
                throw new Exception("Erro na requisição");
            }

            return await Task.FromResult(contato);
        
        }

        public async Task<List<Models.Contato>> GetAll(int page, int size)
        {

            List<Models.Contato> contatos = new List<Models.Contato>();

            try
            {


                for (int i = 1; i < size; i++)
                {
                    Random random = new Random();
                    Models.Contato contato = new Models.Contato();

                    contato.id = i.ToString();
                    contato.nome = "Contato " + i.ToString().Trim();
                    contato.valor = random.Next(100, 3500).ToString();
                    contato.obs = "gerado em " + DateTime.Now;
                    contato.canal = "web";
                    contatos.Add(contato);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro na requisição");
            }

            return await Task.FromResult(contatos);

        }

    }
}
