﻿using TasksManagementSystem.Models;

namespace TasksManagementSystem.DataAccess.Data.TodoData
{
    public interface ITodoData
    {
        Task<IEnumerable<Todo>> GetAll();
        Task InsertTodo(Todo todo);
        Task<Todo> GetById(int? id);
        Task DeleteTodo(int? id);
        Task UpdateTodo(Todo todo);
    }
}