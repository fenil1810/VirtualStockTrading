namespace VirtualStockTrading
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminLogin")]
    public partial class AdminLogin
    {
        [Key]
        public string UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(64)]
        public string Password { get; set; }
    }
}
