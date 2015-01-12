namespace Gluecksfee.Core
{
    public class Spiel
    {
        public Spiel(Spieler heimSpieler, Spieler gastSpieler)
        {
            HeimSpieler = heimSpieler;
            GastSpieler = gastSpieler;
        }

        public Spieler HeimSpieler { get; private set; }
        public Spieler GastSpieler { get; private set; }
        public Spieler Gewinner { get; private set; }
        public Spieler Verlierer { get; private set; }

        public void SetzeGewinnerAufHeimspieler()
        {
            Gewinner = HeimSpieler;
            Verlierer = GastSpieler;
        }

        public void SetzeGewinnerAufGastspieler()
        {
            Gewinner = GastSpieler;
            Verlierer = HeimSpieler;
        }
    }
}