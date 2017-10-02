namespace VirtualStockTrading
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Portfolio")]
    public partial class Portfolio
    {
        public int PortfolioId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string StockName { get; set; }

        public int ShareQuantity { get; set; }

        public double TotalProfit { get; set; }

        public double BidPrice { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
