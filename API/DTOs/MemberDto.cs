using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MemberDto
    {
        public int ID { get; set; }


        public string UserName { get; set; }
        public string photoUrl { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string UserGender { get; set; }
        public string Introduction { get; set; }

        public string LookingFor { get; set; }
        public string Interests { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public List<PhotoDto> Photos { get; set; }


    }
}