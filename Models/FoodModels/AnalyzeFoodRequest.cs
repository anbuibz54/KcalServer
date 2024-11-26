using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FoodModels
{
    public class AnalyzeFoodRequest
    {
        public string Image {  get; set; }
        public string MimeType { get; set; }
    }
}
