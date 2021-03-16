namespace AxonCFS.Application.Results
{
    public class ServiceResult
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }

        public ServiceResult()
        {
            Succeed = true;
        }

        public ServiceResult(string message)
        {
            Message = message;
            Succeed = false;
        }
    }

    public class ServiceResult<T> : ServiceResult
        where T : class
    {
        public ServiceResult()
            : base()
        {
        }

        public ServiceResult(string message)
            : base(message)
        {
        }

        public ServiceResult(T content)
            : base()
        {
            Content = content;
        }

        public T Content { get; set; }
    }
}