using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoTest.Domain
{
    internal class Status
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
