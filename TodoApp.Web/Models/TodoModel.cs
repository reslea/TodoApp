using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Web.Models
{
    public class TodoModel
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; } = DateTime.Today;

        public bool IsDone { get; set; } = false;
    }
}
