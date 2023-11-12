using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace StreamApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "client_import.csv";
            string outputFilePath = "result.txt";
            List<string[]> data = new List<string[]>();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string[] row = reader.ReadLine().Split(';');
                    string lastName = row[0].Trim();
                    string firstName = row[1].Trim();
                    string middleName = row[2].Trim();
                    int gender = (row[3].ToLower() == "м" || row[3].ToLower() == "мужской") ? 1 : 2;
                    string phone = new string(row[4].Where(char.IsDigit).ToArray());
                    string fileName = Path.GetFileName(row[5]);
                    DateTime birthDate = DateTime.Parse(row[6]);
                    string formattedBirthDate = birthDate.ToString("dd.MM.yyyy");
                    string email = row[7].Trim().ToLower();
                    DateTime regDate = DateTime.Parse(row[8]);
                    string formattedRegDate = regDate.ToString("dd.MM.yyyy");
                    string[] newRow = { lastName, firstName, middleName, gender.ToString(), phone, fileName, formattedBirthDate, email, formattedRegDate };
                    data.Add(newRow);
                }
            }
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Фамилия;Имя;Отчество;Пол;Телефон;Имя файла;Дата рождения;Email;Дата регистрации");
                foreach (string[] row in data)
                {
                    writer.WriteLine(string.Join(";", row));
                }
            }
            Console.WriteLine("Операция завершена успешно.");
            Console.ReadKey();
        }
    }
}
