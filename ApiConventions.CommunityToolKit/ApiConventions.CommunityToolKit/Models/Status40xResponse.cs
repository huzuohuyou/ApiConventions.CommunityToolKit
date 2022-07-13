using Microsoft.AspNetCore.Http;

namespace ApiConventions.CommunityToolKit.Models
{
    public class Status40xResponse
    {
        /// <summary>
        /// 状态结果
        /// </summary>
        public int StatusCode { get; set; } = StatusCodes.Status200OK;

        private string? _msg;

        /// <summary>
        /// 消息描述
        /// </summary>
        public string? Message
        {
            get => _msg;
            set => _msg = value;
        }
    }
}
