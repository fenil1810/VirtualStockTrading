namespace VirtualStockTrading
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderTable")]
    public partial class OrderTable
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string StockName { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionType { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public double TransactionFee { get; set; }

        public virtual StockData StockData { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
