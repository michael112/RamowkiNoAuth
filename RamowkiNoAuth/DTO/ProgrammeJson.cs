using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RamowkiAPIMockedNoSQL.DTO
{
    public class ProgrammeJson
    {
        [JsonProperty(Required = Required.Always)]
        public string Title { get; set; }
        public String Description { get; set; }

        public ProgrammeJson() { }
        public ProgrammeJson(string title)
        {
            this.Title = title;
        }
        public ProgrammeJson(string title, string description) : this(title)
        {
            this.Description = description;
        }
    }
}
