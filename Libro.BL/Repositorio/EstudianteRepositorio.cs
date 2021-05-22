
using LibroBL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibroBL.Repositorio
{
    public class EstudianteRepositorio
    {
        private readonly string url = "https://localhost:44398/api/Estudiante/";
        public EstudianteRepositorio()
        {
        }

        public async Task<List<Estudiante>> GetEstudiante()
        {
            List<Estudiante> colEstudiantes = new List<Estudiante>();
            using (HttpClient http = new HttpClient())
            {
                var response = await http.GetStringAsync(url);
                colEstudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(response);
            }

            return colEstudiantes;
        }


        public async Task<Estudiante> GetEstudiante(int id)
        {
            Estudiante estudiante = new Estudiante();

            using (HttpClient http = new HttpClient())
            {
                var response = await http.GetStringAsync(url + $"{id}");
                estudiante = JsonConvert.DeserializeObject<Estudiante>(response);
            };

            return estudiante;
        }
        public async void Agregar(UsuarioEstudiante _estudiante)
        {
            Estudiante est = new Estudiante();
            est.Nombre = _estudiante.Nombre;
            est.Apellido = _estudiante.Apellido;
            est.FechaNacimiento = _estudiante.FechaNacimiento;

            Usuario usu = new Usuario();
            usu.Pass = _estudiante.Pass;
            usu.NombreUsuario = _estudiante.Usuario;
            usu.Tipo = "Estudiante";

            using (HttpClient http = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(est);
                var byteContent = new StringContent(myContent);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await http.PostAsync(url, byteContent);
            };
        }

        public Estudiante GetEstudianteByUserID(int id)
        {
            Estudiante estudiante = new Estudiante();

            using (BibliotecaContext context = new BibliotecaContext())
            {
                estudiante = context.Estudiantes.Where(w => w.Idusuario == id).FirstOrDefault();
            };

            return estudiante;
        }

        public async void EditSend(Estudiante estudiante)
        {
            using (HttpClient http = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(estudiante);
                var byteContent = new StringContent(myContent);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await http.PutAsync(url + estudiante.NumeroEstudiante, byteContent);
            };
        }

        public void Remove(int id)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DeleteAsync(url + id);
            }

        }

    }
}
