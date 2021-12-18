using System;
using Xunit;
using PushTaThune.DAL;
using System.Collections.Generic;

namespace PushTaThune.DAL.Tests
{
    public class SoireeDepot_DAL_Tests
    {
        [Fact]
        public void SoireeDepot_DAL_ValiderGetAll()
        {
            // Arrange
            SoireeDepot_DAL dp = new SoireeDepot_DAL();

            // Act
            List<Soiree_DAL> ls = dp.getAll();

            // Assert
            Assert.NotNull(ls);
            Assert.IsType<List<Soiree_DAL>>(ls);
        }

        [Fact]
        public void SoireeDepot_DAL_ValiderGetByID()
        {
            // Arrange
            SoireeDepot_DAL dp = new SoireeDepot_DAL();

            // Act
            Soiree_DAL result = dp.getByID(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Soiree_DAL>(result);
        }

        [Fact]
        public void SoireeDepot_DAL_ValiderInsert()
        {
            // Arrange
            string nom = "test";
            string lieu = "testCity";
            DateTime date = DateTime.Now;

            Soiree_DAL s = new Soiree_DAL(nom, lieu, date);
            SoireeDepot_DAL dp = new SoireeDepot_DAL();

            // Act
            var result = dp.insert(s);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Soiree_DAL>(result);
        }
    }
}
