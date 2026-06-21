using Microsoft.AspNetCore.Mvc;
using Nurse_data.Abstract;
using Nurse_data.Models;
using Nurse_data.NurseRepo;

namespace MVC_Nurse.Controllers
{
    public class NurseController : Controller
    {
        private INurseRepo _nurseRepo = new NurseRepo();

        [HttpGet]
        public IActionResult Index()
        {
            List<Nurse> nurses = _nurseRepo.GetAllNurse();
            return View(nurses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Nurse nurse)
        {
            int nurseUpdated = _nurseRepo.InsertNurse(nurse);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Nurse nurse = _nurseRepo.GetNurseById(id);
            if (nurse == null)
                return NotFound();
            return View(nurse);
        }

        [HttpPost]
        public IActionResult Edit(Nurse nurse)
        {
            int nurseUpdated = _nurseRepo.UpdateNurse(nurse);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Nurse nurse = _nurseRepo.GetNurseById(id);
            if (nurse == null)
                return NotFound();
            return View(nurse);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Nurse nurse = _nurseRepo.GetNurseById(id);
            if (nurse == null)
                return NotFound();
            return View(nurse);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteNurse(int id)
        {
            int nurseDeleted = _nurseRepo.DeleteNurse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

