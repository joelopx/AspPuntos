using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PointRest.Models
{
    public class Point
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Description { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}