
using Project.Common.TaskItemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ITaskRepository
    {
        Task Create(TaskModel taskModel);
        Task<List<TaskModel>> GetAllTasks();
        Task Delete(int id);
        Task<string> Update(int id, TaskModel aaa);
    }

}