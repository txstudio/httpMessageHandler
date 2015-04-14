using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using txstudio.HttpMessageHandler.Data;

namespace txstudio.HttpMessageHandler
{

    /// <summary>
    /// 儲存 WebApi 請求與回應內容的處理常式
    /// </summary>
    public class HttpMessageDelegatingHandler : DelegatingHandler
    {
        private IHttpMessageLogRepository _httpMessagnLogRepository;

        private txstudio.HttpMessageHandler.Data.HttpMessageHandler _message;
        private Encoding _encoding;


        public HttpMessageDelegatingHandler(IHttpMessageLogRepository httpMessageLogRepositoryInstance)
        {
            this._httpMessagnLogRepository = httpMessageLogRepositoryInstance;

            this._message = new txstudio.HttpMessageHandler.Data.HttpMessageHandler();
            this._encoding = Encoding.GetEncoding("utf-8");
        }


        protected override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(
            System.Net.Http.HttpRequestMessage request,
            System.Threading.CancellationToken cancellationToken)
        {
            Byte[] _requestContent;
            Byte[] _responseContent;

            var _responseTask = base.SendAsync(request, cancellationToken);


            //取得請求與回應內容 Request.Content , Response.Content
            request.Content.ReadAsStreamAsync().Result.Position = 0;
            _requestContent = request.Content.ReadAsByteArrayAsync().Result;
            _responseContent = _responseTask.Result.Content.ReadAsByteArrayAsync().Result;


            //取得 WebApi 請求訊息資訊
            if (request.Properties.ContainsKey("MS_HttpContext"))
                this._message.IPAddress = ((System.Web.HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;

            this._message.Method = request.Method.Method;
            this._message.RequestUrl = request.RequestUri.ToString();

            this._message.RequestMessage = this._encoding.GetString(_requestContent);
            this._message.ResponseMessage = this._encoding.GetString(_responseContent);


            //儲存 WebApi 訊息，儲存方式由使用者擴充定義的 IHttpMessageLogRepository 介面方法
            this._httpMessagnLogRepository.SaveChange(this._message);

            return (_responseTask);
        }

    }
}
