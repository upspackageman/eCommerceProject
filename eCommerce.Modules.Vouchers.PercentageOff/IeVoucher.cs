namespace eCommerce.Modules.Vouchers.PercentOff
{
    public interface IeVoucher
    {
        int MinSpend { get; set; }
        int Value { get; set; }
        object VoucherCode { get; }
        object VoucherDescription { get; set; }
        object VoucherId { get; set; }

        void ProcessVoucher(IeVoucher voucher, IBasket basket, IBasketVoucher basketVoucher);


    };
}