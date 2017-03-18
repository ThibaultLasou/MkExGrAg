namespace MakeTheExtranetGreatAgain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class appl : DbContext
    {
        public appl()
            : base("name=appl")
        {
        }

        public virtual DbSet<Activites> Activites { get; set; }
        public virtual DbSet<Cours> Cours { get; set; }
        public virtual DbSet<Doc_Web> Doc_Web { get; set; }
        public virtual DbSet<Groupes> Groupes { get; set; }
        public virtual DbSet<Individus> Individus { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Options_Questionnaire> Options_Questionnaire { get; set; }
        public virtual DbSet<Questionnaires> Questionnaires { get; set; }
        public virtual DbSet<Salles> Salles { get; set; }
        public virtual DbSet<Sous_doc_Web> Sous_doc_Web { get; set; }
        public virtual DbSet<Statut> Statut { get; set; }
        public virtual DbSet<Tâches> Tâches { get; set; }
        public virtual DbSet<Types_Questionnaire> Types_Questionnaire { get; set; }
        public virtual DbSet<Creneaux> Creneaux { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activites>()
                .HasMany(e => e.Creneaux)
                .WithRequired(e => e.Activites)
                .HasForeignKey(e => e.Id_Activite)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Activites)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.Id_cours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doc_Web>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Doc_Web>()
                .HasMany(e => e.Individus)
                .WithMany(e => e.Doc_Web)
                .Map(m => m.ToTable("Auteur_Doc").MapLeftKey("Id_Doc").MapRightKey("Id_individu"));

            modelBuilder.Entity<Doc_Web>()
                .HasMany(e => e.Groupes)
                .WithMany(e => e.Doc_Web)
                .Map(m => m.ToTable("Document_Groupe").MapLeftKey("Id_Document").MapRightKey("Id_groupe"));

            modelBuilder.Entity<Groupes>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Groupes>()
                .HasMany(e => e.Cours)
                .WithRequired(e => e.Groupes)
                .HasForeignKey(e => e.Id_groupe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groupes>()
                .HasMany(e => e.Individus)
                .WithMany(e => e.Groupes)
                .Map(m => m.ToTable("Appartenances").MapLeftKey("Id_groupe").MapRightKey("Id_individu"));

            modelBuilder.Entity<Groupes>()
                .HasMany(e => e.Messages)
                .WithMany(e => e.Groupes)
                .Map(m => m.ToTable("Notifications_Diffusions").MapLeftKey("Id_groupe").MapRightKey("Id_message"));

            modelBuilder.Entity<Groupes>()
                .HasMany(e => e.Individus1)
                .WithMany(e => e.Groupes1)
                .Map(m => m.ToTable("Responsables_groupe").MapLeftKey("Id_groupe").MapRightKey("Id_individu"));

            modelBuilder.Entity<Individus>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Individus>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Individus>()
                .HasMany(e => e.Cours)
                .WithRequired(e => e.Individus)
                .HasForeignKey(e => e.Id_prof)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Individus>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Individus)
                .HasForeignKey(e => e.Id_expediteur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Individus>()
                .HasMany(e => e.Messages1)
                .WithMany(e => e.Individus1)
                .Map(m => m.ToTable("Notifications_simples").MapLeftKey("Id_individu").MapRightKey("Id_message"));

            modelBuilder.Entity<Individus>()
                .HasMany(e => e.Statut)
                .WithMany(e => e.Individus)
                .Map(m => m.ToTable("Statut_Individu").MapLeftKey("Id_individu").MapRightKey("Id_statut"));

            modelBuilder.Entity<Messages>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<Messages>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.Messages)
                .HasForeignKey(e => e.Id_message)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Options_Questionnaire>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.Options_Questionnaire)
                .HasForeignKey(e => e.Id_Option)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questionnaires>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Salles>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Salles>()
                .HasMany(e => e.Creneaux)
                .WithRequired(e => e.Salles)
                .HasForeignKey(e => e.Id_Salle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sous_doc_Web>()
                .Property(e => e.contenu_html)
                .IsUnicode(false);

            modelBuilder.Entity<Sous_doc_Web>()
                .HasMany(e => e.Doc_Web)
                .WithRequired(e => e.Sous_doc_Web)
                .HasForeignKey(e => e.Id_contenu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statut>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Types_Questionnaire>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Types_Questionnaire>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.Types_Questionnaire)
                .WillCascadeOnDelete(false);
        }
    }
}
