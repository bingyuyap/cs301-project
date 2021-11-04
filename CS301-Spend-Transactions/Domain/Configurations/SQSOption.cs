namespace CS301_Spend_Transactions.Domain.Configurations
{
    public class SQSOption
    {
        public SQSOption() {}
        public SQSOption(string queueUrl, string region)
        {
            QueueURL = queueUrl;
            Region = region;
        }

        public string QueueURL { get; set; }

        public string Region { get; set; }

    }
}