namespace Aliquota.WebApp.Models
{
    public class CommandResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}