using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Modele
{
    public class Client
    {
        [Key]
        public int Client_ID { get; set; }
        public string Client_Nom { get; set; }
        public int Client_Age { get; set; }

        public List<ReservationFilm> ReservationFilms { get; set; }
        public List<ReservationNourriture> ReservationNourritures{ get; set; }
    }
}
