// //RLCContest->Controls->CircuitGraphItem.cs
// //andreygolubkow Андрей Голубков

using System.Collections.Generic;
using System.Drawing;

namespace Controls.CircuitDrawer
{
    public class CircuitGraphItem
    {
        public CircuitGraphItem()
        {
            In = new List<CircuitGraphItem>();
            Out = new List<CircuitGraphItem>();
        }

        public Image Image { get; set; }

        public List<CircuitGraphItem> In { get; set; }

        public List<CircuitGraphItem> Out { get; set; }


    }
}
