using E01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E01.Data
{
    interface ITodoService
    {
       Task<IList<Todo>> GetTodosAsync();
        Task AddTodoAsync(Todo todo);
        Task RemoveTodoAsync(int todoId);
        Task UpdateAsync(Todo todo);
    }
}
