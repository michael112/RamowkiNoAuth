using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RamowkiAPIMockedNoSQL.DTO;
using RamowkiAPIMockedNoSQL.Models;

namespace RamowkiAPIMockedNoSQL.Services.ProgrammeService
{
    public interface IProgrammeService
    {
        IEnumerable<Programme> ReadProgrammeList();
        Programme ReadProgramme(string id);
        void CreateProgramme(ProgrammeJson programme);
        string CreateProgrammeAndReturnId(ProgrammeJson programme);
        void UpdateProgramme(string id, ProgrammeJson programme);
        void DeleteProgramme(string id);
    }
}
