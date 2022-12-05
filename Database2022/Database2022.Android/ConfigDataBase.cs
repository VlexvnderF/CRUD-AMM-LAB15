using Database2022.Droid;
using Database2022.Interfaces;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(ConfigDataBase))]
namespace Database2022.Droid
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);                  
        }
    }
}