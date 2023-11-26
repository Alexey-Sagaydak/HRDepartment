using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class HiringDocumentCreator
    {
        public void FillAndSaveDocument(string templatePath, string outputPath, string lastName, string firstName, string middleName)
        {
            // Создаем объект приложения Word
            var wordApp = new Application();

            try
            {
                // Открываем существующий документ
                var document = wordApp.Documents.Open(templatePath);

                // Заменяем метки на реальные данные
                ReplaceText(document, "[LastName]", lastName);
                ReplaceText(document, "[FirstName]", firstName);
                ReplaceText(document, "[MiddleName]", middleName);

                // Сохраняем документ
                document.SaveAs2(outputPath);
                document.Close();
            }
            finally
            {
                // Закрываем приложение Word
                wordApp.Quit();
            }

            Console.WriteLine($"Документ успешно создан и сохранен по пути: {outputPath}");
        }

        private static void ReplaceText(Document doc, string placeholder, string value)
        {
            // Используем Find and Replace для замены текста в документе
            var find = doc.Content.Find;
            find.Text = placeholder;
            find.Replacement.Text = value;

            // Выполняем замену
            find.Execute(Replace: WdReplace.wdReplaceAll);
        }
    }
}
