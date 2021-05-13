
using LibroBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroBL.Repositorio
{
    public class EstudianteRepositorio
    {
        public EstudianteRepositorio()
        {
        }

        public List<Estudiante> GetEstudiantes()
        {
            List<Estudiante> colEstudiantes = new List<Estudiante>();
            using (BibliotecaContext context = new BibliotecaContext())
            {
                colEstudiantes = context.Estudiantes.ToList();
            }
            return colEstudiantes;
        }

        public void Agregar(UsuarioEstudiante _estudiante)
        {
            Estudiante est = new Estudiante();
            est.Nombre = _estudiante.Nombre;
            est.Apellido = _estudiante.Apellido;
            est.FechaNacimiento = _estudiante.FechaNacimiento;

            Usuario usu = new Usuario();
            usu.Pass = _estudiante.Pass;
            usu.NombreUsuario = _estudiante.Usuario;
            usu.Tipo = "Estudiante";

            using (BibliotecaContext context = new BibliotecaContext())
            {
                context.Usuarios.Add(usu);

                est.Usuario = usu;
                context.Estudiantes.Add(est);

                context.SaveChanges();

            };
        }

        public Estudiante GetEstudiante(int id)
        {
            Estudiante estudiante = new Estudiante();

            using (BibliotecaContext context = new BibliotecaContext())
            {
                estudiante = context.Estudiantes.Where(w => w.Idusuario == id).FirstOrDefault();
            };

            return estudiante;
        }

        public void EditSend(Estudiante estudiante)
        {
            using (BibliotecaContext context = new BibliotecaContext())
            {
                Estudiante Hestudiante = context.Estudiantes.Where(w => w.NumeroEstudiante == estudiante.NumeroEstudiante).FirstOrDefault();
                Hestudiante.Nombre = estudiante.Nombre;
                Hestudiante.Apellido = estudiante.Apellido;
                Hestudiante.FechaNacimiento = estudiante.FechaNacimiento;

                context.SaveChanges();
            };
        }

        public void Remove(int id)
        {
            using (BibliotecaContext context = new BibliotecaContext())
            {
                Estudiante estudiante = context.Estudiantes.Where(w => w.NumeroEstudiante == id).FirstOrDefault();
                context.Estudiantes.Remove(estudiante);

                if (estudiante.Idusuario != null)
                {
                    Usuario usuario = context.Usuarios.Find(estudiante.Idusuario);
                    context.Usuarios.Remove(usuario);
                }

                context.SaveChanges();
            };
        }

    }
}
