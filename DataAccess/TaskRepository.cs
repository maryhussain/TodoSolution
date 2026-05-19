using System.Collections.Generic;
using System.Linq;
using NTierTodoApp.Models;
namespace NTierTodoApp.DataAccess
    {
        // <summary>
        /// مستودع البيانات إلدارة المهام باستخدام قائمة في الذاكرة.
        /// </summary>
        public class TaskRepository
        {
            private List<TaskItem> tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "مهمة أولى", IsComplete = false },
                new TaskItem { Id = 2, Title = "مهمة ثانية", IsComplete = false }
            };

            public List<TaskItem> GetAll() => tasks;

            public void Add(TaskItem task)
            {
                tasks.Add(task);
            }

            public TaskItem GetById(int id)
            {
                return tasks.FirstOrDefault(t => t.Id == id);
            }

            //تنفيذ دالة تعديل عنوان المهمة 
            public void Edit(int id, string newTitle)
            {
                var task = GetById(id);
                if (task != null && !string.IsNullOrWhiteSpace(newTitle))
                {
                    task.Title = newTitle.Trim();
                }
            }

            public void Save() { }

            // TODO: تنفيذ دالة حذف المهمة
            public void Delete(int id)
            {        
                var task = GetById(id);
                if (task != null)
                {
                    tasks.Remove(task);
                }
        }
    }
}