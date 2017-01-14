using eCommerce.Contracts.Repositories;
using eCommerce.Model;
using eCommerce.Services;
using System.Web.Mvc;

namespace eCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<Voucher> vouchers;
        IRepositoryBase<VoucherType> voucherTypes;
        IRepositoryBase<BasketVoucher> basketVouchers;

        BasketService basketService;
       

        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Basket> baskets)
        {
            this.customers = customers;
            this.products = products;
            this.baskets = baskets;
            this.vouchers = vouchers;
            this.basketVouchers = basketVouchers;
            this.voucherTypes = voucherTypes;

            basketService = new BasketService(this.baskets, this.vouchers, this.basketVouchers, this.voucherTypes);
        }
        
        public ActionResult BasketSummary()
        {
            var model = basketService.GetBasket(this.HttpContext);

            return View(model.BasketItems);
        }

        public ActionResult AddToBasket(int id)
        {
            basketService.AddToBasket(this.HttpContext, id, 1);
            return RedirectToAction("BasketSummary");
        }

        

        public ActionResult Index()
        {
            var productList = products.GetAll();
            return View(productList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            var product = products.GetById(id); 
            return View(product);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}