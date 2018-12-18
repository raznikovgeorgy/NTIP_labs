using System;
using System.IO;
using Newtonsoft.Json;


namespace ContactsApp
{
    /// <summary>
    /// Класс, отвечающий за сериализацию и десериализацию. Выполняет загрузку/сохранение объекта
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Метод, реализующий сохранение файла, путём сериализации 
        /// </summary>
        /// <param name="_project">Объект, который нужно сохранить</param>
        /// <param name="filePath">Путь, куда будем сохранять</param>
        public static void SaveFile(Project _project, string filePath)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(_project));
        }

        /// <summary>
        /// Метод, реализующий загрузку файла, путём десериализации 
        /// </summary>
        /// <param name="filePath">Путь к файлу, который нужно загрузить</param>
        /// <returns></returns>
        public static Project LoadFile(string filePath)
        {
            try
            {
                return JsonConvert.DeserializeObject<Project>(File.ReadAllText(filePath));
            }
            catch (Exception exception)
            {
                return  new Project();
            }
        }
    }
}
