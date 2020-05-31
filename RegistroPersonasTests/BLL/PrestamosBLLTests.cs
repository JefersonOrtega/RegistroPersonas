using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPersonas.BLL;
using RegistroPersonas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPersonas.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PrestamosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.PrestamoId = 0;
            prestamo.Fecha = DateTime.Now;
            prestamo.PersonaId = 2;
            prestamo.Concepto = "Compra de Inmueble";
            prestamo.Monto = 50000;

            paso = PrestamosBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.PrestamoId = 0;
            prestamo.Fecha = DateTime.Now;
            prestamo.PersonaId = 2;
            prestamo.Concepto = "Compra de Solar";
            prestamo.Monto = 90000;

            paso = PrestamosBLL.Insertar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.PrestamoId = 1;
            prestamo.Fecha = DateTime.Now;
            prestamo.PersonaId = 2;
            prestamo.Concepto = "Compra de Inmueble";
            prestamo.Monto = 750000;

            paso = PrestamosBLL.Modificar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = false;
            Prestamos prestamo;

            prestamo = PrestamosBLL.Buscar(1);

            if (prestamo!=null)
                paso = true;

            Assert.AreEqual(paso,true);
        }


        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso=PrestamosBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        
        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPrestamosTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NuevoBalancePersonaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarBalancePersonaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarBalancePersonaTest()
        {
            Assert.Fail();
        }
    }
}