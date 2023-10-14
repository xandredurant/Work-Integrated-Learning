namespace WIL_Project.Models
{
    public class DiscountVoucherRedemption
    {
        public int RedemptionID { get; set; }
        public int UserID { get; set; }
        public string Code { get; set; }
        public DateTime RedemptionDate { get; set; }

        // Navigation properties for related user and discount
        public UserInfo UserInfo { get; set; }
        public DiscountVoucher DiscountVoucher { get; set; }
    }
}
