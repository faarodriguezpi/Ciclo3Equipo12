using System;
namespace MascotaFeliz.App.Dominio
{
    public class Persona
    {

        public int Id {get;set;} // propiedades (como atributos, pero también con los métodos). Así se encapsulan los atributos de la clase

        public string Nombres {get;set;}

        public string Apellidos {get;set;}

        public string Telefono {get;set;}

        public string Direccion {get;set;}
    }
}