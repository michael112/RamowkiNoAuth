using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using RamowkiAPIMockedNoSQL.Services.ProgrammeService;
using RamowkiAPIMockedNoSQL.Models;
using RamowkiAPIMockedNoSQL.DTO;


namespace RamowkiAPIMockedNoSQL.Controllers
{
    [Route("api/[controller]")]
    public class ProgrammeController : Controller
    {

        private readonly IProgrammeService programmeService;

        public ProgrammeController(IProgrammeService programmeService)
        {
            this.programmeService = programmeService;
        }

        // GET api/programme
        [HttpGet]
        public IEnumerable<Programme> ReadProgrammeList()
        {
            return this.programmeService.ReadProgrammeList();
        }

        // GET api/programme/{programmeID}
        [HttpGet("{programmeID}")]
        public Programme ReadProgramme(string programmeID)
        {
            return this.programmeService.ReadProgramme(programmeID);
        }

        // POST api/programme
        [HttpPost]
        public void CreateProgramme([FromBody]ProgrammeJson newProgramme)
        {
            this.programmeService.CreateProgramme(newProgramme);
        }

        // PUT api/programme/{programmeID}
        [HttpPut("{programmeID}")]
        public void UpdateProgramme(string programmeID, [FromBody]ProgrammeJson programme)
        {
            this.programmeService.UpdateProgramme(programmeID, programme);
        }

        // DELETE api/programmeID/{programmeID}
        [HttpDelete("{programmeID}")]
        public void DeleteProgramme(string programmeID)
        {
            this.programmeService.DeleteProgramme(programmeID);
        }
    }
}
