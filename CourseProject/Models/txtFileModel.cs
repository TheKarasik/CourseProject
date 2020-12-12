using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class txtFileModel
    {
        [Required(ErrorMessage = "Введите текст")]
        [DisplayName("Текст")]
        public string Txt { get; set; }

        [Required(ErrorMessage = "Введи ключ шифровки")]
        [DisplayName("Ключ шифровки")]
        public string Key { get; set; }

        [Required(ErrorMessage = "Введи путь для сохранения")]
        [DisplayName("Путь сохранения")]
        public string Path { get; set; }

        [Required(ErrorMessage = "Введи название файла")]
        [DisplayName("Название файла")]
        public string Name { get; set; }
    }
}
