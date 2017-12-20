using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RamowkiNoAuth.DTO;
using RamowkiNoAuth.Models;

namespace RamowkiNoAuth.Services.ProgrammeService
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
