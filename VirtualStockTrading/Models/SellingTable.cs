namespace VirtualStockTrading
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SellingTable")]
    public partial class SellingTable
    {
        [Key]
        public int AskId { get; set; }

        public double AskPrice { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string StockName { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public virtual StockData StockData { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
