using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoApp.Ifrastructure.Entities
{
    public class Todo
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; } = DateTime.Today;

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool IsDone { get; set; } = false;
    }
}
