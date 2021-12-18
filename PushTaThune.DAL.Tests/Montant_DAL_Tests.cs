using System;
using Xunit;
using PushTaThune.DAL;

namespace PushTaThune.DAL.Tests
{
    public class Montant_DAL_Tests
    {
        [Fact]
        public void Montant_DAL_ValiderGetMontant()
        {
            // Arrange
            Montant_DAL m = new Montant_DAL(1, 0, 0);
            int expected = 1;

            // Act
            double result = m.getMontant;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<double>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Montant_DAL_ValiderGetIDParticipant()
        {
            // Arrange
            Montant_DAL m = new Montant_DAL(0, 1, 0);
            int expected = 1;

            // Act
            int result = m.getIDParticipant;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Montant_DAL_ValiderGetIDSoiree()
        {
            // Arrange
            Montant_DAL m = new Montant_DAL(0, 0, 1);
            int expected = 1;

            // Act
            int result = m.getIDSoiree;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Montant_DAL_ValiderConstructeur()
        {
            // Arrange
            double montant = 1;
            int idParticipant = 2;
            int idSoiree = 3;

            // Act
            Montant_DAL m = new Montant_DAL(montant, idParticipant, idSoiree);

            // Assert
            Assert.NotNull(m);
            Assert.IsType<Montant_DAL>(m);
        }
    }
}
