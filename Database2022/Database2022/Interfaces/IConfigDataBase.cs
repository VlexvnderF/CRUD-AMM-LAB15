using System;
using System.Collections.Generic;
using System.Text;

namespace Database2022.Interfaces
{
    public interface IConfigDataBase
    {
        string GetFullPath(string databaseFileName);
    }
}
