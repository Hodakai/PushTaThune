using System;
using Xunit;
using PushTaThune;

namespace PushTaThune.Tests
{
    public class Soiree_Test
    {
        [Fact]
        public void Soiree_ValiderGetID()
        {
            // Arrange
            Soiree s = new Soiree(1, "test", "testCity", DateTime.Now);

            // Act
            int result = s.getIDSoiree;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int>(result);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Soiree_ValiderGetNom()
        {
            // Arrange
            Soiree s = new Soiree("test", "testCity", DateTime.Now);
            string expected = "test";

            // Act
            string result = s.getNom;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Soiree_ValiderGetLieu()
        {
            // Arrange
            Soiree s = new Soiree("test", "testCity", DateTime.Now);
            string expected = "testCity";

            // Act
            string result = s.getLieu;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Soiree_ValiderGetDate()
        {
            // Arrange
            Soiree s = new Soiree("test", "testCity", DateTime.Now);
            string expected = DateTime.Now.ToString("d");

            // Act
            string result = s.getDate.ToString("d");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Soiree_ValiderConstructeur()
        {
            // Arrange

            string nom = "test";
            string lieu = "testCity";
            DateTime date = DateTime.Now;

            // Act
            Soiree s = new Soiree(nom, lieu, date);

            // Assert
            Assert.NotNull(s);
            Assert.IsType<Soiree>(s);
            Assert.Equal(nom, s.getNom);
            Assert.Equal(lieu, s.getLieu);
            Assert.Equal(date, s.getDate);
        }
    }
}
