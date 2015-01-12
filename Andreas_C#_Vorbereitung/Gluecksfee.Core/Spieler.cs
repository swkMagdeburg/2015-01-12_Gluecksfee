namespace Gluecksfee.Core
{
    public class Spieler
    {
        public Spieler(string vorname, string nachname)
        {
            Vorname = vorname;
            Nachname = nachname;
        }

        public string Vorname { get; private set; }
        public string Nachname { get; private set; }
    }
}