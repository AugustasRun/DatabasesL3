using Lab2.Models;
using Lab2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class MotherboardController : Controller
    {
        MotherboardRepository motherboardRepository = new MotherboardRepository();
        public ActionResult Index()
        {
            //gražinamas darbuotoju sarašo vaizdas
            return View(motherboardRepository.GetMotherboards());
        }

        // GET: Motherboard/Create
        public ActionResult Create()
        {
            //Grazinama darbuotojo kūrimo forma
            Motherboard motherboard = new Motherboard();
            return View(motherboard);
        }

        // POST: Motherboard/Create
        [HttpPost]
        public ActionResult Create(Motherboard collection)
        {
            try
            {
                // Patikrinama ar tokiod arbuotojo nėra duomenų bazėje
                Motherboard tmpMotherboard = motherboardRepository.GetMotherboard(collection.id_Motinine_Plokste);

                if (tmpMotherboard.id_Motinine_Plokste != null)
                {
                    ModelState.AddModelError("ID_MOTHERBOARD", "Motherboard su tokiu tabelio numeriu jau egzistuoja duomenų bazėje.");
                    return View(collection);
                }
                //Jei darbuotojo su tabelio nr neranda prideda naują
                if (ModelState.IsValid)
                {
                    motherboardRepository.addMotherboard(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Motherboard/Edit/5
        public ActionResult Edit(int id)
        {
            //grazinama darbuotojo redagavimo forma
            return View(motherboardRepository.GetMotherboard(id));
        }

        // POST: Motherboard/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Motherboard collection)
        {
            try
            {
                // Atnaujina darbuotojo informacija
                if (ModelState.IsValid)
                {
                    motherboardRepository.updateMotherboard(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Motherboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View(motherboardRepository.GetMotherboard(id));
        }

        // POST: Motherboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               
                motherboardRepository.deleteMotherboard(id);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
