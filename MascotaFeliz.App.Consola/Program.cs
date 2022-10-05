using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno= new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // AddDueno();
            // AddVeterinario();
            // AddMascota();
            //GetVeterinario(2);
            //GetDueno(1);
            //GetMascota(1);
            //ListarDuenos(); //ok
            ListarMascotas(); //ok
            //ListarVeterinario(); // ok
            //UpdateVeterinario(2); //ok
            //UpdateDueno(5); //ok
            //UpdateMascota(4);
            //DeleteDueno(8);
            //DeleteVeterinario(9);
            //DeleteMascota(8);
            //GetDuenosPorFiltro("osc"); //la busqueda es case sensitive, pero si es parte del nombre lo listará (ej osc en oscar)
            //GetVeterinariosPorFiltro("Pepe");
            //GetMascotasPorFiltro("Jonas"); //ok
            AsignarVisitaPyP(3); //no probado
        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "oscar",
                Apellidos = "ben",
                Direccion = "Col",
                Telefono = "123",
                Correo = "oscar@gmail.com"
            };
            _repoDueno.AddDueno(dueno); // static para que no ocupe memoria a cada dueno - objeto. Si no, cada objeto se crea en memoria (una explicación light)
        }

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Nombres = "Pepe",
                Apellidos = "Cordero",
                Direccion = "Si",
                Telefono = "12345678",
                TarjetaProfesional = "CFR-8222"
            };
            _repoVeterinario.AddVeterinario(veterinario); // static para que no ocupe memoria a cada dueno - objeto. Si no, cada objeto se crea en memoria (una explicación light)
        }

        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Jonas",
                Color = "cafe con leche",
                Especie = "Felino",
                Raza = "comun"
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void GetDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
        }

        private static void GetVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
        }

        private static void GetMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
        }

        private static void ListarDuenos()
        {
            IEnumerable<Dueno> duenos = _repoDueno.GetAllDuenos();
            foreach (var dueno in duenos)
            {
                Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
            }
        }

        private static void ListarMascotas()
        {
            IEnumerable<Mascota> mascotas = _repoMascota.GetAllMascotas();
            foreach (var mascota in mascotas)
            {
                Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
            }
        }

        private static void ListarVeterinario()
        {
            IEnumerable<Veterinario> veterinarios = _repoVeterinario.GetAllVeterinarios();
            foreach (var veterinario in veterinarios)
            {
                Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
            }
        }


        private static void UpdateDueno(int id)
        {
            var dueno = new Dueno
            {
                Id = id,
                Nombres = "oscar ",
                Apellidos = "gil",
                Direccion = "Col",
                Telefono = "123",
                Correo = "oscar@gmail.com"
            };
            _repoDueno.UpdateDueno(dueno);
        }

        private static void UpdateVeterinario(int id)
        {
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Id = id,
                Nombres = "Peper",
                Apellidos = "Cordero",
                Direccion = "Nel",
                Telefono = "12345678",
                TarjetaProfesional = "CFR-8222"
            };
            _repoVeterinario.UpdateVeterinario(veterinario);
        }

        private static void UpdateMascota(int id)
        {
            var mascota = new Mascota
            {
                Id = id,
                Nombre = "Kira",
                Color = "cafe",
                Especie = "Canino",
                Raza = "beagle"
            };
            _repoMascota.UpdateMascota(mascota);
        }

        private static void DeleteDueno(int idDueno)
        {
            _repoDueno.DeleteDueno(idDueno);
            Console.WriteLine("Dueno borrado id: " + idDueno);
        }

        private static void DeleteVeterinario(int idVeterinario)
        {
            _repoVeterinario.DeleteVeterinario(idVeterinario);
            Console.WriteLine("Veterinario borrado id: " + idVeterinario);
        }

        private static void DeleteMascota(int idMascota)
        {
            _repoMascota.DeleteMascota(idMascota);
            Console.WriteLine("Mascota borrado id: " + idMascota);
        }

        private static void GetDuenosPorFiltro(string filtro)
        {
            IEnumerable<Dueno> duenosFiltrados = _repoDueno.GetDuenosPorFiltro(filtro);
            foreach (var dueno in duenosFiltrados)
            {
                Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
            }
        }

        private static void GetMascotasPorFiltro(string filtro)
        {
            IEnumerable<Mascota> mascotasFiltrados = _repoMascota.GetMascotasPorFiltro(filtro);
            foreach (var mascota in mascotasFiltrados)
            {
                Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
            }
        }

        private static void GetVeterinariosPorFiltro(string filtro)
        {
            IEnumerable<Veterinario> veterinariosFiltrados = _repoVeterinario.GetVeterinariosPorFiltro(filtro);
            foreach (var veterinario in veterinariosFiltrados)
            {
                Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
            }
        }

        private static void AsignarVeterinario() //permite asignar veterinario a mascota
        {
            var veterinario = _repoMascota.AsignarVeterinario(1, 15);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void AsignarVisitaPyP(int idHistoria)
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                if (historia.VisitasPyP != null) //IdVeterinario se refiere a CedulaVeterinario. FecuenciaRespiratoria quedó así en la entidad
                {
                    historia.VisitasPyP.Add(new VisitaPyP { FechaVisita = new DateTime(2022, 07, 01), Temperatura = 48.0F, Peso = 30.0F, FecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", IdVeterinario = 123, Recomendaciones = "Dieta extrema"});
                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>{
                        new VisitaPyP{FechaVisita = new DateTime(2021, 08, 08), Temperatura = 35.0F, Peso = 30.0F, FecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", IdVeterinario = 123, Recomendaciones = "Dieta extrema" }
                    };
                }
                _repoHistoria.UpdateHistoria(historia);
            }
        }
    }
}
