using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Modele
{
    public class ReservationNourriture
    {
        [Key]
        public int ReservationB_ID { get; set; }
        public int Client_ID { get; set; }
        [ForeignKey("Client_ID")]
        public Client client { get; set; }

        public int Film_ID { get; set; }
        [ForeignKey("Film_ID")]
        public Film film { get; set; }
    }
}
