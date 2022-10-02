using Domain.BaseEntityKey;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelsDTO
{
    public class BooksView : EntityKey
    {
        [Required(ErrorMessage = "Не указана название книги")]
        [MaxLength(100), MinLength(3)]
        public string name_books { get; set; }

        [Required(ErrorMessage = "Не указан год выпуска книги")]
        public int year { get; set; }

        [Required(ErrorMessage = "Не указан автор книги")]
        [MaxLength (20), MinLength(2)]
        public string name { get; set; }
    }
}
