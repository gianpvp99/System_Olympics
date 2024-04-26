namespace SystemOlympics_Entity
{
    public class ELogin
    {
        public string? message { get; set; }
        public string? token { get; set; }
        public int Rstate { get; set; }
        public string? user { get; set; }
        public string? password { get; set; }

        public int idUser { get; set; }
        public int idUserDelete { get; set; }
        public string nroDocument { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int option { get; set; }
        public DateTime dateCreate { get; set; }
        public DateTime dateModification { get; set; }
        public int idUserModification { get; set; }
    }
}
