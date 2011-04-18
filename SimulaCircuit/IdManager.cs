using System.Collections.Generic;

namespace SimulaCircuit
{
    public static class IdManager
    {
        private static ulong id = 0;
        public static Dictionary<ulong, IOutput> Items = new Dictionary<ulong, IOutput>();

        public static ulong Next(IOutput obj)
        {
            ulong itemId = id++;
            Items.Add(itemId, obj);
            return id++;
        }
    }
}
