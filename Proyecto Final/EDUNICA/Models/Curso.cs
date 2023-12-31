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
    
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            this.Leccions = new HashSet<Leccion>();
        }
    
        public int Id { get; set; }
        public string NombreCurso { get; set; }
        public long Presupuesto { get; set; }
        public int CategoriaId { get; set; }
        public int GradoId { get; set; }
        public int MaestroId { get; set; }
        public int ColaboracionId { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leccion> Leccions { get; set; }
        public virtual Grado Grado { get; set; }
        public virtual Maestro Maestro { get; set; }
        public virtual Colaboracion Colaboracion { get; set; }
    }
}
