using System;
using System.Collections.Generic;

namespace Crystal.Data
{
    public class CrystalStuff
    {
        public CrystalStuff()
        {
            for (int i = 0; i < 1000; i++)
            {
                Types.Add("TYPE #" + i);
            }

        }

        public List<string> Types = new List<string>();
    }
}
