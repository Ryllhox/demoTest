using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoTest.Domain
{
    internal class Request
    {
        public int Id { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateEnd { get; set; }
        public required Product Product { get; set; }
        public required string Problem { get; set; }
        public required User User { get; set; }
        public required Status Status { get; set; }
        public User? Master { get; set; }
        public string? MasterDescription { get; set; }
        public Priority? Priority { get; set; }
    }
}
