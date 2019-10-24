using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PixivApi.Exceptions
{
    public class PixivApiException : Exception
    {
        public PixivApiException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }

        public HttpStatusCode? HttpStatusCode { get; set; }
    }
}
