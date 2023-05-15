using System;
using System.Collections.Generic;

namespace CS_EFCoreDbFirst.Models
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public string Task { get; set; } = null!;
    }
}
