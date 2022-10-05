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
    public class ListaDuenosModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno; //IReposit... está en la Persistencia

        public IEnumerable<Dueno> listaDuenos {get;set;} 

        public ListaDuenosModel()
        {
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext()); //Igual que como se asignó en consola program.cs
        }

        public void OnGet() //Toma a listaDuenos y le envía lo que devuelve el llamado al metodo GetAllDuenos(), que está en Persistencia
        {
            listaDuenos = _repoDueno.GetAllDuenos();
        }
    }
}
