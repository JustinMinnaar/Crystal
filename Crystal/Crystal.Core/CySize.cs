using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crystal.Core
{
    [Serializable]
    public class CySize : IMatches<CySize>
    {
        public CySize() { }

        public CySize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        [XmlAttribute]
        public int Width { get; set; }
        [XmlAttribute]
        public int Height { get; set; }

        public bool Matches(CySize other)
        {
            if (Width != other.Width) return false;
            if (Height != other.Height) return false;
            return true;
        }
    }
}
