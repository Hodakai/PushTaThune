using System;
using Xunit;
using PushTaThune;

namespace PushTaThune.Tests
{
    public class Montant_Test
    {
        [Fact]
        public void Montant_ValiderGetMontant()
        {
            // Arrange
            Montant m = new Montant(1, 0, 0);
            int expected = 1;

            // Act
            double result = m.getMontant;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<double>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Montant_ValiderGetIDParticipant()
        {
            // Arrange
            Montant m = new Montant(0, 1, 0);
            int expected = 1;

            // Act
            int result = m.getIDParticipant;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Montant_ValiderGetIDSoiree()
        {
            // Arrange
            Montant m = new Montant(0, 0, 1);
            int expected = 1;

            // Act
            int result = m.getIDSoiree;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Montant_ValiderConstructeur()
        {
            // Arrange
            double montant = 1;
            int idParticipant = 2;
            int idSoiree = 3;

            // Act
            Montant m = new Montant(montant, idParticipant, idSoiree);

            // Assert
            Assert.NotNull(m);
            Assert.IsType<Montant>(m);
        }
    }
}
