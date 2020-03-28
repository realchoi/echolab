using EchoBlog.Infrastructures.Core.Extensions;
using EchoBlog.Infrastructures.Core.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Core.Behaviors
{
    /// <summary>
    /// 事务管理
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class TransactionBehavior<TDbContext, TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TDbContext : EFContext
    {
        TDbContext _dbContext;

        public TransactionBehavior(TDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);
            var typeName = request.GetGenericTypeName();

            try
            {
                if (_dbContext.HasActiveTransaction)
                    return await next();

                // 创建默认的执行策略
                var strategy = _dbContext.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {
                    Guid transactionId;

                    using (var transaction = await _dbContext.BeginTransactionAsync())
                    {
                        LogUtil.Info($"TransactionContext: {transaction.TransactionId}");
                        LogUtil.Info($"------ 开始事务 {transaction.TransactionId} ({typeName})");

                        response = await next();

                        LogUtil.Info($"------ 提交事务 {transaction.TransactionId} ({typeName})");
                        await _dbContext.CommitTransactionAsync(transaction);

                        transactionId = transaction.TransactionId;
                    }
                    /*using (_logger.BeginScope("TransactionContext: {TransactionId}", transaction.TransactionId))
                    {
                        _logger.LogInformation("------ 开始事务 {TransactionId} ({@Command})", transaction.TransactionId, typeName, request);
                        response = await next();

                        _logger.LogInformation("------ 提交事务 {TransactionId} {CommandName}", transaction.TransactionId, typeName);
                        await _dbContext.CommitTransactionAsync(transaction);

                        transactionId = transaction.TransactionId;
                    }*/
                });
                return response;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"处理事务出错，{typeName} ({request})");
                //_logger.LogError(ex, "处理事务出错，{CommandName} ({@Command})", typeName, request);
                throw ex;
            }
        }
    }
}
