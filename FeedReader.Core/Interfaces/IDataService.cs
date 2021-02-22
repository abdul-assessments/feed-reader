using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Core.Interfaces
{
    public interface IDataService
    {
        List<TData> GetStorage<TData>();
        void UpdateStorage(object data);
    }
}
