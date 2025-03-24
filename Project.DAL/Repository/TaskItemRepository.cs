using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Project.Common.TaskItemModel;
using Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(TaskModel taskModel)
        {
            var taskitem = new TaskModel
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                IsCompleted = taskModel.IsCompleted,
                CreatedAt = DateTime.Now
            };
            _context.TaskModels.Add(taskModel);
            await _context.SaveChangesAsync();
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _context.TaskModels.ToListAsync();
        }
        

        public async Task Delete(int id)
        {
            var task = await _context.TaskModels.FindAsync(id);
            if (task != null)
            {
                _context.TaskModels.Remove(task);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<string> Update(int id, TaskModel aaa)
        {
            var task = await _context.TaskModels.FindAsync(id);
            if (task != null)
            {
                task.Title = aaa.Title;
                task.Description = aaa.Description;
                task.IsCompleted = aaa.IsCompleted;

                await _context.SaveChangesAsync();
                return "Done";
            }
            return "Try Again";
        }


    }

}

