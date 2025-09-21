using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TaskTuner.Converters;

namespace TaskTuner.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan Timer { get; set; }
        public TaskState TaskState { get; set; }

        public TaskImportance TaskImportance { get; set; }

        public TaskCategory TaskCategory { get; set; }

        public ObservableCollection<TaskCheckList>? TaskCheckLists { get; set; }
    }

    public class TaskView : Task 
    {
        ImportanceToBrushConverter importanceToBrushConverter;
        public TaskView()
        {
            importanceToBrushConverter = new ImportanceToBrushConverter();
        }

        public object SolidColorBrush { get => importanceToBrushConverter.Convert(TaskImportance); }
    }
}
