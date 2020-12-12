using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class FileModel
    {
        [Required(ErrorMessage = "Введи путь для сохранения")]
        [DisplayName("Путь сохранения")]
        public string Path { get; set; }

        [Required(ErrorMessage = "Введи название файла")]
        [DisplayName("Название файла")]
        public string Name { get; set; }
    }
}
