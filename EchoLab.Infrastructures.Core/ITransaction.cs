using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Core
{
    /// <summary>
    /// 事务接口
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// 判断事务是否开启
        /// </summary>
        bool HasActiveTransaction { get; }

        /// <summary>
        /// 获取当前事务对象
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction GetCurrentTransaction();

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        Task<IDbContextTransaction> BeginTransactionAsync();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction">待提交的事务</param>
        /// <returns></returns>
        Task CommitTransactionAsync(IDbContextTransaction transaction);

        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTransaction();
    }
}
