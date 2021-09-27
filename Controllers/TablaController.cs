using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LUCKYSAC.Models;
using LUCKYSAC.Models.VieModels;

namespace LUCKYSAC.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ClientesViewModell> lst;
            //Conectamos a la BD
            using (CRUDEntities db = new CRUDEntities())
            {
                lst = (from c in db.Cliente
                       select new ClientesViewModell
                       //Mostramos los datos
                       {
                           IdCliente = c.Id,
                           Nombres = c.Nombres,
                           Apellidos = c.Apellidos,
                           DNI = c.Dni,
                           Telefono = c.Telefono,
                           Correo = c.Correo,
                           Direccion = c.Direccion

                       }).ToList();
            }
            return View(lst);
        }


        public ActionResult Nuevo()
        {
            return View();

        }
        //Le asignamos el metodo Post al método
        [HttpPost]
        public ActionResult Nuevo(ClientesViewModell model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities db = new CRUDEntities())
                    {
                        var obj = new Cliente();
                        obj.Id = model.IdCliente;
                        obj.Nombres = model.Nombres;
                        obj.Apellidos = model.Apellidos;
                        obj.Dni = model.DNI;
                        obj.Telefono = model.Telefono;
                        obj.Correo = model.Correo;
                        obj.Direccion = model.Direccion;

                        db.Cliente.Add(obj);
                        db.SaveChanges();
                    }
                    //Retorna a listado al guardar
                    return Redirect("~/Tabla/");
                }

                return View(model);


            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }



        }






      
        public ActionResult Editar(int Id)
        {
            ClientesViewModell model = new ClientesViewModell();
            using (CRUDEntities db = new CRUDEntities())
            {
                var obj = db.Cliente.Find(Id);
                model.IdCliente = obj.Id;
                model.Nombres = obj.Nombres;
                model.Apellidos = obj.Apellidos;
                model.DNI = obj.Dni;
                model.Telefono = obj.Telefono;
                model.Correo = obj.Correo;
                model.Direccion = obj.Direccion;
    
            }
            return View(model);

        }
        //Le asignamos el metodo Post al método
        [HttpPost]
        public ActionResult Editar(ClientesViewModell model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities db = new CRUDEntities())
                    {
                        var obj = db.Cliente.Find(model.IdCliente);
                        obj.Id = model.IdCliente;
                        obj.Nombres = model.Nombres;
                        obj.Apellidos = model.Apellidos;
                        obj.Dni = model.DNI;
                        obj.Telefono = model.Telefono;
                        obj.Correo = model.Correo;
                        obj.Direccion = model.Direccion;

                        db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    //Retorna a listado al guardar
                    return Redirect("~/Tabla/");
                }

                return View(model);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            
            using (CRUDEntities db = new CRUDEntities())
            {
                
                var obj = db.Cliente.Find(Id);
                db.Cliente.Remove(obj);
                db.SaveChanges();
                

            }
            return Redirect("~/Tabla/");

        }

    }

}
