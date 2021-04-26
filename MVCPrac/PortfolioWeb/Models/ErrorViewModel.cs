using System;

namespace PortfolioWeb.Models
{
    //에러가 났을때 처리하는 모델
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
