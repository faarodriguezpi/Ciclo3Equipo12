using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario//RepositorioVeteri... implementa la interface IRepo...
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext; // readonly variable, can be assigned only while being instantiated or in a constructor
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Veterinario AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.Veterinarios.Add(veterinario); //Duenos es el dbset ubicado en appContext. 
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity; //Devuelve un dueno
        }

        public Veterinario GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return GetAllVeterinarios_();
        }

        public IEnumerable<Veterinario> GetAllVeterinarios_()
        {
            return _appContext.Veterinarios;
        }

        public Veterinario UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == veterinario.Id);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombres = veterinario.Nombres;
                veterinarioEncontrado.Apellidos = veterinario.Apellidos;
                veterinarioEncontrado.Direccion = veterinario.Direccion;
                veterinarioEncontrado.Telefono = veterinario.Telefono;
                veterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;
                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }

        public void DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == idVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Veterinario> GetVeterinariosPorFiltro(string filtro) //filtrar por nombre mascota
        {
            var veterinarios = GetAllVeterinarios(); // Obtiene todos los saludos
            if (veterinarios != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    veterinarios = veterinarios.Where(s => s.Nombres.Contains(filtro));
                }
            }
            return veterinarios;
        }
    }
}