using Crystal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crystal.Ocr.Data
{
    [Serializable]
    public class CyOcrResult
    {
        public List<CyOcrCharacter> Characters;
    }

    [Serializable]
    public class CyOcrCharacter : IMatches<CyOcrCharacter>
    {
        /// <summary>The character, or sometimes multiple possible characters.</summary>
        [XmlAttribute]
        public string Symbols;

        /// <summary>The rectangle that encloses the character.</summary>
        [XmlElement]
        public CyRect Rectangle;

        /// <summary>A group of characters that are logically part of the same field.</summary>
        [XmlAttribute]
        public int GroupIndex;

        [XmlAttribute]
        public float Confidence;

        public bool Matches(CyOcrCharacter other)
        {
            if (this.Confidence != other.Confidence) return false;
            if (this.GroupIndex != other.GroupIndex) return false;
            if (!this.Rectangle.Matches(other.Rectangle)) return false;
            if (this.Symbols != other.Symbols) return false;

            return true;
        }
    }

}
