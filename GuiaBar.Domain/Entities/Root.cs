using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GuiaBar.Domain.Entities
{

    public class Root    
    {
        public List<string> destination_addresses { get; set; } 
        public List<string> origin_addresses { get; set; } 
        public List<Row> rows { get; set; } 
    }
    
}