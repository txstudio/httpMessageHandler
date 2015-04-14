using System;
using System.Runtime.Serialization;

/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
namespace txstudio.HttpMessageHandler.Data
{
    /// <summary>
    /// Http 呼叫紀錄事件
    /// </summary>
    [DataContract]
    public class HttpMessageHandler
    {
        /// <summary>
        /// 使用的 Http 方法 Get , Post , Put , Delete
        /// </summary>
        [DataMember(IsRequired = true)]
        public String Method { get; set; }

        /// <summary>
        /// 呼叫方法的 IP 位址
        /// </summary>
        [DataMember(IsRequired = true)]
        public String IPAddress { get; set; }

        /// <summary>
        /// 請求 Url 路徑
        /// </summary>
        [DataMember(IsRequired = true)]
        public String RequestUrl { get; set; }

        /// <summary>
        /// 請求的訊息內容
        /// </summary>
        [DataMember(IsRequired = true)]
        public String RequestMessage { get; set; }

        /// <summary>
        /// 回應訊息內容
        /// </summary>
        [DataMember(IsRequired = true)]
        public String ResponseMessage { get; set; }
    }
}
