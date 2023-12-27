using CurdTask.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace CurdTask.PL.Helpers
{
    public  class ReportGenrator
    {
        public static  DataTable GenerateExcel(string fileName,IEnumerable<EmployeeToReturnViewModel> employees)
        {
            DataTable dataTable = new DataTable("Employee");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id"),
                new DataColumn("Name"),
                new DataColumn("Salary"),
                new DataColumn("City"),
                new DataColumn("SubCity"),
                new DataColumn("Villag")
            });

            foreach (var employee in employees)
                dataTable.Rows.Add(employee.EmployeeId,
                    employee.Name,employee.Salary,employee.CityName,
                    employee.SubCityName,employee.VillageName);

            return dataTable;
        }

        public static FileStreamResult ExportToPdf(EmployeeToReturnViewModel employee)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (PdfDocument document = new PdfDocument())
                {
                    // Add a page to the document
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Set font and format
                    XFont font = new XFont("Verdana", 12);
                    XStringFormat format = XStringFormat.TopLeft;
                   
                    // Add data to the PDF
                    gfx.DrawString($"Employee {employee.EmployeeId} Data", font, XBrushes.Black, new XRect(10, 10, page.Width, page.Height), format);
                    gfx.DrawString($"ID: {employee.EmployeeId}", font, XBrushes.Black, new XRect(10, 30, page.Width, page.Height), format);
                    gfx.DrawString($"Employee Name: {employee.Name}", font, XBrushes.Black, new XRect(10, 50, page.Width, page.Height), format);
                    gfx.DrawString($"Salary: {employee.Salary}", font, XBrushes.Black, new XRect(10, 70, page.Width, page.Height), format);
                    gfx.DrawString($"City: {employee.CityName}", font, XBrushes.Black, new XRect(10, 90, page.Width, page.Height), format);
                    gfx.DrawString($"Sub City: {employee.SubCityName}", font, XBrushes.Black, new XRect(10, 110, page.Width, page.Height), format);
                    gfx.DrawString($"Village: {employee.VillageName}", font, XBrushes.Black, new XRect(10, 130, page.Width, page.Height), format);
                    document.Save(memoryStream);
                }

                memoryStream.Position = 0;

                return new FileStreamResult(memoryStream, "application/pdf")
                {
                    FileDownloadName = "ExportedEmployeeData.pdf"
                };
            }
        }


    }
}
