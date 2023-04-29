using ApplicationEventos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.Http;

namespace ApplicationEventos.Controllers
{
    public class EventoController : Controller
    {
        string BaseUrl = "";
        private readonly IConfiguration _configuration;

        public EventoController(IConfiguration configuration)
        {
            _configuration = configuration;
            BaseUrl = _configuration.GetValue<string>("WebApi");
        }
        public async Task<IActionResult> Index()
        {
            List <Eventos> EventosGetAll = new List<Eventos>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Evento/");
                if (Res.IsSuccessStatusCode)
                {
                    var _ClientResponse = Res.Content.ReadAsStringAsync().Result;
                    EventosGetAll = JsonConvert.DeserializeObject<List<Eventos>>(_ClientResponse);

                }
            }

            return View(EventosGetAll);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Eventos evento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var postTask = client.PostAsJsonAsync<Eventos>("api/Evento/", evento);
                postTask.Wait();

                var resut = postTask.Result;

                if (resut.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error, contactar al administrador.");
            return View(evento);
        }

        // GET: Evento/Create
        public async Task  <IActionResult> Edit(int id)
        {
             Eventos EventosGetAll = new Eventos();
            try { 
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync($"https://localhost:7242/api/Evento/{id}");
                    if (Res.IsSuccessStatusCode)
                    {
                        var _ClientResponse = Res.Content.ReadAsStringAsync().Result;
                        EventosGetAll = JsonConvert.DeserializeObject<Eventos>(_ClientResponse);
                        return View(EventosGetAll);
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        //[Route("Evento/Edit/{id}/{Fecha}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Lugar, Descripcion, Fecha, Nroentrada, Precio, Estado, EstadoDesc")] Eventos evento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //var putTask = client.PutAsync($"api/Evento/{evento.Id}", content);
                var fechaQuery = evento.Fecha.ToString("dd-MM-yyyy");
                var putTask = client.PutAsync($"api/Evento/{evento.Id}/{fechaQuery}", null);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error, contactar al administrador.");
            return View(evento);
        }

        [HttpGet]
        [Route("Evento/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Eventos EventosGetAll = new Eventos();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync($"https://localhost:7242/api/Evento/{id}");
                    if (Res.IsSuccessStatusCode)
                    {
                        var _ClientResponse = Res.Content.ReadAsStringAsync().Result;
                        EventosGetAll = JsonConvert.DeserializeObject<Eventos>(_ClientResponse);
                        return View(EventosGetAll);
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Evento/Delete/{id}")]
        public async Task<IActionResult> Delete(int id, [Bind("Id, Lugar, Descripcion, Fecha, Nroentrada, Precio, Estado, EstadoDesc")] Eventos evento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //var putTask = client.PutAsync($"api/Evento/{evento.Id}", content);
                var fechaQuery = evento.Fecha.ToString("dd-MM-yyyy");
                var putTask = client.DeleteAsync ($"api/Evento/{evento.Id}");
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error, contactar al administrador.");
            return View(evento);
        }

        [HttpGet]
        [Route("Evento/Detalles/{id}")]
        public async Task<IActionResult> Detalles(int id)
        {
            Eventos EventosGetAll = new Eventos();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync($"https://localhost:7242/api/Evento/{id}");
                    if (Res.IsSuccessStatusCode)
                    {
                        var _ClientResponse = Res.Content.ReadAsStringAsync().Result;
                        EventosGetAll = JsonConvert.DeserializeObject<Eventos>(_ClientResponse);
                        return View(EventosGetAll);
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
