using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CountMasters.SaveSystem
{
    public class SaveManager
    {
        public static void Save<T>(T objectToSave, string key)
        {
            SaveToFile<T>(objectToSave, key);
        }

        public static void Save(Object objectToSave, string key)
        {
            SaveToFile<Object>(objectToSave, key);
        }
        
        private static void SaveToFile<T>(T objectToSave, string fileName)
        {
            string path = Application.persistentDataPath + "/saves/";
            Directory.CreateDirectory(path);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path + fileName + ".txt", FileMode.Create);
            try
            {
                formatter.Serialize(fileStream, objectToSave);
            }
            catch (SerializationException exception)
            {
                Debug.LogError("Save failed. Error: " + exception.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }
        
        public static T Load<T>(string key)
        {
            string path = Application.persistentDataPath + "/saves/";
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Open);
            T returnValue = default(T);
            try
            {
                returnValue = (T) formatter.Deserialize(fileStream);
            }
            catch (SerializationException exception)
            {
                Debug.LogError("Load failed. Error: " + exception.Message);
            }
            finally
            {
                fileStream.Close();
            }

            return returnValue;
        }
    }
}