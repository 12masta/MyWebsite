using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models
{
    public class ApplicationInsights
    {
        public string InstrumentationKey { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class DataSource
    {
        public string Webio { get; set; }
    }

    public class EmailProvider
    {
        public string login { get; set; }
        public string password { get; set; }
    }

    public class RootObject
    {
        public ApplicationInsights ApplicationInsights { get; set; }
        public Logging Logging { get; set; }
        public DataSource DataSource { get; set; }
        public EmailProvider EmailProvider { get; set; }
    }
}
