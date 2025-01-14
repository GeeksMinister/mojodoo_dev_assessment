﻿using TasksManagementSystem.DataAccess.DbAccess;
using TasksManagementSystem.Models;

namespace TasksManagementSystem.DataAccess.Data.TodoData;
public class TodoData : ITodoData
{
    private readonly ISqlDataAccess _dbContext;
    public TodoData(ISqlDataAccess dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Todo>> GetAll()
    {
        return await _dbContext.LoadData<Todo, object>("SELECT * FROM Todo", new { });
    }

    public async Task<IEnumerable<Todo>> SearchTodo(string status, string tag, string searchTerm)
    {
        string query = "SELECT * FROM Todo WHERE Status = @status OR Tag = @tag OR" +
            "(TaskName LIKE '%' || @searchTerm || '%' OR Description LIKE '%' || @searchTerm || '%')";
        return await _dbContext.LoadData<Todo, object>(query, new { status, tag, searchTerm });
    }

    public async Task<Todo> GetById(int? id)
    {
        string query = "SELECT * FROM Todo WHERE Id = @Id";
        var result = await _dbContext.LoadData<Todo, object>(query, new { Id = id });
        return result.FirstOrDefault()!;
    }

    public async Task InsertTodo(Todo todo)
    {
        string query = "INSERT INTO Todo (TaskName, Description, Priority, Status, Tag) " +
                       "VALUES(@TaskName, @Description, @Priority, @Status, @Tag)";
        await _dbContext.SaveData(query, new
        {
            todo.TaskName,
            todo.Description,
            todo.Priority,
            todo.Status,
            todo.Tag
        });
    }

    public async Task UpdateTodo(Todo todo)
    {
        string query = "UPDATE Todo Set TaskName = @TaskName, Description = @Description, " +
                       "Priority = @Priority, Status = @Status, Tag = @Tag WHERE Id = @Id";
        await _dbContext.SaveData(query, todo);
    }

    public async Task DeleteTodo(int? id)
    {
        string query = "DELETE FROM Todo WHERE Id = @Id";
        await _dbContext.SaveData(query, new { Id = id });
    }



}

