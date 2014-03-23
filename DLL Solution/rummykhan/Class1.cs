using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace rummykhan
{
    [Serializable]
    public class DrawingClient
    {
        List<Point> _points;
        public List<Point> Points
        {
            get { return _points; }
            set { _points = value; }
        }
    }
}
