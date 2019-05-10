using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBook.UI.Areas.Member.Models.VM
{
    public class JsonLikeVM
    {
        public string userMassage { get; set; }
        public int Likes { get; set; }
        public bool isSuccess { get; set; }
        public int Comments { get; set; }
    }
}