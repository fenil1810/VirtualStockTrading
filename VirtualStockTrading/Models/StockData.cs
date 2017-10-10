namespace VirtualStockTrading
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockData")]
    public partial class StockData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockData()
        {
            BuyingTables = new HashSet<BuyingTable>();
            OrderTables = new HashSet<OrderTable>();
            SellingTables = new HashSet<SellingTable>();
            StockPrices = new HashSet<StockPrice>();
        }

        [Key]
        [StringLength(50)]
        public string StockName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MarketPrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TotalVolume { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuyingTable> BuyingTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SellingTable> SellingTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockPrice> StockPrices { get; set; }
    }
}
