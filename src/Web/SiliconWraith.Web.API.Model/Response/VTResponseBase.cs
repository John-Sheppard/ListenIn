using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Web;

namespace VibeTribe.Web.API.Model.Response
{
    public class VTResponseBase
    {
        public const string XCorrelationId = "X-VibeTribe-Correlation-Id";

        public Guid CorrelationId { get; set; }
        public string ResponseMessage { get; set; }

        public static void SetCorrelationIdHeader(IResponse response)
        {

        }
       
    }
}
