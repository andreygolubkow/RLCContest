#region Using
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace Tools
{

    /// <summary>
    /// Класс сериализации. Позволяет сериализовать и десериализовать данные. 
    /// </summary>
    public static class DataSerializer
    {
        #region Public Methods

        /// <summary>
        /// Десериализует данные из файла.
        /// </summary>
        /// <typeparam name="T">Тип десериализуемых данных.</typeparam>
        /// <param name="fileName">Имя файла.</param>
        /// <param name="container">Контейнер, куда будет записано содержимое.</param>
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

        /// <summary>
        /// Сериализует данные в файл.
        /// </summary>
        /// <typeparam name="T">Тип сериализуемых данных.</typeparam>
        /// <param name="fileName">Имя файла.</param>
        /// <param name="container">Контейнер который требуется сериализовать.</param>
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
//TODO две последние закрывающие скобки не должны быть на одном уровне