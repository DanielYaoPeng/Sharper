using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharper.Filters
{
    public class GlobalFilter : IActionFilter, IExceptionFilter
    {
        private IDictionary<string, object> _actionArguments;

        public GlobalFilter()
        {
            
        }

        /// <summary>
        /// 退出action之前执行的操作
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }

        /// <summary>
        /// 进入action执行操作
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // 临时保存一下，如果异常的时候可以使用
            _actionArguments = context.ActionArguments;
        }

        /// <summary>
        /// 全局错误
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {

            var requestBody = string.Empty;
            if (_actionArguments != null && _actionArguments.Count > 0)
            {
                requestBody = JsonConvert.SerializeObject(_actionArguments, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            string action = context.RouteData.Values["action"] as string;

            Console.WriteLine($"请求异常{Environment.NewLine}action:{action}{Environment.NewLine}requestBody:{requestBody}");
        }
    }
}
