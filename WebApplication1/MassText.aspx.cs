using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace WebApplication1
{
    public partial class MassText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Find your Account Sid and Auth Token at twilio.com/console
            const string accountSid = "ACfea5d37bf26506dc28eec82b31753b4b";
            const string authToken = "064e3b6440e1172673fdc210a3f3b1cd";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+3179975301");
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("(317)-961-7486"),
                body: "This is the ship that made the Kessel Run in fourteen parsecs?");

            Console.WriteLine(message.Sid);
        }
    }
}


/*
 curl 'https://api.twilio.com/2010-04-01/Accounts/ACfea5d37bf26506dc28eec82b31753b4b/Messages.json' -X POST \
--data-urlencode 'To=+13179975301' \
--data-urlencode 'From=+13179617486' \
--data-urlencode 'Body=this some ole bullshit' \
-u ACfea5d37bf26506dc28eec82b31753b4b:064e3b6440e1172673fdc210a3f3b1cd

    */
