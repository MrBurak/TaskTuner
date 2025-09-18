using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTuner.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? DEscription { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan Timer { get; set; }

    }
}
