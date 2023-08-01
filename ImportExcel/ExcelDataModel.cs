using System.ComponentModel.DataAnnotations;

namespace ImportExcel
{
    public class ExcelDataModel
    {
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string STK_ID { get; set; }
        public string STK_NAME { get; set; }
        public string Ma_NH { get; set; }
        public string Ten_NH { get; set; }
        public string SKU_ID { get; set; }
        public string SKU_CODE { get; set; }
        public string BARCODE { get; set; }
        public string FULL_NAME { get; set; }
        public string ĐVT { get; set; }
        public string Ma_Thue_Suat { get; set; }
        public int Ton_Kho { get; set; }
        public decimal Gia_Tri_Ton { get; set; }
    }
}
