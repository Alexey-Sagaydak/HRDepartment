using System;
using System.Collections.Generic;
using System.Linq;
using Xceed.Words.NET;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using System.Reflection.Metadata;

namespace CommonClasses
{
    public class DocumentCreator
    {
        public void Query1Document(IEnumerable<PersonWithHours> people, string outPath)
        {
            using (var doc = DocX.Create(outPath))
            {
                var title = doc.InsertParagraph();
                title.Alignment = Alignment.center;
                title.Append("Сведения о трудовом стаже сотрудников на текущую дату.\n")
                    .FontSize(14)
                    .Bold()
                    .Font(new Font("Times New Roman"));

                var table = doc.AddTable(1, 4);
                table.Alignment = Alignment.center;
                table.Rows[0].Cells[0].Paragraphs.First().Append("Фамилия").FontSize(12).Bold().Font(new Font("Times New Roman"));
                table.Rows[0].Cells[1].Paragraphs.First().Append("Имя").FontSize(12).Bold().Font(new Font("Times New Roman"));
                table.Rows[0].Cells[2].Paragraphs.First().Append("Отчество").FontSize(12).Bold().Font(new Font("Times New Roman"));
                table.Rows[0].Cells[3].Paragraphs.First().Append("Трудовой стаж (дн)").FontSize(12).Bold().Font(new Font("Times New Roman"));

                foreach (var person in people)
                {
                    var row = table.InsertRow();
                    row.Cells[0].Paragraphs.First().Append(person.Surname).FontSize(12).Font(new Font("Times New Roman"));
                    row.Cells[1].Paragraphs.First().Append(person.Name).FontSize(12).Font(new Font("Times New Roman"));
                    row.Cells[2].Paragraphs.First().Append(person.MiddleName).FontSize(12).Font(new Font("Times New Roman"));
                    row.Cells[3].Paragraphs.First().Append(person.Hours.ToString()).FontSize(12).Font(new Font("Times New Roman"));
                }
                doc.InsertTable(table);

                doc.InsertParagraph().Append($"\n\n\nДата: {DateTime.Now.ToShortDateString()}\t\t\t\t\tПодпись: ________________").FontSize(12).Font(new Font("Times New Roman"));

                doc.Save();
            }
        }

        public void Query2Document(IEnumerable<Person> people, string outPath)
        {
            using (var doc = DocX.Create(outPath))
            {
                var title = doc.InsertParagraph();
                title.Alignment = Alignment.center;
                title.Append("Сведения о сотрудниках, которые должны быть направлены в отпуск в декабре.\n")
                    .FontSize(14)
                    .Bold()
                    .Font(new Font("Times New Roman"));

                var table = doc.AddTable(1, 3);
                table.Alignment = Alignment.center;
                table.Rows[0].Cells[0].Paragraphs.First().Append("Фамилия").FontSize(12).Bold().Font(new Font("Times New Roman"));
                table.Rows[0].Cells[1].Paragraphs.First().Append("Имя").FontSize(12).Bold().Font(new Font("Times New Roman"));
                table.Rows[0].Cells[2].Paragraphs.First().Append("Отчество").FontSize(12).Bold().Font(new   Font("Times New Roman"));

                foreach (var person in people)
                {
                    var row = table.InsertRow();
                    row.Cells[0].Paragraphs.First().Append(person.Surname).FontSize(12).Font(new Font("Times New Roman"));
                    row.Cells[1].Paragraphs.First().Append(person.Name).FontSize(12).Font(new Font("Times New Roman"));
                    row.Cells[2].Paragraphs.First().Append(person.MiddleName).FontSize(12).Font(new Font("Times New Roman"));
                }
                doc.InsertTable(table);

                doc.InsertParagraph().Append($"\n\n\nДата: {DateTime.Now.ToShortDateString()}\t\t\t\t\tПодпись: ________________").FontSize(12).Font(new Font("Times New Roman"));

                doc.Save();
            }
        }
        public void Query3Document(IEnumerable<Person> people, string outPath)
        {
            using (var doc = DocX.Create(outPath))
            {
                var title = doc.InsertParagraph();
                title.Alignment = Alignment.center;
                title.Append("Сведения о сотрудниках, не проходивших повышение квалификации в течение прошедшего года или не имеющих высшего образования.\n")
                    .FontSize(14)
                    .Bold()
                    .Font(new Font("Times New Roman"));

                var table = doc.AddTable(1, 3);
                table.Alignment = Alignment.center;
                table.Rows[0].Cells[0].Paragraphs.First().Append("Фамилия").FontSize(12).Bold().Font(new Font("Times New Roman"));
                table.Rows[0].Cells[1].Paragraphs.First().Append("Имя").FontSize(12).Bold().Font(new Font("Times New Roman"));
                table.Rows[0].Cells[2].Paragraphs.First().Append("Отчество").FontSize(12).Bold().Font(new Font("Times New Roman"));

                foreach (var person in people)
                {
                    var row = table.InsertRow();
                    row.Cells[0].Paragraphs.First().Append(person.Surname).FontSize(12).Font(new Font("Times New Roman"));
                    row.Cells[1].Paragraphs.First().Append(person.Name).FontSize(12).Font(new Font("Times New Roman"));
                    row.Cells[2].Paragraphs.First().Append(person.MiddleName).FontSize(12).Font(new Font("Times New Roman"));
                }
                doc.InsertTable(table);

                doc.InsertParagraph().Append($"\n\n\nДата: {DateTime.Now.ToShortDateString()}\t\t\t\t\tПодпись: ________________").FontSize(12).Font(new Font("Times New Roman"));

                doc.Save();
            }
        }
    }
}