namespace SimulaCircuit
{
    public static class IdManager
    {
        private static ulong id = 0;

        public static ulong Next()
        {
            return id++;
        }
    }

    public class AutoId
    {
        private ulong id = IdManager.Next();
        public ulong Id
        {
            get { return id; }
        }
    }
}
