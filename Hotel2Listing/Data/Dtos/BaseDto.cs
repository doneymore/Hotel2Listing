using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Dtos
{
    public abstract class BaseDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
