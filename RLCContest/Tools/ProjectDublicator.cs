using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Circuits;
using Core.Elements;

namespace Tools
{
    public static class ProjectDublicator
    {


        public static ICircuit CopyCircuit(ICircuit circuit)
        {
            if ( circuit is SerialCircuit )
            {
                var c = new SerialCircuit();
                c.Name = circuit.Name;
                foreach (var e in circuit)
                {
                    if ( e is IElement el )
                    {
                        c.Add(CopyElement(el));
                    }
                    else if ( e is ICircuit ci )
                    {
                        c.Add(CopyCircuit(ci));
                    }
                }
                return c;
            }
            if (circuit is ParallelCircuit)
            {
                var c = new ParallelCircuit();
                c.Name = circuit.Name;
                foreach (var e in circuit)
                {
                    if (e is IElement el)
                    {
                        c.Add(CopyElement(el));
                    }
                    else if (e is ICircuit ci)
                    {
                        c.Add(CopyCircuit(ci));
                    }
                }
                return c;
            }

            return null;
        }

        public static IElement CopyElement(IElement element)
        {
            if ( element is Resistor r)
            {
                return new Resistor(r.Name,r.Value);
            }
            if ( element is Capacitor c )
            {
                return new Capacitor(c.Name,c.Value);
            }
            if ( element is Inductor i )
            {
                return new Inductor(i.Name,i.Value);
            }
            return null;
        }

        public static Project CopyProject(Project project)
        {
            var proj = new Project();
            proj.Circuits = new List<IComponent>();
            proj.Frequencies = new List<double>();
            foreach (var f in project.Frequencies)
            {
                proj.Frequencies.Add(f);
            }

            foreach (var component in project.Circuits)
            {
                if (component is ICircuit c)
                proj.Circuits.Add(CopyCircuit(c));
            }
            return proj;
        }

    }
}
