using System.Runtime.Serialization;

namespace HM.Core.Extensions;
/// <summary>
/// The exception that is thrown when the object is empty.
/// </summary>
[Serializable]
public class EmptyExceptions : Exception
{
    public EmptyExceptions() { }
    public EmptyExceptions(string message)
        : base(message) { }
    public EmptyExceptions(string message, Exception inner)
        : base(message, inner) { }
    protected EmptyExceptions(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}