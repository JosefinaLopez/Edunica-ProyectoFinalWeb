//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDUNICA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Leccion
    {
        public int Id { get; set; }
        public string NombreLeccion { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Completado { get; set; }
        public int CursoId { get; set; }
        public int ProgresoId { get; set; }
        public string Img { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual Progreso Progreso { get; set; }
    }
}
