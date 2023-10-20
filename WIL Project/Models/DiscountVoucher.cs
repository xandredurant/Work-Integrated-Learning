using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WIL_Project.Models
{
    [Table("DiscountVoucher")]
    public class DiscountVoucher
    {
        [Key]
        public string Code { get; set; }
        public string DiscountType { get; set; }
        public string Visibility { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LimitPerUser { get; set; }
        public int TimesUsed { get; set; }
        public string EventID { get; set; }
        public string percentoff { get; set; }
        public int value { get; set; }

        // Navigation property for redemptions related to this discount
        public List<DiscountVoucherRedemption> Redemptions { get; set; }
    }
}
