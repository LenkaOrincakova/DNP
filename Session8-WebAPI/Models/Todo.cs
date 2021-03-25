using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodosWebAPI.Models
{
    public class Todo { 
    [Required] 
    [Range(1, int.MaxValue, ErrorMessage ="Please enter a value bigger than {1}")]

       
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("id"), Key]
        public int TodoId { get; set; }

        [Required, MaxLength(128)]
        [JsonPropertyName("title")]

        public string Title { get; set; }
        [JsonPropertyName("completed")]
        public bool IsCompleted { get; set; }


    }
}
