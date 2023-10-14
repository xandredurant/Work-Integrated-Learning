namespace WIL_Project.Models
{
    public class DiscountAndVoucher
    {
        public string Code { get; set; }
        public string DiscountType { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LimitPerUser { get; set; }
        public int TimesUsed { get; set; }
        public string ApplicableEvents { get; set; }

        // Navigation property for redemptions related to this discount
        public List<DiscountVoucherRedemption> Redemptions { get; set; }
    }
}
