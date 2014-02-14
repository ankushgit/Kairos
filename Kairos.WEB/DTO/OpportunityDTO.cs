using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kairos.WEB.DTO
{
    public class OpportunityDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(200)]        
        public string Client { get; set; }

        [Required]
        [MaxLength(100)]        
        public string PrimaryContact { get; set; }

        [Required]
        [MaxLength(20)]        
        public string Telno { get; set; }
    }
}