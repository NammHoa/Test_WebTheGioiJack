using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamHuynhHoaNam_22DH112245_TestScript
{
    internal class ExcelDataProvider
    {
        private static DataTable _excelDataTable;
        private static DataTable ReadExcel(string filePath)
        {
            if (_excelDataTable != null)
                return _excelDataTable;
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet dataSet = reader.AsDataSet();

                    _excelDataTable = dataSet.Tables[0];

                    return _excelDataTable;
                }
            }
        }
        public static IEnumerable<TestCaseData> GetTestCaseDatasFromExcel()
        {
            var testData = new List<TestCaseData>();
            DataTable excelDataTable = ReadExcel("LamHuynhHoaNam_22DH112245.xlsx");

            for (int i = 1; i < excelDataTable.Rows.Count; i++)
            {
                var a = excelDataTable.Rows[i][0];
                var b = excelDataTable.Rows[i][1];
                var expected = excelDataTable.Rows[i][2];

                testData.Add(new TestCaseData(a, b, expected));
            }
            return testData;
        }
        private static int rowStart = 2;
        private static int colIndexActual = 7;
        public static void WriteResultExcel(string filePath, string sheetName, string actuals, string result)
        {
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName] ?? package.Workbook.Worksheets.Add(sheetName);

                    int newRow = 2; // Luôn bắt đầu từ dòng 2
                    while (!string.IsNullOrEmpty(worksheet.Cells[newRow, colIndexActual].Text))
                    {
                        newRow++; // Nếu dòng đó đã có dữ liệu, tìm dòng trống tiếp theo
                    }

                    worksheet.Cells[newRow, colIndexActual].Value = actuals;
                    worksheet.Cells[newRow, colIndexActual + 1].Value = result;

                    package.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi vào file Excel: {ex.Message}");
            }
        }
    }
}

        