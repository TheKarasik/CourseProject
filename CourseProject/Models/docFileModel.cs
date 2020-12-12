using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class docFileModel
    {

        [Required(ErrorMessage = "Выбери .docx файл")]
        [DisplayName(".docx файл")]
        public IFormFile File{ get; set; }

        [Required(ErrorMessage = "Введи ключ шифровки")]
        [DisplayName("Ключ шифровки")]
        public string Key { get; set; }

        [Required(ErrorMessage = "Введи путь для сохранения")]
        [DisplayName("Путь сохранения")]
        public string Path { get; set; }
    }
}
