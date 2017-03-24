using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models.Blog
{
    public class Tag
    {
        public int ID { get; set; }
        public int PostId { get; set; }
        public Tags TagCategory { get; set; }

        public virtual Post Post { get; set; }
     }

    public enum Tags
    {
        DSP2017,
        QA,
        CSHARP
    }
}
