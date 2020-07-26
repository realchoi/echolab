using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Core
{
    /// <summary>
    /// 返回结果
    /// </summary>
    /// <typeparam name="T">返回的数据类型</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// 返回状态码（值域：0-正常；-1-异常；...；9999-其他）
        /// </summary>
        public int Code { get; set; } = 0;

        /// <summary>
        /// 返回消息，可自定义
        /// </summary>
        public string Message { get; set; } = "Ok";

        /// <summary>
        /// 返回的数据
        /// </summary>
        public T Data { get; set; }
    }
}
