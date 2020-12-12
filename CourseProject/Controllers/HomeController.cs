using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> toReturn = new List<string>();

            foreach (var item in System.IO.File.ReadAllLines($@"{Environment.CurrentDirectory}\\App_Data\\Result_v5.txt", Encoding.GetEncoding("windows-1251")).ToList())
            {
                toReturn.Add(DeNcoder.Decrypt(item, "скорпион"));
            }
            return View(toReturn);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult docDecoder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult docDecoder(docFileModel doc)
        {
            if(doc.File == null) { ModelState.AddModelError("File", "Файл не выбран."); return View(doc); }
            if(string.IsNullOrEmpty(doc.Key) || string.IsNullOrWhiteSpace(doc.Key)) { ModelState.AddModelError("Key", "Введите ключ."); return View(doc); }
            if (string.IsNullOrEmpty(doc.Path) || string.IsNullOrWhiteSpace(doc.Path)) { ModelState.AddModelError("Path", "Введите путь."); return View(doc); }
            string ext = Path.GetExtension(doc.File.FileName);
            string key = doc.Key;
            string path = doc.Path;
            if (!(ext == ".docx")) { ModelState.AddModelError("File", "Выбран файл неверного расширения."); return View(doc); }
            if(!DeNcoder.HasNotCyrillicChars(key)){ModelState.AddModelError("Key", "Введён ключ с некиррилическими символами."); return View(doc); }
            if (!Directory.Exists(path)) {ModelState.AddModelError("Path", "Такой директории не существует"); return View(doc); }

            if (ModelState.IsValid)
            {
                WordReader.ReadDoc(doc);
                return RedirectToAction("Index");
            }
            return View(doc);
        }
        public IActionResult txtDecoder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult txtDecoder(txtFileModel model)
        {
            if (string.IsNullOrEmpty(model.Key) || string.IsNullOrWhiteSpace(model.Key)) { ModelState.AddModelError("Key", "Введите ключ."); return View(model); }
            if(string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name)) {ModelState.AddModelError("Name", "Введите название файла."); return View(model); }
            if(string.IsNullOrEmpty(model.Path) || string.IsNullOrWhiteSpace(model.Path)) {ModelState.AddModelError("Path", "Введите путь."); return View(model); }
            if(string.IsNullOrEmpty(model.Txt) || string.IsNullOrWhiteSpace(model.Txt)) {ModelState.AddModelError("Txt", "Введите текст для шифровки."); return View(model); }
            string key = model.Key;
            string path = model.Path;
            if (!DeNcoder.HasNotCyrillicChars(key)) ModelState.AddModelError("Key", "Введён ключ с некиррилическими символами.");
            if (!Directory.Exists(path)) ModelState.AddModelError("Path", "Такой директории не существует");

            if (ModelState.IsValid)
            {
                try
                {
                    System.IO.File.WriteAllText(Path.Combine(path, $"{model.Name}.txt"), DeNcoder.Encrypt(model.Txt, model.Key));
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("Name", "Может введено неверное имя?");
                }
            }
            return View(model);
        }
        public IActionResult Saver()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Saver(FileModel file)
        {
            string path = file.Path;
            if (!Directory.Exists(path)) ModelState.AddModelError("Path", "Такой директории не существует");

            if (ModelState.IsValid)
            {
                try
                {
                    string decryptedText = DeNcoder.Decrypt(System.IO.File.ReadAllText($@"{Environment.CurrentDirectory}\\App_Data\\Result_v5.txt", Encoding.GetEncoding("windows-1251")), "скорпион");
                    System.IO.File.WriteAllText(Path.Combine(path, $"{file.Name}.txt"), decryptedText);
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("Name", "Может введено неверное имя?");
                }
            }
            return View(file);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
