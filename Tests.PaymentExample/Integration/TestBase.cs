using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PaymentExample.Integration
{
    public abstract class TestBase
    {

        protected readonly string JudoId = ConfigurationManager.AppSettings["JudoId"];
        protected readonly string ApiToken = ConfigurationManager.AppSettings["ApiToken"];
        protected readonly string ApiSecret = ConfigurationManager.AppSettings["ApiSecret"];
        protected readonly string ApiVersion = ConfigurationManager.AppSettings["ApiVersion"];
        protected readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        protected readonly string Currency = ConfigurationManager.AppSettings["Currency"];


    }
}
