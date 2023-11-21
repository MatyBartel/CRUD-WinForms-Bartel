using Entidades;
using System.Linq;
using System.Reflection;

namespace TestUnitarios
{

    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        public void AgregarElemento()
        {
            // Arrange
            Bolsa bolsa = new Bolsa();
            Electronica telefono = new Telefono("iPhone",20,EMarcas.Apple,"OLED","7 Plus"); 
            Electronica consola = new Consola("Playstation",50,EMarcas.Sony,"5th",10000);
            Electronica computadora = new Computadora("PC GAMER",20,EMarcas.AMD,"INTEGRADA",32);


            // Act
            bolsa += telefono;
            bolsa += consola;
            bolsa += computadora;


            // Assert
            Assert.IsTrue(bolsa.productos.Contains(telefono));
            Assert.IsTrue(bolsa.productos.Contains(consola));
            Assert.IsTrue(bolsa.productos.Contains(computadora));
        }

        [TestMethod]
        public void EliminarElemento()
        {
            // Arrange
            Bolsa bolsa = new Bolsa();
            Electronica telefono = new Telefono("iPhone", 20, EMarcas.Apple, "OLED", "7 Plus");
            Electronica consola = new Consola("Playstation", 50, EMarcas.Sony, "5th", 10000);
            Electronica computadora = new Computadora("PC GAMER", 20, EMarcas.AMD, "INTEGRADA", 32);

            bolsa += telefono;
            bolsa += consola;
            bolsa += computadora;

            // Act
            bolsa -= telefono;
            bolsa -= consola;
            bolsa -= computadora;


            // Assert
            Assert.IsFalse(bolsa.productos.Contains(telefono));
            Assert.IsFalse(bolsa.productos.Contains(consola));
            Assert.IsFalse(bolsa.productos.Contains(computadora));
        }


        [TestMethod]
        public void VerificarIgualdad_Telefono()
        {
            // Arrange
            Electronica telefono1 = new Telefono("iPhone", 20, EMarcas.Apple, "OLED", "7 Plus");
            Electronica telefono2 = new Telefono("iPhone", 20, EMarcas.Apple, "OLED", "7 Plus");

            // Act
            bool resultado = telefono1 == telefono2;

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void VerificarIgualdad_Computadora()
        {
            // Arrange
            Electronica computadora1 = new Computadora("PC GAMER", 20, EMarcas.AMD, "INTEGRADA", 32);
            Electronica computadora2 = new Computadora("PC GAMER", 20, EMarcas.AMD, "INTEGRADA", 32);

            // Act
            bool resultado = computadora1 == computadora2;

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void VerificarIgualdad_Consola()
        {
            // Arrange
            Electronica consola1 = new Consola("Playstation", 50, EMarcas.Sony, "5th", 10000);
            Electronica consola2 = new Consola("Playstation", 50, EMarcas.Sony, "5th", 10000);

            // Act
            bool resultado = consola1 == consola2;

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void VerificarDesigualdad_Computadora()
        {
            // Arrange
            Electronica computadora1 = new Computadora("PC GAMER", 20, EMarcas.AMD, "RTX 5060", 32);
            Electronica computadora2 = new Computadora("PC ESTUDIO ", 50, EMarcas.Intel, "INTEGRADA", 4);

            // Act
            bool resultado = computadora1 != computadora2;

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void VerificarDesigualdad_Consola()
        {
            // Arrange
            Electronica consola1 = new Consola("Playstation", 50, EMarcas.Sony, "5th", 10000);
            Electronica consola2 = new Consola("XBOX", 10, EMarcas.Microsoft, "360", 500);

            // Act
            bool resultado = consola1 != consola2;

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void VerificarDesigualdad_Telefono()
        {
            // Arrange
            Electronica telefono1 = new Telefono("iPhone", 20, EMarcas.Apple, "OLED", "7 Plus");
            Electronica telefono2 = new Telefono("Galaxy", 5, EMarcas.Samsung, "LCD","A52");

            // Act
            bool resultado = telefono1 != telefono2;

            // Assert
            Assert.IsTrue(resultado);
        }

    }
}
