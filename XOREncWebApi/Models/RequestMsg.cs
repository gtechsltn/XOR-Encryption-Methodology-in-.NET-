namespace XOREncWebApi.Models
{
    public class RequestMsg
    {
        public string secretKey { get; set; }
        public string data { get; set; }
    }

    public class RequestValidate
    {
        public string enc_token { get; set; }
        public string secretKey { get; set; }
        public string data { get; set; }
    }

}
