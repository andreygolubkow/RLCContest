#region Using
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace Tools
{
    public static class DataSerializer
    {
        #region Public Methods
        public static void DeserializeBin<T>(string fileName, ref T container)
        {
            var formatter = new BinaryFormatter();
            using (var deserializeFile = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (deserializeFile.Length > 0)
                {
                    container = (T)formatter.Deserialize(deserializeFile);
                    deserializeFile.Close();
                }
                else
                {
                    throw new ArgumentException("Файл пустой");
                }
            }
        }

        public static void SerializeBin<T>(string fileName, T container)
        {
            var formatter = new BinaryFormatter();
            using (var serializeFileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(serializeFileStream, container);
            }
        }

        #endregion
    }
    }
