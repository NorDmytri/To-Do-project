using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Todo01._01vercion.Models
{
    public class UserTask
    {
        [Key]
        [Required]
        
        public int UserTaskId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "TaskDate", ResourceType =typeof(Resources.Resource))]
        public DateTime TaskDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "TaskTime", ResourceType = typeof(Resources.Resource))]
        public DateTime TaskTime { get; set; }

        [Required]
        [Display(Name = "TaskTitle", ResourceType = typeof(Resources.Resource))]
        [MaxLength(100,  ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "TaskTitleErr")]
        public string TaskTitle { get; set; }

        [Display(Name = "UseMap", ResourceType = typeof(Resources.Resource))]
        public bool UseMap { get; set; }

        [Display(Name = "MapPoin", ResourceType = typeof(Resources.Resource))]
        public PointModel MapPoin { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Taskdescription", ResourceType = typeof(Resources.Resource))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "TaskdescriptionErr")]
        public string Taskdescription { get; set; }

        [Required]
        [Display(Name = "Status", ResourceType = typeof(Resources.Resource))]
        public string Status { get; set; }

        public string UserId { get; set; }
    }
    public class PointModel
    {
        [Display(Name = "MapLat", ResourceType = typeof(Resources.Resource))]
        public string MapLat { get; set; }

        [Display(Name = "Maplng", ResourceType = typeof(Resources.Resource))]
        public string Maplng { get; set; }

        [Display(Name = "MapTitle", ResourceType = typeof(Resources.Resource))]
        public string MapTitle { get; set; }

    }

}