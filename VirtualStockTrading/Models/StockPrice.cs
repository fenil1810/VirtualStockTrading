namespace VirtualStockTrading
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockPrice")]
    public partial class StockPrice
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string StockName { get; set; }

        public double OpeningPrice { get; set; }

        public double ClosingPrice { get; set; }

        public double HighestPrice { get; set; }

        public double LowestPrice { get; set; }

        public virtual StockData StockData { get; set; }
    }
}
