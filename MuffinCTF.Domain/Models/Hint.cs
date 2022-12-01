using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuffinCTF.Domain.Models
{
    public class Hint
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public Challenge Challenge { get; set; }
    }
}
