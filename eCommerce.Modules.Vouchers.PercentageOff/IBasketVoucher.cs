namespace eCommerce.Modules.Vouchers.PercentOff
{
    public interface IBasketVoucher
    {
        int Value { get; set; }
        object VoucherCode { get; set; }
        object VoucherDescription { get; set; }
        object VoucherId { get; set; }
    }
}