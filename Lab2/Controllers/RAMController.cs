using Lab2.Repository;
using Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class RAMController : Controller
    {
        
            RAMRepository ramRepository = new RAMRepository();
            MotherboardRepository motherboardRepository = new MotherboardRepository();
        public ActionResult Index()
            {
                //gražinamas darbuotoju sarašo vaizdas
                return View(ramRepository.getRAMs());
            }

        
            // GET: Motherboard/Create
            public ActionResult Create()
            {
                //Grazinama darbuotojo kūrimo forma
                RAMEditViewModel ram = new RAMEditViewModel();
                PopulateSelections(ram);
                return View(ram);
            }

            // POST: Motherboard/Create
            [HttpPost]
            public ActionResult Create(RAMEditViewModel collection)
            {
                try
                {
                RAMEditViewModel temp = ramRepository.getRAM(collection.id_RAM);
                if (temp.Pavadinimas != null)
                {
                    ModelState.AddModelError("ID_RAM", "SAME ID ALEARDY EXIST TRY AGAIN");
                    return View(collection);
                }
                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        ramRepository.addRAM(collection);
                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    PopulateSelections(collection);
                    return View(collection);
                }
            }

            // GET: Motherboard/Edit/5
            public ActionResult Edit(int id)
            {
            RAMEditViewModel ram = ramRepository.getRAM(id);
            PopulateSelections(ram);
            //grazinama darbuotojo redagavimo forma
            return View(ram);
            }

            // POST: Motherboard/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, RAMEditViewModel collection)
            {
                try
                {
                    // Atnaujina darbuotojo informacija
                    if (ModelState.IsValid)
                    {
                    ramRepository.updateRAM(collection);
                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                PopulateSelections(collection);
                return View(collection);
                }
            }

            // GET: Motherboard/Delete/5
            public ActionResult Delete(int id)
            {
            RAMEditViewModel ram = ramRepository.getRAM(id);
            return View(ram);
        }

            // POST: Motherboard/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {

                    ramRepository.deleteRAM(id);


                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

        public void PopulateSelections(RAMEditViewModel modelis)
        {
            var markes = motherboardRepository.GetMotherboards();
            List<SelectListItem> selectListmotherboards = new List<SelectListItem>();

            foreach (var item in markes)
            {
                selectListmotherboards.Add(new SelectListItem() { Value = Convert.ToString(item.id_Motinine_Plokste), Text = item.Pavadinimas });
            }

            modelis.MotherBoardList = selectListmotherboards;
        }

    }
}