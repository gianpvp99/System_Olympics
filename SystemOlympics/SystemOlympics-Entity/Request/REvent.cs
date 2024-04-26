using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOlympics_Entity.Request
{
    public class REvent
    {
        public int idUser { get; set; }
        public int option {  get; set; }
        public int idEvent { get; set; }
        public int idSportComplex {  get; set; }
        public string? name { get; set; }
        public int numberParticipant { get; set; }
        public int numberCommissar {  get; set; }
        public bool state {  get; set; }

    }
}
