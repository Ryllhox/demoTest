using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoTest.Domain
{
    internal class User
    {
        public int Id { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
        public int Phone { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required Role Role { get; set; }
    }
}
