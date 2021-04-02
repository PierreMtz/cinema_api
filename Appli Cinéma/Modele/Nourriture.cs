using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Modele
{
    public class Nourriture
    {
        [Key]
        public int Nourriture_ID { get; set; }
        public string Nourriture_Nom { get; set; }
        public int Nourriture_Prix { get; set; }
        

    }
}
