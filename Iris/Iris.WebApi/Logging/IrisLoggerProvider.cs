using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iris.WebApi.Logging
{
    public class IrisLoggerProvider : ILoggerProvider
    {
        public IWebHostEnvironment _hostingEnvironment;
        public IrisLoggerProvider(IWebHostEnvironment hostingEnvironment) => _hostingEnvironment = hostingEnvironment;
        public ILogger CreateLogger(string categoryName) => new IrisLogger(_hostingEnvironment);
        public void Dispose() => throw new NotImplementedException();
    }
}
