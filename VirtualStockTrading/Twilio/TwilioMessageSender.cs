using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace VirtualStockTrading.Twilio
{
    public interface ITwilioMessageSender
    {
        Task SendMessageAsync(string to, string from, string body);
    }
    public class TwilioMessageSender : ITwilioMessageSender
    {
        public TwilioMessageSender()
        {
            TwilioClient.Init(Config.AccountSid, Config.AuthToken);
        }

        public async Task SendMessageAsync(string to, string from, string body)
        {
            await MessageResource.CreateAsync(new PhoneNumber(to),
                                              from: new PhoneNumber(from),
                                              body: body);
        }
    }
}