using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.ConcreteClasses
{
    public class LoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Request:");
            Console.WriteLine(request);

            if (request.Content != null)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }

            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("Response:");
            Console.WriteLine(response);

            if (response.Content != null)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            return response;
        }
    }

}
