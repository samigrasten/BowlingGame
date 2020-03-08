namespace BowlingGameKata
{
    public class OperationResult
    {
        private OperationResult() { }

        private OperationResult(string message)
        {
            _message = message;
        }

        public static OperationResult Success() => new OperationResult();
        public static OperationResult Failed(string message) => new OperationResult(message);

        public bool IsSuccess => string.IsNullOrEmpty(_message);

        private string _message;
    }
}