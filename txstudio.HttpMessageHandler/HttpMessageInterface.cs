using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txstudio.HttpMessageHandler
{
    /// <summary>
    /// 定義儲存 WebApi Http 請求與回應內容的資料操作容器
    /// </summary>
    public interface IHttpMessageLogRepository
    {
        /// <summary>
        /// 儲存 WebApi 請求與回應訊息
        /// </summary>
        /// <param name="message">要儲存的訊息物件</param>
        void SaveChange(txstudio.HttpMessageHandler.Data.HttpMessageHandler message);
    }
}
