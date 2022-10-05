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
    public class ListaVeterinariosModel : PageModel
    {
        private readonly IRepositorioVeterinario _repoVeterinario; //IReposit... está en la Persistencia

        public IEnumerable<Veterinario> listaVeterinarios {get;set;} 

        public ListaVeterinariosModel()
        {
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext()); //Igual que como se asignó en consola program.cs
        }

        public void OnGet() //Toma a listaDuenos y le envía lo que devuelve el llamado al metodo GetAllDuenos(), que está en Persistencia
        {
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
        }
    }
}
