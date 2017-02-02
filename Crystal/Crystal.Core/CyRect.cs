using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crystal.Core
{
    [Serializable]
    public class CyRect : IMatches<CyRect>
    {
        public CyRect(){}

        public CyRect(int left, int top, int width, int height)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
        }

        [XmlAttribute]
        public int Left { get; set; }

        [XmlAttribute]
        public int Top { get; set; }

        [XmlAttribute]
        public int Width { get; set; }

        [XmlAttribute]
        public int Height { get; set; }

        public bool Matches(CyRect other)
        {
            if (Left != other.Left) return false;
            if (Top != other.Top) return false;
            if (Width != other.Width) return false;
            if (Height != other.Height) return false;
            return true;
        }
    }
}
