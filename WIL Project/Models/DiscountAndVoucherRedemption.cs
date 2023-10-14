namespace WIL_Project.Models
{
    public class DiscountAndVoucherRedemption
    {
        public int RedemptionID { get; set; }
        public int UserID { get; set; }
        public string Code { get; set; }
        public DateTime RedemptionDate { get; set; }

        // Navigation properties for related user and discount
        public UserInformation UserInformation { get; set; }
        public DiscountAndVoucher DiscountAndVoucher { get; set; }
    }
}
