namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        [Key]
        public int CommentID { get; set; }

        public int? UserID { get; set; }

        public int? ProductID { get; set; }

        [Column(TypeName = "ntext")]
        public string CommentContent { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual User User { get; set; }
    }
}
