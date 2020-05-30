using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using Microsoft.JSInterop;
using RegistroPersonas.DAL;
using RegistroPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPersonas.BLL
{
    public class PrestamosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(e => e.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        public static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try{
                prestamo.Balance = prestamo.Monto;
                NuevoBalancePersona(prestamo);
                contexto.Prestamos.Add(prestamo);
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;
                ModificarBalancePersona(prestamo);
                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var prestamo = contexto.Prestamos.Find(id);
                if (prestamo != null)
                {
                    EliminarBalancePersona(prestamo);
                    contexto.Prestamos.Remove(prestamo);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;
            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamo;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<Prestamos> GetPrestamos()
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Prestamos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static void NuevoBalancePersona(Prestamos prestamo)
        {
            Personas persona;

            persona = PersonasBLL.Buscar(prestamo.PersonaId);
            persona.Balance += prestamo.Balance;

            PersonasBLL.Modificar(persona);
        }

        public static void ModificarBalancePersona(Prestamos prestamo)
        {
            Personas persona;
            Prestamos prestamoAnterior;

            persona = PersonasBLL.Buscar(prestamo.PersonaId);
            prestamoAnterior = PrestamosBLL.Buscar(prestamo.PrestamoId);

            persona.Balance -= prestamoAnterior.Balance;
            persona.Balance += prestamo.Balance;

            PersonasBLL.Modificar(persona);
        }

        public static void EliminarBalancePersona(Prestamos prestamo)
        {
            Personas persona;

            persona = PersonasBLL.Buscar(prestamo.PersonaId);
            persona.Balance -= prestamo.Balance;

            PersonasBLL.Modificar(persona);
        }


        
    }
}
