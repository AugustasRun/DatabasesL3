using Lab2.Repository;
using Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class CpuController : Controller
    {

        CpuRepository cpuRepository = new CpuRepository();
        CoolerRepository coolerRepository = new CoolerRepository();
        MotherboardRepository motherboardRepository = new MotherboardRepository();
        public ActionResult Index()
        {

            return View(cpuRepository.getCPUs());
        }


        public ActionResult Create()
        {
            //Grazinama darbuotojo kūrimo forma
            CpuEditList cpu = new CpuEditList();
            cpu.cpu = new CpuEditViewModel();
           
            PopulateSelections(cpu.cpu);
            return View(cpu);
        }

        // POST: Motherboard/Create
        [HttpPost]
        public ActionResult Create(CpuEditList collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {

                    cpuRepository.insertCPU(collection.cpu);

                    if (collection.coolers != null)
                    {
                        foreach (CoolerEditViewModel temp in collection.coolers)
                        {
                            temp.idCPU = collection.cpu.id_CPU;
                            coolerRepository.insertCooler(temp);
                        }
                    }

                }
             

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection.cpu);
                return View(collection);
            }
        }


        // GET: Motherboard/Edit/5
        public ActionResult Edit(int id)
        {
            CpuEditList cpu = new CpuEditList();
            cpu.cpu = cpuRepository.getCPU(id);
            cpu.coolers = coolerRepository.GetCoolerEditViewModels(cpu.cpu.id_CPU);
            PopulateSelections(cpu.cpu);
            //grazinama darbuotojo redagavimo forma
            return View(cpu);
        }

        // POST: Motherboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CpuEditList collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    cpuRepository.updateCPU(collection.cpu);
                    coolerRepository.deleteCooler(collection.cpu.id_CPU);

                    if(collection.coolers != null)
                    {
                        foreach (var item in collection.coolers)
                        {
                            item.idCPU = collection.cpu.id_CPU;
                            coolerRepository.insertCooler(item);
                        }
                        
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult Delete(int id)
        {
            CpuEditList cpu = new CpuEditList();
            cpu.cpu = cpuRepository.getCPU(id);
            cpu.coolers = coolerRepository.GetCoolerEditViewModels(cpu.cpu.id_CPU);
            return View(cpu);
        }


        // POST: Motherboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CpuEditList collection)
        {
            try
            {
                coolerRepository.deleteCooler(id);
                cpuRepository.deleteCPU(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }







        public void PopulateSelections(CpuEditViewModel modelis)
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