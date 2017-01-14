using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model
{
    public class VoucherType : IVoucherType
    {
        public int VoucherTypeId { get; set; }
        public string VoucherModule { get; set; }
        [MaxLength(30)]
        public string Type { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
    }
}
