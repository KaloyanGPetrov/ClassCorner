﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCorner.Models
{
    public class TeacherClass
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey(nameof(Class))]
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
