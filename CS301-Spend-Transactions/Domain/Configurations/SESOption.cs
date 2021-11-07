namespace CS301_Spend_Transactions.Domain.Configurations
{
    public class SESOption
    {
        public SESOption() {}
        public SESOption(string accessKey, string secretKey)
        {
            AccessKey = accessKey;
            SecretKey = secretKey;
        }  

        public string AccessKey { get; set; }
        
        public string SecretKey { get; set; }
    }
}