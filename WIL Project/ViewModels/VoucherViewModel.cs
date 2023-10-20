using WIL_Project.Models;

namespace WIL_Project.ViewModels
{
    public class VoucherViewModel
    {
        public List<DiscountVoucher> DiscountVouchers { get; set; }
        public List<DiscountVoucherRedemption> DiscountVoucherRedemptions { get; set; }
    }
}