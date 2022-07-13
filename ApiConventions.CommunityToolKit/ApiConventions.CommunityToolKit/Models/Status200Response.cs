using Microsoft.AspNetCore.Http;

namespace ApiConventions.CommunityToolKit.Models
{
    public class Status200Response<T>
    {
        /// <summary>
        /// 状态结果
        /// </summary>
        public int Status => StatusCodes.Status200OK;

        private string? _msg;

        /// <summary>
        /// 消息描述
        /// </summary>
        public string? Message
        {
            get => _msg;
            set => _msg = value;
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Data { get; set; }
    }
}
