using System.Runtime.Serialization;

namespace Spg.HelloWorld.Demo.Model
{
    [Serializable]
    internal class CouldNotSaveException : Exception
    {
        public CouldNotSaveException()
        {
        }

        public CouldNotSaveException(string? message) : base(message)
        {
        }

        public CouldNotSaveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CouldNotSaveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}