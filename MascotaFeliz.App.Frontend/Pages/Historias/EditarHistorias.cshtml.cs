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
    public class EditarHistoriasModel : PageModel
    {
        private readonly IRepositorioHistoria _repoHistoria;
        //
        //private readonly IRepositorioVisitaPyP _repoDueno;

        [BindProperty]

        public Historia historia {get; set;}

        public VisitaPyP visitaPyP {get; set;}

        public int indexListVisitaPyP {get; set;}

        //para recibir las listas con duenos y veterinarios
        public IEnumerable<VisitaPyP> listaVisitaPyP {get; set;}

        public EditarHistoriasModel()
        {
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            //this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? historiaId) //pregunta si ha llegado un parámetro. Se ejecuta cuando ingreso a la página
        {
            //listaVvisitas... = _repoVeterinario.GetAllVeterinarios();
            Console.WriteLine("askdaksd");
            if (historiaId.HasValue)
            {
                historia = _repoHistoria.GetHistoria(historiaId.Value);
            }
            else
            {
                historia = new Historia();
            }

            if (historia == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page(); //pinta la página.
        }

        public IActionResult OnPost(Historia historia, int visitaPyPId) // se ejecuta cuando doy Grabar 8es un boton de tipo submit - el formulario es de tipo post
        {
            if (ModelState.IsValid)
            {
                //dueno = _repoDueno.GetDueno(duenoId);
                //veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                Console.WriteLine("visitaPyPId" + visitaPyPId);
                Console.WriteLine("indexListVisitaPyP" + indexListVisitaPyP);
                if (historia.Id > 0) //se está haciendo actualización
                {
                    //mascota.Veterinario = veterinario;
                    //mascota.Dueno = dueno;
                    historia = _repoHistoria.UpdateHistoria(historia);
                }
                else //se agrega una nueva mascota y sus asignaciones (dueno y veterinario)
                {
                    historia = _repoHistoria.AddHistoria(historia);
                    //_repoMascota.AsignarDueno(mascota.Id, dueno.Id);
                    //_repoMascota.AsignarVeterinario(mascota.Id, veterinario.Id);
                }
                return RedirectToPage("/Historias/ListaHistorias"); //al terminar de grabar redirecciona a Lista de mascotas
            }
            else
            {
                return Page();
            }
        }
    }
}
