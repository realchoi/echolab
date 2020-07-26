using EchoBlog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domains.UserAggregate
{
    /// <summary>
    /// 使用用户名口令进行登录的表
    /// </summary>
    public class LocalAuthUser : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 用户 ID，关联 user 表的主键
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// 用户登录口令
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 建立一个 User 对象
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="email">电子邮件地址</param>
        /// <param name="github">GitHub 地址</param>
        /// <param name="website">个人网站地址</param>
        public LocalAuthUser(long userId, string userName, string password)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Password = password;
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(long userId, string newPassword)
        {
            // 修改密码后创建领域事件
            //this.AddDomainEvent(new UserPasswordChangedDomainEvent(this));
            return true;
        }
    }
}
