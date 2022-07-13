using Microsoft.AspNetCore.Http;

namespace ApiConventions.CommunityToolKit.Models
{
    public class Status500Response
    {
        /// <summary>
        /// 状态结果
        /// </summary>
        public int Status => StatusCodes.Status500InternalServerError;

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
