using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Gluecksfee.Core.Tests.ErmittleGewinnerViewModelTests
{
    [TestClass]
    public class InitialwerteTests
    {
        [TestMethod]
        public void ErmittleGewinner_GewinnerSollteInitialNullSein()
        {
            // Arrange

            // Act
            var sut = new ErmittleGewinnerViewModel(null);

            // Assert
            Assert.IsNull(sut.Gewinner);
        }

        [TestMethod]
        public void ErmittleGewinner_SpieleSollteInitialKeineSpieleEnthalten()
        {
            // Arrange

            // Act
            var sut = new ErmittleGewinnerViewModel(null);

            // Assert
            Assert.IsFalse(sut.Spiele.Any());
        }

        [TestMethod]
        public void ErmittelGewinner_SpielerLiefertSpielerAusUebergebenenRepository()
        {
            // Arrange
            var spieler = new List<Spieler>();
            var repository = new Mock<ISpielerRepository>();
            repository.Setup(r => r.Spieler).Returns(spieler);

            // Act
            var sut = new ErmittleGewinnerViewModel(repository.Object);

            // Assert
            Assert.AreEqual(spieler, sut.Spieler);
        }
    }
}