using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TaskTuner.DataService;
using TaskTuner.Models;

namespace TaskTuner.ModelViews
{
    internal class TaskViewModel : INotifyPropertyChanged
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

        public ObservableCollection<TaskCheckList>? TaskCheckLists { get; set; }=new ObservableCollection<TaskCheckList>();

        public ICommand IAddNewTask => new RelayCommand(AddTasks, null!);







        private readonly TaskDataService taskDataService;

        

        private ObservableCollection<Models.Task> tasks;

        public ObservableCollection<Models.Task> Tasks
        {
            get => tasks;
            set 
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }

        }


        private TaskImportance importance;
        public TaskImportance Importance
        {
            get => importance;
            set
            {
                if (importance != value)
                {
                    importance = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Importance)));
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadTasks() 
        {
            var taskList = taskDataService.LoadTask();
            Tasks = new ObservableCollection<Models.Task>(taskList); 
        }

        public void AddTasks()
        {
            Models.Task task = new Models.Task()
            {
                Description = this.Description,
                DueDate = this.DueDate,
                StartDate = DateTime.Now,
                Id = Guid.NewGuid(),
                IsCompleted = false,
                TaskCheckLists = this.TaskCheckLists,
                Timer = this.Timer,
                Title = this.Title,
                TaskCategory = this.TaskCategory,
                TaskImportance = this.TaskImportance,
                TaskState=this.TaskState,
            };

            taskDataService.AddTask(task);
            ClearData();
            LoadTasks();
            
        }

        private void ClearData() 
        {
            Title = string.Empty;
            Description = string.Empty;
            DueDate = DateTime.Now;
            TaskCheckLists.Clear();

            OnPropertyChanged(nameof(TaskCheckLists));
            OnPropertyChanged(nameof(Timer));
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(TaskCategory));
            OnPropertyChanged(nameof(TaskState));
            OnPropertyChanged(nameof(TaskImportance));
            OnPropertyChanged(nameof(TaskState));
               
        }

        public void UpdateTasks(Models.Task task)
        {
            taskDataService.UpdateTask(task);
            LoadTasks();
        }

        public void DeleteTasks(Guid id)
        {
            taskDataService.DeleteTask(id);
            LoadTasks();
        }

        public TaskViewModel()
        {
            taskDataService = new TaskDataService();
            DueDate=DateTime.Now;
        }

        protected virtual void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
