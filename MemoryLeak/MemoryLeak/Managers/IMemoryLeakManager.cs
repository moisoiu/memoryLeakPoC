using MemoryLeak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryLeak.Managers
{
    public interface IMemoryLeakManager
    {
        Task GenerateMemoryLeakObjectViaConcurentBag();

        Task GenerateMemoryLeak();

    }
}
