using System;
using System.Collections.Generic;

namespace CS_EFCoreAppStructure.Models
{
    public partial class PersonInfo
    {
        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; } = null!;
        public int NameStyle { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int EmailPromotion { get; set; }
    }
}
