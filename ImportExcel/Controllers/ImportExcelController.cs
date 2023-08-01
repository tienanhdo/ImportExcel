using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Globalization;

namespace ImportExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportExcelController : ControllerBase
    {
        private readonly ImportExcelDBContext _ImportExcelDBContext;
        public ImportExcelController(ImportExcelDBContext ImportExcelDBContext)
        {
            _ImportExcelDBContext = ImportExcelDBContext;
        }
        [HttpPost("import")]
        public async Task<IActionResult> Import([FromForm] FileUploadModel fileModel)
        {
            try
            {
                if (fileModel == null || fileModel.File == null || fileModel.File.Length == 0)
                {
                    return BadRequest("Vui lòng chọn tệp Excel.");
                }

                using (var package = new ExcelPackage(fileModel.File.OpenReadStream()))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                    if (worksheet == null)
                    {
                        return BadRequest("Không tìm thấy worksheet trong tệp Excel.");
                    }


                    List<ExcelDataModel> dataList = new List<ExcelDataModel>();

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 4; row <= rowCount; row++)
                    {
                        var a = row;
                       //đọc dữ liệu từ file excel
                        ExcelDataModel data = new ExcelDataModel
                        {

                            Date = ParseDateTime(worksheet.Cells[row, 1].Value?.ToString()),
                            STK_ID = (worksheet.Cells[row, 2].Value?.ToString()),
                            STK_NAME = worksheet.Cells[row, 3].Value?.ToString(),
                            Ma_NH = worksheet.Cells[row, 4].Value?.ToString(),
                            Ten_NH = worksheet.Cells[row, 5].Value?.ToString(),
                            SKU_ID = (worksheet.Cells[row, 6].Value?.ToString()),
                            SKU_CODE = worksheet.Cells[row, 7].Value?.ToString(),
                            BARCODE = worksheet.Cells[row, 8].Value?.ToString(),
                            FULL_NAME = worksheet.Cells[row, 9].Value?.ToString(),
                            ĐVT = worksheet.Cells[row, 10].Value?.ToString(),
                            Ma_Thue_Suat = worksheet.Cells[row, 11].Value?.ToString(),
                            Ton_Kho = int.Parse(worksheet.Cells[row, 12].Value?.ToString()),
                            Gia_Tri_Ton = decimal.Parse(worksheet.Cells[row, 13].Value?.ToString())


                        };

                        dataList.Add(data);
                    }

                    _ImportExcelDBContext.AddRange(dataList);
                    await _ImportExcelDBContext.SaveChangesAsync();

                    // Xử lý dữ liệu, ví dụ: lưu vào cơ sở dữ liệu
                    // YourDataRepository.Save(dataList);

                    return Ok(dataList);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi xảy ra trong quá trình xử lý tệp Excel: {ex.Message}");
            }
        }



        // Phương thức chuyển đổi chuỗi ngày thành đối tượng DateTime
        private static DateTime ParseDateTime(string dateString)
        {
            // Các định dạng ngày tháng có thể xuất hiện trong tệp Excel
            string[] formats = { "dd/M/yyyy", "dd/MM/yyyy", "d/M/yyyy", "d/MM/yyyy" };

            DateTime parsedDate;

            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }
            else
            {
                // Nếu không thể chuyển đổi, bạn có thể xử lý hoặc thông báo lỗi tùy ý
                throw new ArgumentException($"Không thể chuyển đổi chuỗi '{dateString}' thành đối tượng DateTime hợp lệ.");
            }

        }
    }
    public class FileUploadModel
    {
        public IFormFile File { get; set; }
    }

}
