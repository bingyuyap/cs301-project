using Amazon;
using System;
using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Amazon.SQS;
using CS301_Spend_Transactions.Domain.Configurations;
using CS301_Spend_Transactions.Repo.Helpers.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class SESHelper : ISESHelper 
    {
        // Replace sender@example.com with your "From" address.
        // This address must be verified with Amazon SES.
        static readonly string senderAddress = "bingyu.yap.21@gmail.com";

        // Replace recipient@example.com with a "To" address. If your account
        // is still in the sandbox, this address must be verified.
        static readonly string receiverAddress = "bingyu.yap.2020@scis.smu.edu.sg";

        // The configuration set to use for this email. If you do not want to use a
        // configuration set, comment out the following property and the
        // ConfigurationSetName = configSet argument below. 
        static readonly string configSet = "ConfigSet";

        // The subject line for the email.
        static readonly string subject = "Amazon SES test (AWS SDK for .NET)";

        // The email body for recipients with non-HTML email clients.
        static readonly string textBody = "Amazon SES Test (.NET)\r\n"
                                          + "This email was sent through Amazon SES "
                                          + "using the AWS SDK for .NET.";

        // The HTML body of the email.
        string htmlBody = @"<html>
        <head></head>
        <body>
          <h1>Amazon SES Test (AWS SDK for .NET)</h1>
          <p>This email was sent with
            <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
            <a href='https://aws.amazon.com/sdk-for-net/'>
              AWS SDK for .NET</a>.</p>
        </body>
        </html>";
        
        private readonly SESOption _option;
        private AmazonSimpleEmailServiceClient _amazonSimpleEmailServiceClient;
        private ILogger<SQSHelper> _logger;

        public SESHelper(IOptions<SESOption> option, ILogger<SQSHelper> logger)
        {
            _option = option.Value;
            _amazonSimpleEmailServiceClient = new AmazonSimpleEmailServiceClient(
                _option.AccessKey,
                _option.SecretKey,
                RegionEndpoint.APSoutheast1
            );
            _logger = logger;
        }

        public async void SendFailedTransactionEmail(string transactionId)
        {
            using (var client = _amazonSimpleEmailServiceClient)
            {
                var sendRequest = new SendEmailRequest
                {
                    Source = senderAddress,
                    Destination = new Destination
                    {
                        ToAddresses =
                            new List<string> { receiverAddress }
                    },
                    Message = new Message
                    {
                        Subject = new Content(subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = htmlBody
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = textBody
                            }
                        }
                    },
                    // If you are not using a configuration set, comment
                    // or remove the following line 
                    // ConfigurationSetName = configSet
                };
                try
                {
                    Console.WriteLine("Sending email using Amazon SES...");
                    await client.SendEmailAsync(sendRequest);
                    Console.WriteLine("The email was sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);

                }
            }

        }
    }
}