using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Input;
using TaskTuner.DataService;
using TaskTuner.Models;
using TaskTuner.Views;

namespace TaskTuner.ModelViews
{
    public class MainWindowsViewModal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private List<TaskView> tasks = new();
        public List<TaskView> Tasks
        {
            get => tasks;
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }



        public ICommand IOpenNewWindow => new RelayCommand(OpenNewWindow, null!);


        private readonly TaskDataService taskDataService;

        public MainWindowsViewModal()
        {
            taskDataService = new TaskDataService();
            tasks = JsonConvert.DeserializeObject<List<TaskView>>(JsonConvert.SerializeObject(this.taskDataService.LoadTask()));
        }

        private void OpenNewWindow() 
        {
            NewTaskWindow newTaskWindow = new NewTaskWindow();
            newTaskWindow.ShowDialog();
        }

        

        



        protected virtual void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private TaskImportance _importance;
        public TaskImportance Importance
        {
            get => _importance;
            set
            {
                if (_importance != value)
                {
                    _importance = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Importance)));
                }
            }
        }

    }
}
