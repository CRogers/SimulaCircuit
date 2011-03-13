namespace SimulaCircuit.Gates
{
    public class True : IOutput
    {
        public bool Output
        {
            get { return true; }
        }
    }

    public class False : IOutput
    {
        public bool Output
        {
            get { return false; }
        }
    }
}
