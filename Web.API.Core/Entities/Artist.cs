using System;
using System.Collections.Generic;
using System.Text;
using Web.API.Core.Interfaces;

namespace Web.API.Core.Entities
{
    public class Artist : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
