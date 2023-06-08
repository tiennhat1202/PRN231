using Microsoft.Build.Framework;

namespace eStoreClient.DTO.OrderDTO
{
    public class FormFilterReportOrder
    {
        [Required]
        public DateTime? DateFrom { get; set;}
        [Required]
        public DateTime? DateTo { get; set;}
        [Required]
        public string Sort { get; set;}
    }
}
