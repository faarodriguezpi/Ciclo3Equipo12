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
    public class EditarMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        //Veterinario y Dueno agregados para ser asignados en la creación o edicion de una Mascota
        private readonly IRepositorioDueno _repoDueno;

        private readonly IRepositorioVeterinario _repoVeterinario;
        [BindProperty]

        public Mascota mascota {get; set;}

        public Veterinario veterinario {get; set;}

        public Dueno dueno {get; set;}

        //para recibir las listas con duenos y veterinarios
        public IEnumerable<Dueno> listaDuenos {get; set;}

        public IEnumerable<Veterinario> listaVeterinarios {get; set;}

        public EditarMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? mascotaId) //pregunta si ha llegado un parámetro. Se ejecuta cuando ingreso a la página
        {
            listaDuenos = _repoDueno.GetAllDuenos();
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
            
            if (mascotaId.HasValue)
            {
                mascota = _repoMascota.GetMascota(mascotaId.Value);
            }
            else
            {
                mascota = new Mascota();
            }

            if (mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page(); //pinta la página.
        }

        public IActionResult OnPost(Mascota mascota, int duenoId, int veterinarioId) // se ejecuta cuando doy Grabar 8es un boton de tipo submit - el formulario es de tipo post
        {
            if (ModelState.IsValid)
            {
                dueno = _repoDueno.GetDueno(duenoId);
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                
                if (mascota.Id > 0) //se está haciendo actualización
                {
                    mascota.Veterinario = veterinario;
                    mascota.Dueno = dueno;
                    mascota = _repoMascota.UpdateMascota(mascota);
                }
                else //se agrega una nueva mascota y sus asignaciones (dueno y veterinario)
                {
                    mascota = _repoMascota.AddMascota(mascota);
                    _repoMascota.AsignarDueno(mascota.Id, dueno.Id);
                    _repoMascota.AsignarVeterinario(mascota.Id, veterinario.Id);
                }
                return RedirectToPage("/Mascotas/ListaMascotas"); //al terminar de grabar redirecciona a Lista de mascotas
            }
            else
            {
                return Page();
            }
        }
    }
}
