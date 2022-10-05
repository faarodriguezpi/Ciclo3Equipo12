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
    public class DetallesHistoriasModel : PageModel
    {
        private readonly IRepositorioHistoria _repoHistoria; //IReposit... está en la Persistencia

        public Historia historia {get;set;}

        public string idVisita {get;set;}
        //public string nombreDueno {get;set;}

        public DetallesHistoriasModel()
        {
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int historiaId) //ese historiaId no se puede cambiar porque así viene desde ListaDuenos
        {
            historia = _repoHistoria.GetHistoria(historiaId);
            
            
            if (historia == null)
            {
                return RedirectToPage("./NotFound");
            } 
            else
            {
                if (historia.VisitasPyP == null)
                {
                    idVisita = "null";
                }
                                                
                return Page();
            }
        }
    }
}
