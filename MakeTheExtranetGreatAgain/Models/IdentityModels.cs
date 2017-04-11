using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakeTheExtranetGreatAgain.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant plus de propriétés à votre classe ApplicationUser ; consultez http://go.microsoft.com/fwlink/?LinkID=317594 pour en savoir davantage.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Groupes> Groupes { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Activites> Activites { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Cours> Cours { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Creneaux> Creneaux { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Doc_Web> Doc_Web { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Individus> Individus { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Messages> Messages { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Options_Questionnaire> Options_Questionnaire { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Questionnaires> Questionnaires { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Types_Questionnaire> Types_Questionnaire { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Salles> Salles { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Sous_doc_Web> Sous_doc_Web { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Statut> Statuts { get; set; }

        public System.Data.Entity.DbSet<MakeTheExtranetGreatAgain.Tâches> Tâches { get; set; }
    }
}