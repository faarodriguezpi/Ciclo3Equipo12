using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        IEnumerable<Historia> GetAllHistorias();
        Historia AddHistoria(Historia historia);
        Historia UpdateHistoria(Historia historia);
        //void DeleteDueno(int idDueno);
        Historia GetHistoria(int idHistoria);
        //IEnumerable<Dueno> GetDuenosPorFiltro(string filtro);
        VisitaPyP AsignarVisitaPyP(int idHistoria, int idVisitaPyP);
    }
}