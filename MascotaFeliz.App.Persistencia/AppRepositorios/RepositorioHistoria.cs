using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria //RepositorioDueno implementa la interface IRepo...
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
        
        public RepositorioHistoria(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Historia AddHistoria(Historia historia)
        {
            var historiaAdicionado = _appContext.Historias.Add(historia); //Duenos es el dbset ubicado en appContext. 
            _appContext.SaveChanges();
            return historiaAdicionado.Entity; //Devuelve un dueno
        }

        public Historia GetHistoria(int idHistoria)
        {
            return _appContext.Historias.Include("VisitasPyP").FirstOrDefault(h => h.Id == idHistoria);
        }

        public Historia UpdateHistoria(Historia historia)
        {
            var historiaEncontrado = _appContext.Historias.FirstOrDefault(h => h.Id == historia.Id);
            if (historiaEncontrado != null)
            {
                historiaEncontrado.FechaInicial = historia.FechaInicial;
                historiaEncontrado.VisitasPyP = historia.VisitasPyP;
                _appContext.SaveChanges();
            }
            return historiaEncontrado;

        }

        public Dueno UpdateDueno(Dueno dueno)
        {
            var duenoEncontrado = _appContext.Duenos.FirstOrDefault(d => d.Id == dueno.Id); // para cada item de Duenos, extrae el id y compara con el dueno.Id que llega en la argunmento de la funcion
            Console.WriteLine("repo Dueno id: "+dueno.Id);
            if (duenoEncontrado != null)
            {
                duenoEncontrado.Nombres = dueno.Nombres;
                duenoEncontrado.Apellidos = dueno.Apellidos;
                duenoEncontrado.Direccion = dueno.Direccion;
                duenoEncontrado.Telefono = dueno.Telefono;
                duenoEncontrado.Correo = dueno.Correo;
                _appContext.SaveChanges();
            }
            return duenoEncontrado;
        }     

        public IEnumerable<Historia> GetAllHistorias()
        {
            return GetAllHistorias_();
        }

        public IEnumerable<Historia> GetAllHistorias_()
        {
            //return _appContext.Mascotas;
            return _appContext.Historias.Include("VisitasPyP");
        }

        public VisitaPyP AsignarVisitaPyP(int idHistoria, int idVisitaPyP)
        {
            var historiaEncontrado = _appContext.Historias.FirstOrDefault(m => m.Id == idHistoria);
            if (historiaEncontrado != null)
            {
                var visitaEncontrado = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisitaPyP); //likely a List<VisitaPyP>
                if (visitaEncontrado != null)
                {
                    historiaEncontrado.VisitasPyP.Add(visitaEncontrado);
                    _appContext.SaveChanges();
                }
                return visitaEncontrado;
            }
            return null;
        }
        
        
    }
}