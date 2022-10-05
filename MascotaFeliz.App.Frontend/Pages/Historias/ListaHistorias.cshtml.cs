using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListaHistoriasModel : PageModel
    {
        private readonly IRepositorioHistoria _repoHistoria; //IReposit... está en la Persistencia

        public IEnumerable<Historia> listaHistorias {get;set;} 

        public ListaHistoriasModel()
        {
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext()); //Igual que como se asignó en consola program.cs
        }

        public void OnGet() //Toma a listaHistorias y le envía lo que devuelve el llamado al metodo GetAllHistorias(), que está en Persistencia
        {
            listaHistorias = _repoHistoria.GetAllHistorias();
        }
    }
}
