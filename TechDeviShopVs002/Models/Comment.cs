namespace TechDeviShopVs002.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int CommentID { get; set; }

        public int UserID { get; set; }

        public int ProductID { get; set; }

        [StringLength(500)]
        public string CommentContent { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
