namespace SimulaCircuit.Gates
{
    public class True : IOutput
    {
        public bool this[int i]
        {
            get { return true; }
        }

        public ulong Id { get; private set; }

        public True()
        {
            Id = IdManager.Next(this);
        }
    }

    public class False : IOutput
    {
        public bool this[int i]
        {
            get { return false; }
        }

        public ulong Id { get; private set; }

        public False()
        {
            Id = IdManager.Next(this);
        }
    }
}
