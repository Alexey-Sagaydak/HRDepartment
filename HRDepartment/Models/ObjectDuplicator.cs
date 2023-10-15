using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HRDepartment
{
    public class ObjectDuplicator
    {
        public static T DuplicateObject<T>(T obj)
        {
            if (obj == null)
            {
                return default(T); // Возвращаем значение по умолчанию для типа T
            }

            string json = JsonConvert.SerializeObject(obj);
            T clonedObject = JsonConvert.DeserializeObject<T>(json);
            return clonedObject;
        }
    }
}
