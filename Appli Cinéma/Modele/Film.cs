using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Modele
{
    public class Film
    {
        [Key]
        public int Film_ID { get; set; }
        public int TypeFilm_ID { get; set; }
        public string Film_Description { get; set; }
        public string Film_Horraires { get; set; }
        public string Film_Durée { get; set; }
        public string Film_Nom { get; set; }
        public string TypeFilm_Nom { get; set; }
        public int Salle_ID { get; set; }
        [ForeignKey("Salle_ID")]
        public Salle Salle { get; set; }
        public string Image{ get; set; }
    }
}
