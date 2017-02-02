using System;
using Crystal.Core;
using Crystal.Ocr.Data;

namespace Crystal.Profiler.Data
{
    public class CyProfileExtractor : IMatches<CyProfileExtractor>
    {
        public string DestinationField { get; set; }
        public CyRect RectanglePixels { get; set; }

        public bool Matches(CyProfileExtractor other)
        {
            if (DestinationField != other.DestinationField) return false;
            if (RectanglePixels.Matches(other.RectanglePixels)) return false;

            return true;
        }
    }
}