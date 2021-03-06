﻿using System.Collections.Generic;

namespace SimulaCircuit
{
    public static class IdManager
    {
        private static ulong id = 0;
        public static Dictionary<ulong, IInputsOutput> Items = new Dictionary<ulong, IInputsOutput>();

        public static ulong Next(IInputsOutput obj)
        {
            ulong itemId = id++;
            Items.Add(itemId, obj);
            return id++;
        }
    }
}
