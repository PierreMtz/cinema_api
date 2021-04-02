using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Modele
{
    public class Salle
    {
        [Key]
        public int Salle_ID { get; set; }
        public string Salle_Nom { get; set; }
        public int Nb_Places { get; set; }
        public int Nb_PlacesRestantes { get; set; }
    }
}
