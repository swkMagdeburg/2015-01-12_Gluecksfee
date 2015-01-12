using System.Collections.Generic;

using Gluecksfee.Core;

namespace Gluecksfee.Infrastructure
{
    public class SpielerRepository : ISpielerRepository
    {
        private readonly List<Spieler> _spieler;

        public SpielerRepository()
        {
            _spieler = new List<Spieler>
            {
                new Spieler("Quentin", "Tarantino"),
                new Spieler("Uma", "Thurman"),
                new Spieler("Samuel", "Jackson"),
                new Spieler("Harvery", "Keitel"),
                new Spieler("Selma", "Hayek"),
                new Spieler("Juliette", "Lewis"),
                new Spieler("Danny", "Trejo")
            };
        }

        public IEnumerable<Spieler> Spieler
        {
            get { return _spieler; }
        }

        public void Entferne(Spieler verlierer)
        {
            _spieler.Remove(verlierer);
        }
    }
}