using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Park_sPortfolio.Models
{//데이터베이스를 DB에서 작업하는 것이 아니라 비쥬얼 스튜디오에서 작업
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]//not null을 의미
        public string Name { get; set; }
        public virtual ICollection<Speaker> Speakers { get; set; }

    }
    public class Speaker
    {
        [Key]
        public int SpeakerId { get; set; }
        [Required]//not null을 의미
        public string Name { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
