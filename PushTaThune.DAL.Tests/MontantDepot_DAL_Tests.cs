using System;
using Xunit;
using PushTaThune.DAL;
using System.Collections.Generic;

namespace PushTaThune.DAL.Tests
{
    public class MontantDepot_DAL_Tests
    {
        [Fact]
        public void MontantDepot_DAL_ValiderGetAll()
        {
            // Arrange
            MontantDepot_DAL m = new MontantDepot_DAL();

            // Act
            List<Montant_DAL> lm = m.getAll();

            // Assert
            Assert.NotNull(lm);
            Assert.IsType<List<Montant_DAL>>(lm);
        }

        [Fact]
        public void MontantDepot_DAL_ValiderGetByID()
        {
            // Arrange
            MontantDepot_DAL m = new MontantDepot_DAL();

            // Act
            Montant_DAL result = m.getByID(53);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Montant_DAL>(result);
        }

        [Fact]
        public void MontantDepot_DAL_ValiderInsert()
        {
            // Arrange
            double montant = 2;
            int idParticipant = 5;
            int idSoiree = 3;

            var montantDAL = new Montant_DAL(montant, idParticipant, idSoiree);

            var dp = new MontantDepot_DAL();

            // Act
            var result = dp.insert(montantDAL);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Montant_DAL>(result);
        }
    }
}
