// //RLCContest->Controls->CircuitAdapter.cs
// //andreygolubkow Андрей Голубков

using System.Drawing;

using Core;
using Core.Circuits;
using Core.Elements;
using Controls.AdvancedCircuitDrawer;

namespace Controls.CircuitDrawer
{
    public static class CircuitAdapter
    {

        public static (GraphElement In, GraphElement Out) CircuitToGraph(ICircuit circuit)
        {
            // контакт А
            var aItem = new GraphElement()
            {
                Image = CircuitImages.Connector,
            };
            //Контакт Б
            var bItem = new GraphElement()
            {
                Image = CircuitImages.Connector,
            };
            GraphElement item = aItem;
            if ( circuit is SerialCircuit )
            {
                foreach (var circuitItem in circuit)
                {
                    if ( circuitItem is IElement elementItem )
                    {
                        var element = ElementToGraphItem(elementItem);

                        item.Out.Add(element);
                        element.In.Add(item);
                        item = element;
                    }
                    else
                    {
                        (GraphElement subCircuitIn, GraphElement subCircuitOut) = CircuitToGraph(circuitItem as ICircuit);
                        item.Out.Add(subCircuitIn);
                        subCircuitIn.In.Add(item);
                        item = subCircuitOut;
                    }
                }
                bItem.In.Add(item);
                item.Out.Add(bItem);
                return (aItem, bItem);
            }
            if ( circuit is ParallelCircuit )
            {
                foreach (var circuitItem in circuit)
                {
                    if ( circuitItem is IElement elementItem )
                    {
                        var element = ElementToGraphItem(elementItem);

                        aItem.Out.Add(element);
                        element.In.Add(aItem);

                        bItem.In.Add(element);
                        element.Out.Add(bItem);
                    }
                    else
                    {
                        (GraphElement subCircuitIn, GraphElement subCircuitOut) = CircuitToGraph(circuitItem as ICircuit);
                        aItem.Out.Add(subCircuitIn);
                        subCircuitIn.In.Add(aItem);
                        bItem.In.Add(subCircuitOut);
                        subCircuitIn.Out.Add(bItem);
                    }
                }
                return (aItem, bItem);
            }
            return (aItem, bItem);
        }

        private static GraphElement ElementToGraphItem(IElement element)
        {
            Image image = CircuitImages.WhiteBlock;
            if (element is Resistor )
            {
                image = CircuitImages.SerialResistor;
            }
            else if (element is Capacitor)
            {
                image = CircuitImages.SerialCapasitor;
            }
            else if (element is Inductor)
            {
                image = CircuitImages.SerialInductor;
            }
            else
            {
                image = CircuitImages.Connector;
            }

            return new GraphElement()
                   {
                       Image = image
                   };
        }

    }
}
