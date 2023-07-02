using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public static class ClassService
    {
        public static List<Class> GetClassList(string fileName = Config.classFilePath)
        {
            List<Class> result = new();
            List<string> data = File.ReadAllLines(fileName).ToList();

            foreach (var item in data)
            {
                List<string> classInfo = item.Split(" /-/ ", StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(
                    new Class
                    {
                        Id = int.Parse(classInfo[0]),
                        Name = classInfo[1]
                    }
                );
            }
            return result;
        }
    }
}
