using Crystal.Profiler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Profiler.Adapter
{
    public enum FileFormat { Xml, Json }

    public interface ICyProfileAdapter
    {
        IList<CyProfileHeader> ListProfiles();

        CyProfile LoadProfile(string name);

        void SaveProfile(CyProfile profile);
    }
}
