using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace VirtualStockTrading.Twilio
{
    public class Config
    {
        public static string AccountSid => WebConfigurationManager.AppSettings["AccountSid"] ??
                                           "AC3d8e47a47da06be00fd95c6576d87cc9";

        public static string AuthToken => WebConfigurationManager.AppSettings["AuthToken"] ??
                                          "3e01e7838314396b3f302cee18a7763a";

        public static string TwilioNumber => WebConfigurationManager.AppSettings["TwilioNumber"] ??
                                             "+19564460255 ";
    }
}