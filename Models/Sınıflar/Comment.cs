using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace TravelTripProject.Models.Sınıflar
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Commentt { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}