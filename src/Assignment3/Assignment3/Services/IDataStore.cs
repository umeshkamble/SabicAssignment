using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment3.Services
{
    public interface IDataStore<T>
    {
        //Task<bool> AddItemAsync(T item);
        //Task<bool> UpdateItemAsync(T item);
        //Task<bool> DeleteItemAsync(string id);
        Task<T> GetControlAsync(string Name);
        Task<IEnumerable<T>> GetControlsAsync();
    }
}
