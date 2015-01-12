using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gluecksfee.Core.Tests.ErmittleGewinnerViewModelTests
{
    [TestClass]
    public class SimuliereSpieleTests
    {
        private ErmittleGewinnerViewModel _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new ErmittleGewinnerViewModel(null);
        }

        [TestMethod]
        public void SimuliereSpiele_CanExecuteSollteFalseSeinWennNochKeineSpieleAusgelostSind()
        {
            // Arrange

            // Act
            var canExecute = _sut.SimuliereSpiele.CanExecute(null);

            // Assert
            Assert.IsFalse(canExecute);
        }

        [TestMethod]
        public void SimuliereSpiele_CanExecuteSollteTrueSeinWennSpieleAusgelostSind()
        {
            // Arrange
            _sut.Spiele.Add(new Spiel(new Spieler("Uma", "Thurman"), new Spieler("Quentin", "Tarantino")));
            _sut.Spiele.Add(new Spiel(new Spieler("Samuel", "Jakson"), new Spieler("Harvey", "Keitel")));

            // Act
            var canExecute = _sut.SimuliereSpiele.CanExecute(null);

            // Assert
            Assert.IsTrue(canExecute);
        }

        [TestMethod]
        public void SimuliereSpiele_SollteGewinnerSetzen()
        {
            // Arrange
            _sut.Spiele.Add(new Spiel(new Spieler("Uma", "Thurman"), new Spieler("Quentin", "Tarantino")));
            _sut.Spiele.Add(new Spiel(new Spieler("Samuel", "Jakson"), new Spieler("Harvey", "Keitel")));

            // Act
            _sut.SimuliereSpiele.Execute(null);

            // Assert
            var spiel = _sut.Spiele.First();
            Assert.IsTrue(spiel.Gewinner == spiel.HeimSpieler || spiel.Gewinner == spiel.GastSpieler,
                "Gewinner im ersten Spiel muss auf Heim- oder Gastspieler gesetzt sein.");
            spiel = _sut.Spiele.Last();
            Assert.IsTrue(spiel.Gewinner == spiel.HeimSpieler || spiel.Gewinner == spiel.GastSpieler,
                "Gewinner im letzten Spiel muss auf Heim- oder Gastspieler gesetzt sein.");
        }
    }
}