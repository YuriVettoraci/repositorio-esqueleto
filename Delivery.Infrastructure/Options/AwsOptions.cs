using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Options
{
    public class AwsOptions
    {
        public const string AWS = "AWS";
        public string AccessKey { get; set; } = String.Empty;
        public string SecretKey { get; set; } = String.Empty;
        public string Profile { get; set; } = String.Empty;
        public string Region { get; set; } = String.Empty;
        public string Bucket { get; set; } = String.Empty;
    }
}
