using System;

namespace PortfolioWeb.Models
{
    //������ ������ ó���ϴ� ��
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
