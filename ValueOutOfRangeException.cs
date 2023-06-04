using System.Runtime.Serialization;

[Serializable]
internal class ValueOutOfRangeException : Exception
{
    public ValueOutOfRangeException(string message)
         : base(message)
    {

    }

    public override string Message
    {
        get
        {
            return "ValueOutOfRangeException: " + base.Message;
        }
    }
}