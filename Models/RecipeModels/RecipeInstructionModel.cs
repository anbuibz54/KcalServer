using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Models.RecipeModels
{
    public class RecipeInstructionModel
    {
        public RecipeInstructionModel() { }
        public RecipeInstructionModel(string? json) 
        {
            if (json == null)
            {
                this.Contents = new List<InstructionContent>();
            }
            else
            {
                var res = JsonConvert.DeserializeObject<List<InstructionContent>>(json);
                this.Contents = res;
            }
        }
        public List<InstructionContent> Contents { get; set; }
    }
    public class InstructionContent
    {
        public string Value { get; set; }
    }
}
