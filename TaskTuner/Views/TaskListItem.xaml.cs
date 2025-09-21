using System.Windows;
using System.Windows.Controls;
using TaskTuner.Models;
using TaskTuner.ModelViews;

namespace TaskTuner.Views
{
    public partial class TaskListItem : UserControl
    {
        public TaskListItem()
        {
            InitializeComponent();
        }

        public TaskView Task
        {
            get => (TaskView)GetValue(TaskProperty);
            set => SetValue(TaskProperty, value);
        }

        public static readonly DependencyProperty TaskProperty =
    DependencyProperty.Register(nameof(TaskView), typeof(TaskView), typeof(TaskListItem),
        new PropertyMetadata(null));




    }
}
