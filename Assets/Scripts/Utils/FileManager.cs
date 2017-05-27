
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    class FileManager
    {
        private static BinaryFormatter bf = new BinaryFormatter();
        private static FileStream file;

        public static void Save(UnityEngine.Object objectToSave, Type clazz, string fileName)
        {  
            file = File.Create(Application.persistentDataPath + "/" + fileName + ".dat");      

            bf.Serialize(file, Convert.ChangeType(objectToSave, clazz));

            file.Close();

            
        }

        public static void Save(System.Object objectToSave, Type clazz, string fileName)
        {                 
            file = File.Create(Application.persistentDataPath + "/" + fileName + ".dat");          

            bf.Serialize(file, Convert.ChangeType(objectToSave, clazz));

            file.Close();
        }

        public static T Load<T>(string fileName)
        {
            if (File.Exists(Application.persistentDataPath + "/" + fileName + ".dat"))
            {
                file = File.Open(Application.persistentDataPath + "/" + fileName + ".dat", FileMode.Open);             

                return (T)bf.Deserialize(file);
            }

            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
