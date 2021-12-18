using System;
using Xunit;
using PushTaThune.DAL;

namespace PushTaThune.DAL.Tests
{
    public class Participant_DAL_Tests
    {
        [Fact]
        public void Participant_DAL_ValiderGetIDParticipant()
        {
            // Arrange
            Participant_DAL p = new Participant_DAL("test", 1);
            ParticipantDepot_DAL dp = new ParticipantDepot_DAL();
            p = dp.insert(p);

            // Act
            int result = p.getIDParticipant;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
        }

        [Fact]
        public void Participant_DAL_ValiderGetNom()
        {
            // Arrange
            Participant_DAL p = new Participant_DAL("test", 1);

            // Act
            string result = p.getNom;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.Equal("test", result);
        }

        [Fact]
        public void Participant_DAL_ValiderGetIDSoiree()
        {
            // Arrange
            Participant_DAL p = new Participant_DAL("test", 1);
            int expected = 1;

            // Act
            int result = p.getIDSoiree;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Participant_DAL_ValiderConstructeur()
        {
            // Arrange
            string nom = "test2";
            int idSoiree = 1;

            // Act
            Participant_DAL p = new Participant_DAL(nom, idSoiree);

            // Assert
            Assert.NotNull(p);
            Assert.IsType<Participant_DAL>(p);
            Assert.Equal(nom, p.getNom);
            Assert.Equal(idSoiree, p.getIDSoiree);
        }
    }
}
