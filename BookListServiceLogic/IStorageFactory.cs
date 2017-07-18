using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookListStorageLogic;

namespace BookListServiceLogic
{
    public interface IStorageFactory
    {
        IStorage Create();
    }
}
