namespace SimulaCircuit.Gates
{
    public interface IOutput
    {
        bool Output { get; }
    }

    public abstract class Gate : IOutput
    {
        public IOutput[] Inputs { get; set; }

        protected Gate(){}

        protected Gate(params IOutput[] inputs)
        {
            Inputs = inputs;
        }

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

        protected Gate1(IOutput input)
        {
            Inputs = new[] {input};
        }
    }
}
