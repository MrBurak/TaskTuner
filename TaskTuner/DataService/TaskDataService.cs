using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using TaskTuner.Models;



namespace TaskTuner.DataService
{
    public class TaskDataService
    {
        private readonly string filepath;
        private readonly string folderName = "TaskTuner";
        private readonly string fileName="tasks.json";
        private string appDataPath;
        public TaskDataService()
        {
            appDataPath = "C:\\TaskTurnerData";
            string appFolder = Path.Combine(appDataPath, folderName);
            string dataFolder=Path.Combine(appFolder, "data");

            if (!Directory.Exists(dataFolder)) 
            {
                Directory.CreateDirectory(dataFolder);
            }

            filepath=Path.Combine(dataFolder,fileName);

            InitializeFile();

        }

        private void InitializeFile() 
        {
            if (!File.Exists(filepath)) 
            {
                File.WriteAllText(filepath, JsonConvert.SerializeObject(new List<Models.Task>()));
            }
            //Process.Start(Path.Combine(appDataPath, filepath));

        }

        public List<Models.Task> LoadTask()
        {
            string fileContent = File.ReadAllText(filepath);
           return JsonConvert.DeserializeObject<List<Models.Task>>(fileContent);

        }

        public void SaveTasks(List<Models.Task> tasks)
        {
            File.WriteAllText(filepath, JsonConvert.SerializeObject(tasks));
        }

        public void AddTask(Models.Task task)
        {
            var tasks = LoadTask();
            task.Id = Guid.NewGuid();
            tasks.Add(task);
            SaveTasks(tasks);
        }

        public void UpdateTask(Models.Task task)
        {
            var tasks = LoadTask();
            var index=tasks.FindIndex(t=> t.Id==task.Id);
            if (index == -1) return;
            tasks[index]=task; 
            SaveTasks(tasks);
        }

        public void DeleteTask(Guid id)
        {
            var tasks = LoadTask();
            var index = tasks.FindIndex(t => t.Id == id);
            if (index == -1) return;
            tasks.RemoveAll(t => t.Id == id);
            SaveTasks(tasks);
        }
    }
    
}
