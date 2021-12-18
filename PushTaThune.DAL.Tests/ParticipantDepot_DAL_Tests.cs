using System;
using Xunit;
using PushTaThune.DAL;
using System.Collections.Generic;

namespace PushTaThune.DAL.Tests
{
    public class ParticipantDepot_DAL_Tests
    {
        [Fact]
        public void ParticipantDepot_DAL_ValiderGetAll()
        {
            // Arrange
            ParticipantDepot_DAL dp = new ParticipantDepot_DAL();

            // Act
            List<Participant_DAL> lp = dp.getAll();

            // Assert
            Assert.NotNull(lp);
            Assert.IsType<List<Participant_DAL>>(lp);
        }

        [Fact]
        public void ParticipantDepot_DAL_ValiderGetByID()
        {
            // Arrange
            ParticipantDepot_DAL dp = new ParticipantDepot_DAL();

            // Act
            Participant_DAL result = dp.getByID(5);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Participant_DAL>(result);
        }

        [Fact]
        public void ParticipantDepot_DAL_ValiderInsert()
        {
            // Arrange
            string nom = "test3";
            int idSoiree = 1;

            var participantDAL = new Participant_DAL(nom, idSoiree);

            var dp = new ParticipantDepot_DAL();

            // Act
            var result = dp.insert(participantDAL);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Participant_DAL>(result);
        }

        [Fact]
        public void ParticipantDepot_DAL_ValiderUpdate()
        {
            // Arrange
            ParticipantDepot_DAL dp = new ParticipantDepot_DAL();
            Participant_DAL s = dp.getByID(3);
            s = new Participant_DAL("test4", 3);

            // Act
            var result = dp.update(s);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Participant_DAL>(result);
            Assert.Equal("test4", result.getNom);
            Assert.Equal(3, result.getIDSoiree);
        }
    }
}
