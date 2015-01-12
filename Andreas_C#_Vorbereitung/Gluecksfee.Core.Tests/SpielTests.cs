using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gluecksfee.Core.Tests
{
    [TestClass]
    public class SpielTests
    {
        [TestMethod]
        public void SetzteGewinnerAufHeimspieler_SollteGewinnerUndVerliererRichtigSetzen()
        {
            // Arrange
            var sut = new Spiel(new Spieler("Uma", "Thurman"), new Spieler("Juliette", "Lewis"));

            // Act
            sut.SetzeGewinnerAufHeimspieler();

            // Assert
            Assert.AreEqual(sut.HeimSpieler, sut.Gewinner);
            Assert.AreEqual(sut.GastSpieler, sut.Verlierer);
        }

        [TestMethod]
        public void SetzteGewinnerAufGastspieler_SollteGewinnerUndVerliererRichtigSetzen()
        {
            // Arrange
            var sut = new Spiel(new Spieler("Harvei", "Keitel"), new Spieler("Samuel", "Jackson"));

            // Act
            sut.SetzeGewinnerAufGastspieler();

            // Assert
            Assert.AreEqual(sut.GastSpieler, sut.Gewinner);
            Assert.AreEqual(sut.HeimSpieler, sut.Verlierer);
        }
    }
}