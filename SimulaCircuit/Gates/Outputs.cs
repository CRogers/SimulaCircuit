namespace SimulaCircuit.Gates
{
    public class True : AutoId, IOutput
    {
        public bool this[int i]
        {
            get { return true; }
        }
    }

    public class False : AutoId, IOutput
    {
        public bool this[int i]
        {
            get { return false; }
        }
    }
}
