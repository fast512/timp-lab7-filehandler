using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    /// <summary>
    /// Вся работа с текстовыми файлами из папки Data
    /// </summary>
    public class FileDataService
    {
        private readonly string _dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private readonly Encoding _enc = new UTF8Encoding(false);

        public bool TeachersFileExists => File.Exists(Path.Combine(_dataFolder, "teachers.txt"));

        /// <summary>
        /// Читает teachers.txt: логин;пароль;ФИО;кафедра
        /// </summary>
        public List<Teacher> LoadTeachers()
        {
            List<Teacher> teachers = new();
            string teachersPath = Path.Combine(_dataFolder, "teachers.txt");
            if (!File.Exists(teachersPath)) { return teachers; }

            using (StreamReader reader = new StreamReader(teachersPath, _enc))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split(";");
                    if (parts.Length < 4) { continue; }

                    teachers.Add(new Teacher()
                    {
                        Login = parts[0].Trim(),
                        Password = parts[1].Trim(),
                        FullName = parts[2].Trim(),
                        Department = parts[3].Trim()
                    });
                }
            }
            return teachers;
        }
    }
}
