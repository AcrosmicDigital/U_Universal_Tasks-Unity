using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U.Universal.Tasks
{
    public class GameObjectDestroyedBeforeUroutineEndException : Exception
    {

        const string error = " The GameObject that host the Uroutine has been destroyed before hosted corroutine ends";

        public GameObjectDestroyedBeforeUroutineEndException() : base(error) { }

        public GameObjectDestroyedBeforeUroutineEndException(string message) : base(message + error) { }

        public GameObjectDestroyedBeforeUroutineEndException(string message, Exception inner) : base(message + error, inner) { }

    }
}
