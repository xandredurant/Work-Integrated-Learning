using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WIL_Project.Models
{
    [Table("DiscountVoucherRedemption")]
    public class DiscountVoucherRedemption
    {
        [Key]
        public int RedemptionID { get; set; }
        [ForeignKey("UserInfo")]
        public int UserID { get; set; }
        [ForeignKey("DiscountVoucher")]
        public string Code { get; set; }
        public DateTime RedemptionDate { get; set; }

        // Navigation properties for related user and discount
        public UserInfo UserInfo { get; set; }
        public DiscountVoucher DiscountVoucher { get; set; }
    }
}
