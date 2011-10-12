using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InoSoft.TeamStudio.Core.Entities;

namespace InoSoft.TeamStudio.Core.Services
{
    public class VersionService
    {
        public List<InoSoft.TeamStudio.Core.Entities.Version> GetAllVersion()
        {
            using (var manager = new DataManager())
            {
                return manager.Context.Versions.ToList();
            }
        }


        public InoSoft.TeamStudio.Core.Entities.Version GetVersion(int VersionId)
        {
            using (var Manager = new DataManager())
            {
                return Manager.Context.Versions.SingleOrDefault(v => v.VersionId == VersionId);
            }
        }


        public InoSoft.TeamStudio.Core.Entities.Version GetVersion(string VersionNum)
        {
            using (var Manager = new DataManager())
            {
                return Manager.Context.Versions.SingleOrDefault(v => v.VersionNum == VersionNum);
            }
        }

    }
}
