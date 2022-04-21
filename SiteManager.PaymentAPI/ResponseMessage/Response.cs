namespace SiteManager.PaymentAPI.ResponseMessage
{
    public class Response<T>
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
