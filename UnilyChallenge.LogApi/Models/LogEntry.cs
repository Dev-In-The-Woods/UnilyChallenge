using System;
using System.ComponentModel.DataAnnotations;

namespace UnilyChallenge.LogApi.Models
{
    public class LogEntry
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255, ErrorMessage = "Message cannot exceed 255 characters")]
        public string Message { get; set; }
    }
}
