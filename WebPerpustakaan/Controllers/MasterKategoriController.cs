using Microsoft.AspNetCore.Mvc;

namespace WebPerpustakaan.Controllers
{
    public class MasterKategoriController : Controller
    {
        public IActionResult Index()
        {
            var model = new Models.MasterKategoriControllerVM.Index();

            return View(model);
        }

        public IActionResult Add() {
            var model = new Models.MasterKategoriControllerVM.Add();

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(Models.MasterKategoriControllerVM.Add input)
        {
            try
            {
                Models.MasterKategoriControllerVM.Save(input);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Menampilkan pesan kesalahan
                ViewBag.ErrorMessage = $"Terjadi kesalahan saat menyimpan data: {ex.Message}";
                return View("Error"); // Pastikan ada tampilan "Error" untuk menampilkan pesan kesalahan
            }
        }
    }
}
