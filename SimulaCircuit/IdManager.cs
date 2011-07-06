using System.Collections.Generic;
using SimulaCircuit.Gates;

namespace SimulaCircuit
{
    public static class IdManager
    {
        private static int id = 2;
        public static List<IInputsOutput> Items = new List<IInputsOutput> { new False(), new True() };

        public static int Next(IInputsOutput obj)
        {
            Items.Add(obj);
            return id++;
        }
    }
}
