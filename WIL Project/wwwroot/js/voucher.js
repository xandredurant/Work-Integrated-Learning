document.addEventListener('DOMContentLoaded', function () {
    const vouchers = document.querySelectorAll('.voucher');
    const voucherDetails = document.querySelectorAll('.voucher-details');

    vouchers.forEach((voucher, index) => {
        voucher.addEventListener('click', () => {
            // Toggle the display of voucher details
            voucherDetails[index].classList.toggle('show-details');

            // Check if any other voucher details are open
            const otherOpenDetails = Array.from(voucherDetails).filter((detail, i) => i !== index && detail.classList.contains('show-details'));

            if (otherOpenDetails.length > 0) {
                // If other voucher details are open, arrange them horizontally
                otherOpenDetails.forEach((detail) => {
                    detail.classList.remove('show-details');
                    detail.style.left = '0';
                });
                voucherDetails[index].style.left = '50%';
            } else {
                // If no other voucher details are open, reset the layout
                voucherDetails.forEach((detail) => {
                    detail.style.left = '0';
                });
            }
        });
    });
});
