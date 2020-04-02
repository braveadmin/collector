using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collector.Models
{
    public class WordModel
    {
        public WordModel()
        {
            this.word = "";
            this.status = false;
        }

        public string word { get; set; }
        public bool status { get; set; }
    }
}
