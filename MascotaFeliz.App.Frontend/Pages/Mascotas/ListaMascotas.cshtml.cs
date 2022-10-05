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
    public class ListaMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota; //IReposit... está en la Persistencia

        public IEnumerable<Mascota> listaMascotas {get;set;} 

        public ListaMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext()); //Igual que como se asignó en consola program.cs
        }

        public void OnGet() //Toma a listaMascotas y le envía lo que devuelve el llamado al metodo GetAllMascotas(), que está en Persistencia
        {
            listaMascotas = _repoMascota.GetAllMascotas();
        }
    }
}
