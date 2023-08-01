using ImportExcel.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ImportExcel
{
    public class ImportExcelDBContext : DbContext
    {
        public ImportExcelDBContext(DbContextOptions<ImportExcelDBContext> options) : base(options)
        {
        }

        public DbSet<ExcelDataModel> ExcelDataModels { get; set; }
    }
}