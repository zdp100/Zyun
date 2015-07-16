using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSharp.Core;
using OSharp.Core.Caching;
using OSharp.Core.Configs;
using OSharp.Core.Context;
using OSharp.Core.Data.Entity;
using OSharp.Core.Security;
using OSharp.SiteBase.Logging;
using OSharp.SiteBase.Security;
using OSharp.Utility.Extensions;
using OSharp.Utility.Logging;
using OSharp.Web.Mvc;


namespace OSharp.Demo.Web.Controllers
{
    [OperateLogFilter]
    [Description("网站-测试")]
    public class TestsController : BaseController
    {
        [Description("测试-首页")]
        public ActionResult Index()
        {
            Stopwatch watch = Stopwatch.StartNew();
            ICache cache = CacheManager.GetCacher<Function>();
            Function[] functions = cache.Get<Function[]>(Constants.FunctionAllCacheKey);
            watch.Stop();
            return Content(watch.Elapsed.TotalMilliseconds + "<br/>" + functions.ToJsonString());

            return new EmptyResult();
        }

        [Description("测试-测试01")]
        public ActionResult Test01()
        {
            Dictionary<string,string>dict = new Dictionary<string, string>()
            {
                {"abc","fs"},
                {"授命","rwef"}
            };
            return Content(dict.ToJsonString());
        }
    }
}