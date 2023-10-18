using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using WIL_Project.DBContext;
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class VoucherController : Controller
    {
        private DBContext.MyDbContext _context; // Replace ApplicationDbContext with your actual DbContext

        public VoucherController(DBContext.MyDbContext dbContext)
        {
            _context = dbContext; // Initialize your DbContext
        }

        // GET: Voucher
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddVoucher(string voucherCode)
        {
            // Assuming voucherCode is submitted from the form

            // Find the voucher in the database
            var voucher = _context.DiscountVoucher.FirstOrDefault(v => v.Code == voucherCode);

            if (voucher != null && IsValidRedemption(voucher))
            {
                // Update the voucher usage information
                voucher.TimesUsed++;
                _context.SaveChanges();

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                // Create a redemption entry
                var redemption = new DiscountVoucherRedemption
                {
                    Id = userId,
                    Code = voucherCode,
                    RedemptionDate = DateTime.Now
                };

                // Add redemption entry to the database
                _context.DiscountVoucherRedemption.Add(redemption);
                _context.SaveChanges();

                // Optionally, you can redirect to a success page or return a success message
                return RedirectToAction("Success"); // Replace with your actual action and controller
            }

            // Handle invalid voucher code (e.g., display an error message)
            ModelState.AddModelError("voucher-code", "Invalid voucher code");
            return View("Index");
        }

        private bool IsValidRedemption(DiscountVoucher voucher)
        {
            // Implement any additional validation logic for redemption (e.g., expiration date, user limits)
            // Return true if the redemption is valid, otherwise return false
            return voucher.ValidTo >= DateTime.Now && voucher.LimitPerUser > voucher.TimesUsed;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
