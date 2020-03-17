using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace Prova_WebAPI.Controllers
{
    public class ContatoController : ApiController
    {

        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody] Models.Contato contato)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                
                if (contato == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                    response.Content = new StringContent("Não encontrado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                }


            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return await Task.FromResult(response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Models.Contato contato)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                if (contato == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                    response.Content = new StringContent("Não encontrado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                }


            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return await Task.FromResult(response);
        }


        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int idContato)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                if (idContato == 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                    response.Content = new StringContent("Não encontrado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                }


            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return await Task.FromResult(response);
        }




        [HttpGet]
        public async Task<HttpResponseMessage> Get(int page=0, int size=10)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                var contato = await new Negocio.Contato().GetAll(page,size);
                if (contato == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound);
                    response.Content = new StringContent("Não encontrado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");
                }


            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(ex.ToString(), Encoding.UTF8, "application/json");
            }

            return await Task.FromResult(response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(int idContato)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try {

                var contato = await new Negocio.Contato().Get(idContato);
                if (contato == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound);
                    response.Content = new StringContent("Não encontrado -- entre com valor de 1 a 10", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");
                }
                    

            }
            catch (Exception ex) {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(ex.ToString(), Encoding.UTF8, "application/json");
            }

            return await Task.FromResult(response);
        }


    }
}
