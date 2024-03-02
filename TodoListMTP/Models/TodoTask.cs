﻿using System.ComponentModel.DataAnnotations;

namespace TodoListMTP.Models
{
    public class TodoTask
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; } = false;
        public DateTime CreatedDate { get; set;} = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
    }
}