using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Kairos.WEB.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Range(1,100000)]
        public int Duration { get; set; }

        public DateTime StartDate { get; set; }
        
        //TODO: Validation - Enddate should be >= start date or end date should be blank
        public DateTime EndDate { get; set; }
    }
}