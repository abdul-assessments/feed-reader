using FeedReader.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FeedReader.Core.Services
{
    public class JsonDataService : IDataService
    {
        private string _fileLocation;
        public JsonDataService(string fileLocation)
        {
            _fileLocation = fileLocation;
            
        }
        public List<TData> GetStorage<TData>()
        {
            try
            {
                return JsonSerializer.Deserialize<List<TData>>(File.ReadAllText(_fileLocation));
            }
            catch
            {
                return new List<TData>();
            }
        }

        public void UpdateStorage(object data)
        {
           File.WriteAllText(_fileLocation, JsonSerializer.Serialize(data));
        }
    }
}
