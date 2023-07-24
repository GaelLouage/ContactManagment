using ContactManagementSystem.Base;
using ContactManagementSystem.Entities;
using ContactManagementSystem.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ContactManagementSystem.Services.Classes
{
    public class JsonService<T> : IJsonService<T> 
    {
        private string _jsonFileName;
        private List<T> _listData = new List<T>();
        public JsonService(string jsonFileName)
        {
            _jsonFileName = $"{jsonFileName}.json";
            if (!File.Exists(_jsonFileName))
            {
                var fs = File.Create(_jsonFileName);
                var dummyData = new List<ContactEntity>()
            {
                new ContactEntity() { Id = Guid.NewGuid(), Email= "test@hotmail.com", Name ="Tester1"},
                new ContactEntity() { Id = Guid.NewGuid(), Email= "test@hotmail.com", Name ="Tester2"},
                new ContactEntity() { Id = Guid.NewGuid(), Email= "test@hotmail.com", Name ="Tester3"}
            };
                fs.Close();

                var jsonSerialize = JsonConvert.SerializeObject(dummyData);

                using (var fw = new StreamWriter(_jsonFileName))
                {
                    fw.Write(jsonSerialize);
                }
            }
    }
    public async Task<List<T>> GetAllContactsAsync()
    {
        using (var fs = new StreamReader(_jsonFileName))
        {
            var allData = await fs.ReadToEndAsync();
            _listData = JsonConvert.DeserializeObject<List<T>>(allData);
        }

        if (_listData is null)
        {
            return new List<T>();
        }
        return _listData;
    }
    public async Task<T> CreateDataAsync(T data, string name)
    {
        var contactToUpdate = (await GetAllContactsAsync());
    
        if (contactToUpdate.Any(x => (string)x.GetType().GetProperty("Name").GetValue(x) == name))
        {
             throw new ContactAlreadyExistsException("Contact with the same name already exists.");
        }
        _listData.Add(data);
        await UpateFileAsync(_listData);
        return data;
    }
    public async Task UpdateDataAsync(T data, Guid id)
    {
            var toUpdate = _listData.FirstOrDefault(x => (Guid)x.GetType().GetProperty("Id").GetValue(x) == id);
            toUpdate = data;
            await UpateFileAsync(_listData);
    }

        public async Task DeleteDataAsync( Guid id)
        {
            var toUpdate = _listData.Remove(_listData.FirstOrDefault(x => (Guid)x.GetType().GetProperty("Id").GetValue(x) == id));

            await UpateFileAsync(_listData);
        }

        public async Task<List<T>> UpateFileAsync(List<T> data)
    {
        var jsonSerialize = JsonConvert.SerializeObject(data);

        using (var fw = new StreamWriter(_jsonFileName))
        {
            await fw.WriteLineAsync(jsonSerialize);
        }

        return await GetAllContactsAsync();
    }

        public async Task<T> GetDataByIdAsync(Guid id)
        {
            return (await GetAllContactsAsync()).FirstOrDefault(x => (Guid)x.GetType().GetProperty("Id").GetValue(x) == id);
        }
    }
}
