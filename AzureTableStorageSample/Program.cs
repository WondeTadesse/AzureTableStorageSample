//|---------------------------------------------------------------|
//|                         AZURE TABLE STORAGE                   |
//|---------------------------------------------------------------|
//|                       Developed by Wonde Tadesse              |
//|                             Copyright ©2017 - Present         |
//|---------------------------------------------------------------|
//|                         AZURE TABLE STORAGE                   |
//|---------------------------------------------------------------|

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTableStorageSample
{
    class Program
    {
        static void Main(string[] args)
        {
            new AzureTableStorageProcessor().ProcessTableStorage();
        }
    }
}
