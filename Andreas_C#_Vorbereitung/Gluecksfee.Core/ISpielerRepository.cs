using System.Collections.Generic;

namespace Gluecksfee.Core
{
    public interface ISpielerRepository
    {
        IEnumerable<Spieler> Spieler { get; }
        void Entferne(Spieler verlierer);
    }
}