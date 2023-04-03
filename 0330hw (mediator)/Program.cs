using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0330hw__mediator_
{
    public interface IMediator
    {
        void ConnectToPilot(object From, string Name, string Message);
        void Add(Aircraft obj);
    }
    class MediatorDispatcher : IMediator
    {

        private List<Aircraft> Aircraft;

        public void Add(Aircraft _Aircraft)
        {
            Aircraft.Add(_Aircraft);
        }


        public void ConnectToPilot(object From, string Name, string Message)
        {
            foreach (Aircraft Receiver in Aircraft)
            {
                if (Receiver.Name == Name)
                {
                    Receiver.Receive(Message);
                }
            }
        }
    }

    public abstract class Aircraft
    {
        protected IMediator Mediator;
        public string Name {get; set;}

        public Aircraft()
        {
            this.Mediator = null;
        }

        public void SetMediator(IMediator mediator)
        {
            this.Mediator = mediator;
        }
        public void Receive(string Message)
        {
            Console.WriteLine(Message);
        }
        public void Send(string Name, string Message)
        {

            this.Mediator.ConnectToPilot(this, Name, Message);
        }
    }

    class Helicopter : Aircraft
    {
        public Helicopter()
        {
            Mediator.Add(this);
        }

    }

    class Airliner : Aircraft
    {
        public Airliner()
        {
            Mediator.Add(this);
        }
    }

    class Airplane : Aircraft
    {
        public Airplane()
        {
            Mediator.Add(this);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
