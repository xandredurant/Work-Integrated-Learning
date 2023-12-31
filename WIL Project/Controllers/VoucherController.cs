﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using WIL_Project.DBContext;
using WIL_Project.Models;
using WIL_Project.ViewModels;

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
          var vm = new VoucherViewModel
          {
              DiscountVouchers = _context.DiscountVoucher.ToList(),
              DiscountVoucherRedemptions = _context.DiscountVoucherRedemption.ToList(),
          };


            return View(vm);
        }

        public IActionResult Success()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddVoucher(string voucherCode, DiscountVoucherRedemption redemption)
        {
            // Assuming voucherCode is submitted from the form

            // Find the voucher in the database
            var voucher = _context.DiscountVoucher.FirstOrDefault(v => v.Code == voucherCode);

            if (voucher != null)
            {
                // Update the voucher usage information
                voucher.TimesUsed++;
                _context.SaveChanges();

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


                // Create a redemption entry
                redemption.Id = userId;
                redemption.Code = voucherCode;
                redemption.RedemptionDate = DateTime.Now;


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
