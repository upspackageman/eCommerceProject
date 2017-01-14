namespace eCommerce.Modules.Vouchers.PercentOff
{
    public interface IBasket
    {
        int BasketTotal();
        void AddBasketVoucher(IBasketVoucher basketVoucher);
    }
}