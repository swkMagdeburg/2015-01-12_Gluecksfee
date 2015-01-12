using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Gluecksfee.Core.Tests.ErmittleGewinnerViewModelTests
{
    [TestClass]
    public class LoseSpieleAusTests
    {
        private Mock<ISpielerRepository> _repository;
        private ErmittleGewinnerViewModel _sut;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new Mock<ISpielerRepository>();
            _sut = new ErmittleGewinnerViewModel(_repository.Object);
        }

        [TestMethod]
        public void LoseSpieleAus_CanExecuteSollteFalseLiefernWennKeineSpielerExisitieren()
        {
            // Arrange

            // Act
            var canExecute = _sut.LoseSpieleAus.CanExecute(null);

            // Assert
            Assert.IsFalse(canExecute);
        }

        [TestMethod]
        public void LoseSpieleAus_CanExecuteSollteTrueLiefernWenn2SpielerExisiteren()
        {
            // Arrange
            var spieler = new List<Spieler> {new Spieler("Hans", "Wurst"), new Spieler("Hans", "Guckindieluft")};
            _repository.Setup(r => r.Spieler).Returns(spieler);

            // Act
            var canExecute = _sut.LoseSpieleAus.CanExecute(null);

            // Assert
            Assert.IsTrue(canExecute);
        }

        [TestMethod]
        public void LoseSpieleAus_CanExecuteSollteTrueLiefernWennMehrAls2SpielerExisitieren()
        {
            // Arrange
            var spieler = new List<Spieler>
            {
                new Spieler("Uma", "Thurman"),
                new Spieler("Harvey", "Keitel"),
                new Spieler("Quentin", "Tarantino"),
                new Spieler("Samuel", "Jackson")
            };
            _repository.Setup(r => r.Spieler).Returns(spieler);

            // Act
            var canExecute = _sut.LoseSpieleAus.CanExecute(null);

            // Assert
            Assert.IsTrue(canExecute);
        }

        [TestMethod]
        public void LoseSpieleAus_ExecuteSollteSpieleBelegen()
        {
            // Arrange
            var spieler = new List<Spieler>
            {
                new Spieler("Uma", "Thurman"),
                new Spieler("Harvey", "Keitel"),
                new Spieler("Quentin", "Tarantino"),
                new Spieler("Samuel", "Jackson")
            };
            _repository.Setup(r => r.Spieler).Returns(spieler);

            // Act
            _sut.LoseSpieleAus.Execute(null);

            // Assert
            Assert.AreEqual(2, _sut.Spiele.Count, "Bei vier Spielern müssen 2 Spiele ausgelost werden.");
        }

        [TestMethod]
        public void LoseSpieleAus_ExecuteSollteAlteSpieleEntfernen()
        {
            // Arrange
            var spieler = new List<Spieler>
            {
                new Spieler("Uma", "Thurman"),
                new Spieler("Harvey", "Keitel"),
                new Spieler("Quentin", "Tarantino"),
                new Spieler("Samuel", "Jackson")
            };
            _repository.Setup(r => r.Spieler).Returns(spieler);

            // Act
            _sut.LoseSpieleAus.Execute(null);
            _sut.LoseSpieleAus.Execute(null);

            // Assert
            Assert.AreEqual(2, _sut.Spiele.Count, "Auch bei wiederholtem Auslosen der Spiele, dürfen bei 4 Spielern nur 2 Spiele entstehen.");
        }

        [TestMethod]
        public void LoseSpieleAus_ExecuteSollteBeiUngeraderAnzahlEinenDummySpielerEinfuegen()
        {
            // Arrange
            var spieler = new List<Spieler>
            {
                new Spieler("Uma", "Thurman"),
                new Spieler("Harvey", "Keitel"),
                new Spieler("Quentin", "Tarantino"),
            };
            _repository.Setup(r => r.Spieler).Returns(spieler);

            // Act
            _sut.LoseSpieleAus.Execute(null);

            // Assert
            Assert.IsTrue(!spieler.Contains(_sut.Spiele.Last().GastSpieler), "Bei ungerader Anzahl an Spielern spielt der zuletzt gewählte gegen einen Dummy.");
        }
    }
}