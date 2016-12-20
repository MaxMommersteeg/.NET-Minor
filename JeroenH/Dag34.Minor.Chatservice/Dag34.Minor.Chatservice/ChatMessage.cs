using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dag34.Minor.Chatservice
{
    public class ChatMessage
    {

        public string Message { get; set; }
        [Required]
        [Key]
        public int MessageID { get; set; }
    }
}
