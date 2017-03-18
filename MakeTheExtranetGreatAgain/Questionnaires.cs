namespace MakeTheExtranetGreatAgain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Questionnaires
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Id_message { get; set; }

        public int Id_Option { get; set; }

        [Required]
        [StringLength(15)]
        public string type { get; set; }

        public virtual Messages Messages { get; set; }

        public virtual Options_Questionnaire Options_Questionnaire { get; set; }

        public virtual Types_Questionnaire Types_Questionnaire { get; set; }
    }
}
