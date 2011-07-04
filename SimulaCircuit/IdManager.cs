using System.Collections.Generic;

namespace SimulaCircuit
{
    public static class IdManager
    {
        // Start at 1 so 0 can be the null pointer - ie unattached wire
        private static ulong id = 1;
        public static Dictionary<ulong, IInputsOutput> Items = new Dictionary<ulong, IInputsOutput>();

        public static ulong Next(IInputsOutput obj)
        {
            ulong itemId = id++;
            Items.Add(itemId, obj);
            return itemId;
        }
    }
}
