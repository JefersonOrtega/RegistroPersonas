using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPersonas.BLL;
using RegistroPersonas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPersonas.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        
        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PersonasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Personas persona = new Personas();

            persona.PersonaId = 0;
            persona.Nombre = "Jefeson";
            persona.Telefono = "829-754-0346";
            persona.Cedula = "402-0000000-0";
            persona.Direccion = "C/ Juan P Gonzales #6";
            persona.FechaNacimiento = DateTime.Now;
            paso = PersonasBLL.Guardar(persona);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Personas persona = new Personas();

            persona.PersonaId = 2;
            persona.Nombre = "Jeferson Raul Ortega Bito";
            persona.Telefono = "829-754-0346";
            persona.Cedula = "402-0000000-4";
            persona.Direccion = "C/ Juan P Gonzales #6 Urb Abreu VR";
            persona.FechaNacimiento = DateTime.Now;

            paso = PersonasBLL.Modificar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = PersonasBLL.Eliminar(1);
            Assert.AreNotEqual(paso,false);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = false;
            Personas persona = PersonasBLL.Buscar(1);
            if (persona != null)
                paso = true;
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPersonasTest()
        {
            Assert.Fail();
        }
    }
}