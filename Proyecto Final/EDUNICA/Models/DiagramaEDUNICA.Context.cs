﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DiagramaEDUNICAContainer : DbContext
    {
        public DiagramaEDUNICAContainer()
            : base("name=DiagramaEDUNICAContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Grado> Grados { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Progreso> Progresos { get; set; }
        public virtual DbSet<Colaboracion> Colaboraciones { get; set; }
        public virtual DbSet<Maestro> Maestros { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<InteresesCategoria> InteresesCategorias { get; set; }
        public virtual DbSet<Leccion> Lecciones { get; set; }
    }
}
