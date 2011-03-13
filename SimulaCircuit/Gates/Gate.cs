namespace SimulaCircuit.Gates
{
    public interface IOutput
    {
        bool Output { get; }
    }

    public abstract class Gate : IOutput
    {
        public IOutput[] Inputs { get; set; }

        public bool Output 
        {
            get { return Func(); }
        }

        protected abstract bool Func();
    }

    public abstract class Gate1 : Gate
    {
        protected Gate1()
        {
            Inputs = new IOutput[1];
        }
    }
}
