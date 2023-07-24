using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManagementSystem.Services.Interfaces
{
    public interface IJsonService<T>
    {
        Task<T> CreateDataAsync(T data, string name);
        Task<List<T>> GetAllContactsAsync();
        Task UpdateDataAsync(T data, Guid id);
        Task<List<T>> UpateFileAsync(List<T> data);
        Task DeleteDataAsync(Guid id);
        Task<T> GetDataByIdAsync(Guid id);
    }
}