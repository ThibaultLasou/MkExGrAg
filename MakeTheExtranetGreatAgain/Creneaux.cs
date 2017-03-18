namespace MakeTheExtranetGreatAgain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Creneaux
    {
        [Key]
        [Column(Order = 0, TypeName = "datetime2")]
        public DateTime debut { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "datetime2")]
        public DateTime fin { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Salle { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Activite { get; set; }

        public virtual Activites Activites { get; set; }

        public virtual Salles Salles { get; set; }
    }
}
