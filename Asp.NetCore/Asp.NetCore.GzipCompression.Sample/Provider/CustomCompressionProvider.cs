using Microsoft.AspNetCore.ResponseCompression;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.GzipCompression.Sample.Provider
{
    public class CustomCompressionProvider : ICompressionProvider
    {
        public string EncodingName => "customcompression";

        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream)
        {
            return outputStream;
        }
    }
}
