using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOlympics_Entity.Request
{
    public class RUser
    {
        public int idUser { get; set; }
        public int idUserDelete {  get; set; }
        public string user {  get; set; }
        public string password {  get; set; }
        public string nroDocument { get; set; }
        public string name {  get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool state {  get; set; }
        public int idUserModification { get; set; }
        public int option {  get; set; }
    }
}
