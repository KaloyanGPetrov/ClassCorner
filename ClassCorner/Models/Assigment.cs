﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCorner.Models
{
    public class Assigment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? Deadline { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
    }
}