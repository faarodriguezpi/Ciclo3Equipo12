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
    public class DetallesMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota; //IReposit... está en la Persistencia

        public Mascota mascota {get;set;}

        public string nombreVeterinario {get;set;}
        public string nombreDueno {get;set;}

        public DetallesMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int mascotaId) //ese mascotaId no se puede cambiar porque así viene desde ListaDuenos
        {
            mascota = _repoMascota.GetMascota(mascotaId);
            
            
            if (mascota == null)
            {
                return RedirectToPage("./NotFound");
            } 
            else
            {
                if (mascota.Veterinario == null)
                {
                    nombreVeterinario = "null";
                }
                else
                {
                    nombreVeterinario = mascota.Veterinario.Nombres;
                }
                if (mascota.Dueno == null)
                {
                    nombreDueno = "null";
                }
                else
                {
                    nombreDueno = mascota.Dueno.Nombres;
                }
                
                return Page();
            }
        }
    }
}
