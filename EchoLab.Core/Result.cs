using System;
using System.Collections.Generic;
using System.Text;

namespace EchoLab.Core
{
    /// <summary>
    /// 返回结果
    /// </summary>
    /// <typeparam name="T">返回的数据类型</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// 返回状态码（值域：200、400、401、403、404、500、999-其他）
        /// <para>
        /// 关于状态码的定义，参考：https://www.zhihu.com/question/58686782/answer/159603453
        /// </para>
        /// </summary>
        public int Code { get; set; } = 200;

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
