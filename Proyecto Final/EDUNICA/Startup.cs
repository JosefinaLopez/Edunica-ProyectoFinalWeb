using EDUNICA.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(EDUNICA.Startup))]
namespace EDUNICA
{
    public partial class Startup
    {
        public static void AgregarRolesUsuario()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Rol Administrador
                    if (!ManejadorRol.RoleExists("admin"))
                    {
                        var rolAdmin = new IdentityRole { Name = "admin" };
                        ManejadorRol.Create(rolAdmin);

                        var userAdmin = new ApplicationUser
                        {
                            UserName = "Josefinalopez59@gmail.com",
                            Email = "Josefinalopez59@gmail.com"
                        };

                        string pwdAdmin = "123456789";
                        var verificarAdmin = ManejadorUsuario.Create(userAdmin, pwdAdmin);

                        if (verificarAdmin.Succeeded)
                        {
                            var resultAdmin = ManejadorUsuario.AddToRole(userAdmin.Id, "admin");
                            if (!resultAdmin.Succeeded)
                            {
                                // Manejar el error, posiblemente revertir la transacción
                            }
                        }
                    }

                    // Rol Estudiante
                    if (!ManejadorRol.RoleExists("alumno"))
                    {
                        var rolEstudiante = new IdentityRole { Name = "alumno" };
                        ManejadorRol.Create(rolEstudiante);

                        var userEstudiante = new ApplicationUser
                        {
                            UserName = "RodrigoLopez92@gmail.com",
                            Email = "RodrigoLopez92@gmail.com"
                        };

                        string pwdEstudiante = "12345678";
                        var verificarEstudiante = ManejadorUsuario.Create(userEstudiante, pwdEstudiante);

                        if (verificarEstudiante.Succeeded)
                        {
                            var resultEstudiante = ManejadorUsuario.AddToRole(userEstudiante.Id, "alumno");
                            if (!resultEstudiante.Succeeded)
                            {
                                // Manejar el error, posiblemente revertir la transacción
                            }
                        }
                    }

                    // Rol Docente
                    if (!ManejadorRol.RoleExists("profesor"))
                    {
                        var rolProfesor = new IdentityRole { Name = "profesor" };
                        ManejadorRol.Create(rolProfesor);

                        var userProfesor = new ApplicationUser
                        {
                            UserName = "Robertosolis@docent.unan.edu.ni",
                            Email = "Robertosolis@docent.unan.edu.ni"
                        };

                        string pwdProfesor = "1234567";
                        var verificarProfesor = ManejadorUsuario.Create(userProfesor, pwdProfesor);

                        if (verificarProfesor.Succeeded)
                        {
                            var resultProfesor = ManejadorUsuario.AddToRole(userProfesor.Id, "profesor");
                            if (!resultProfesor.Succeeded)
                            {
                                // Manejar el error, posiblemente revertir la transacción
                            }
                        }
                    }

                    transaction.Commit();  // Coenfirmar la transacción si todo ha tenido éxito
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    // Manejar la excepción, posiblemente revertir la transacción
                    transaction.Rollback();
                }
            }
        }
        public static void Eliminar()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                // Eliminar roles existentes
                var roles = roleManager.Roles.ToList();
                foreach (var role in roles)
                {
                    roleManager.Delete(role);
                }
            }
            using (var context = new ApplicationDbContext())
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                // Eliminar usuarios existentes
                var users = userManager.Users.ToList();
                foreach (var user in users)
                {
                    userManager.Delete(user);
                }
            }

        }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Eliminar();
            AgregarRolesUsuario();
        }
    }
}
