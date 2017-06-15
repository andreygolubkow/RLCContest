// //RLCContest->Controls->ElementWithConnectionAdapter.cs
// //andreygolubkow Андрей Голубков

using Core;

namespace Controls
{
    public class ElementWithConnectionAdapter
    {

        public ElementWithConnectionAdapter(IElement element, ConnectionType connectionType)
        {
            Element = element;
            ConnectionType = connectionType;
        }

        public IElement Element { get; set; }

        public ConnectionType ConnectionType { get; set; }
    }
}
