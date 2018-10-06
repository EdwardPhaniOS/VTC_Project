using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LaborLawHandBook
{
    public class QuestionAndAnswer
    {
        public int thu_tu { get; set; }
        public string cau_hoi { get; set; }
        public string dap_an { get; set; }
        public bool yeu_thich { get; set; }

        internal void WriteTo(JsonTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
