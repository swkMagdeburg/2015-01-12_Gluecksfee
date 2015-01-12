using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Gluecksfee.Core.Tests.ErmittleGewinnerViewModelTests
{
    [TestClass]
    public class EntferneVerliererTests
    {
        private Mock<ISpielerRepository> _repository;
        private ErmittleGewinnerViewModel _sut;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new Mock<ISpielerRepository>();
            _sut = new ErmittleGewinnerViewModel(_repository.Object);
            _sut.Spiele.Add(new Spiel(new Spieler("Uma", "Thurman"), new Spieler("Quentin", "Tarantino")));
            _sut.Spiele.Add(new Spiel(new Spieler("Samuel", "Jakson"), new Spieler("Harvey", "Keitel")));
        }

        [TestMethod]
        public void EntferneVerlierer_CanExecuteSollteFalseSeinWennKeineGewinnerExistieren()
        {
            // Arrange

            // Act
            var canExecute = _sut.EntferneVerlierer.CanExecute(null);

            // Assert
            Assert.IsFalse(canExecute);
        }

        [TestMethod]
        public void EntferneVerlierer_CanExecuteSollteTrueSeinWennGewinnerExistieren()
        {
            // Arrange
            _sut.Spiele.First().SetzeGewinnerAufGastspieler();
            _sut.Spiele.Last().SetzeGewinnerAufHeimspieler();

            // Act
            var canExecute = _sut.EntferneVerlierer.CanExecute(null);

            // Assert
            Assert.IsTrue(canExecute);
        }

        [TestMethod]
        public void EntferneVerlierer_ExecuteSollteVerliereAusRepositoyEntfernen()
        {
            // Arrange
            _sut.Spiele.First().SetzeGewinnerAufGastspieler();
            _sut.Spiele.Last().SetzeGewinnerAufHeimspieler();

            // Act
            _sut.EntferneVerlierer.Execute(null);

            // Assert
            _repository.Verify(r => r.Entferne(_sut.Spiele.First().HeimSpieler), Times.Once,
                "Heimspieler aus dem ersten Spiel muss entfernt werden.");
            _repository.Verify(r => r.Entferne(_sut.Spiele.First().GastSpieler), Times.Never,
                "Der Gewinner aus dem ersten Spiel darf nicht entfernt werden.");
            _repository.Verify(r => r.Entferne(_sut.Spiele.Last().HeimSpieler), Times.Never,
                "Der Gewinner vom letzten Spiel darf nicht entfernt werden.");
            _repository.Verify(r => r.Entferne(_sut.Spiele.Last().GastSpieler), Times.Once,
                "Der Gastspieler vom letzten Spiel muss entfernt werden.");
        }

        [TestMethod]
        public void EntferneVerlierer_SollteKeinenGewinnerSetzenWennMehrAlsEinSpielerExistiert()
        {
            // Arrange
            _sut.Spiele.First().SetzeGewinnerAufGastspieler();
            var spieler = new List<Spieler>
            {
                new Spieler("Uma", "Thurman"),
                new Spieler("Harvey", "Keitel")
            };
            _repository.Setup(r => r.Spieler).Returns(spieler);

            // Act
            _sut.EntferneVerlierer.Execute(null);

            // Assert
            Assert.IsNull(_sut.Gewinner);
        }

        [TestMethod]
        public void EntferneVerlierer_SollteGewinnerSetzenWennNurNochEinSpielerExistiert()
        {
            // Arrange
            _sut.Spiele.First().SetzeGewinnerAufGastspieler();
            var spieler = new List<Spieler>
            {
                new Spieler("Uma", "Thurman")
            };
            _repository.Setup(r => r.Spieler).Returns(spieler);

            // Act
            _sut.EntferneVerlierer.Execute(null);

            // Assert
            Assert.AreEqual(spieler.First(), _sut.Gewinner);
        }
    }
}