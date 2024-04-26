using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOlympics_Entity.Request
{
    public class RSportComplex
    {
        public int idUser {  get; set; }
        public int option {  get; set; }


        public int idSportComplex { get; set; }
        public int idCampusOlympic { get; set; }
        public int idTypeSportComplex { get; set; }
        public string? name { get; set; }
        public string? bossOrganization { get; set; }
        public string? totalArea { get; set; }
        public bool state { get; set; }
    }
}
