using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListStorageLogic
{
    public interface IStorageFactory
    {
        IStorage Create();
    }
}
