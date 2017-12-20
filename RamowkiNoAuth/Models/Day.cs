using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

using RamowkiAPIMockedNoSQL.Utils;

namespace RamowkiAPIMockedNoSQL.Models
{
    public abstract class Day {
        [JsonProperty(Required = Required.AllowNull)]
        public Guid Id { get; set; }
    }
}
