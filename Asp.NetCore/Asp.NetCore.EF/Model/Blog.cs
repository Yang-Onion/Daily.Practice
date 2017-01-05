using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.EF.Model
{
    public class Blog
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User BlogAuthor { get; set; }

    }
}
