using Lab2.Repository;
using Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class PowerBrickController : Controller
    {

        PowerBrickRepository powerBrickRepository = new PowerBrickRepository();

        MotherboardRepository motherboardRepository = new MotherboardRepository();
        public ActionResult Index()
        {
          
            return View(powerBrickRepository.getBricks());
        }




        // GET: Motherboard/Edit/5
        public ActionResult Edit(int id)
        {
            PowerBrickEditViewModel powerBrick = powerBrickRepository.getBrick(id);
            PopulateSelections(powerBrick);
            //grazinama darbuotojo redagavimo forma
            return View(powerBrick);
        }

        // POST: Motherboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PowerBrickEditViewModel collection)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    powerBrickRepository.updateBrick(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Create()
        {
            //Grazinama darbuotojo kūrimo forma
            PowerBrickListAddView powerBrick = new PowerBrickListAddView();
            powerBrick.powerBrick = new PowerBrickEditViewModel();
            PopulateSelections(powerBrick.powerBrick);
            return View(powerBrick);
        }

        // POST: Motherboard/Create
        [HttpPost]
        public ActionResult Create(PowerBrickListAddView collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {

                    powerBrickRepository.addBrick(collection.powerBrick);

                    if (collection.list != null)
                    {
                        foreach (PowerBrickEditViewModel temp in collection.list)
                        {
                            temp.Motherboard = collection.powerBrick.Motherboard;
                            powerBrickRepository.addBrick(temp);
                        }
                    }
                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection.powerBrick);
                return View(collection);
            }
        }


        public ActionResult Delete(int id)
        {
            PowerBrickEditViewModel brick = powerBrickRepository.getBrick(id);
            return View(brick);
        }

        // POST: Motherboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PowerBrickEditViewModel collection)
        {
            try
            {

                powerBrickRepository.deleteBrick(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        public void PopulateSelections(PowerBrickEditViewModel modelis)
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