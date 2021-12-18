using System;
using Xunit;
using PushTaThune;

namespace PushTaThune.Tests
{
    public class Participant_Test
    {
        [Fact]
        public void Participant_ValiderGetIDParticipant()
        {
            // Arrange
            Participant p = new Participant(1, "test", 1);

            // Act
            int result = p.getIDParticipant;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Participant_ValiderGetNom()
        {
            // Arrange
            Participant p = new Participant("test", 1);

            // Act
            string result = p.getNom;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.Equal("test", result);
        }

        [Fact]
        public void Participant_ValiderGetIDSoiree()
        {
            // Arrange
            Participant p = new Participant("test", 1);
            int expected = 1;

            // Act
            int result = p.getIDSoiree;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Participant_ValiderConstructeur()
        {
            // Arrange
            string nom = "test2";
            int idSoiree = 1;

            // Act
            Participant p = new Participant(nom, idSoiree);

            // Assert
            Assert.NotNull(p);
            Assert.IsType<Participant>(p);
            Assert.Equal(nom, p.getNom);
            Assert.Equal(idSoiree, p.getIDSoiree);
        }
    }
}
