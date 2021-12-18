using System;
using Xunit;
using PushTaThune.DAL;

namespace PushTaThune.DAL.Tests
{
    public class Soiree_DAL_Tests
    {
        [Fact]
        public void Soiree_DAL_ValiderGetID()
        {
            // Arrange
            Soiree_DAL s = new Soiree_DAL("test", "testCity", DateTime.Now);
            SoireeDepot_DAL dp = new SoireeDepot_DAL();
            dp.insert(s);

            // Act
            int result = s.getIDSoiree;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
        }

        [Fact]
        public void Soiree_DAL_ValiderGetNom()
        {
            // Arrange
            Soiree_DAL s = new Soiree_DAL("test", "testCity", DateTime.Now);
            string expected = "test";

            // Act
            string result = s.getNom;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Soiree_DAL_ValiderGetLieu()
        {
            // Arrange
            Soiree_DAL s = new Soiree_DAL("test", "testCity", DateTime.Now);
            string expected = "testCity";

            // Act
            string result = s.getLieu;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Soiree_DAL_ValiderGetDate()
        {
            // Arrange
            Soiree_DAL s = new Soiree_DAL("test", "testCity", DateTime.Now);
            string expected = DateTime.Now.ToString("d");

            // Act
            string result = s.getDate.ToString("d");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Soiree_DAL_ValiderConstructeur()
        {
            // Arrange

            string nom = "test";
            string lieu = "testCity";
            DateTime date = DateTime.Now;

            // Act
            Soiree_DAL s = new Soiree_DAL(nom, lieu, date);

            // Assert
            Assert.NotNull(s);
            Assert.IsType<Soiree_DAL>(s);
            Assert.Equal(nom, s.getNom);
            Assert.Equal(lieu, s.getLieu);
            Assert.Equal(date, s.getDate);
        }
    }
}
