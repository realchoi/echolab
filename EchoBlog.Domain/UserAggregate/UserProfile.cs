using EchoBlog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domains.UserAggregate
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class UserProfile : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 电子邮件地址
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// GitHub 地址
        /// </summary>
        public string Github { get; private set; }

        /// <summary>
        /// 个人网站地址
        /// </summary>
        public string Website { get; private set; }

        public UserProfile() { }

        /// <summary>
        /// 建立一个 User 对象
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="email">电子邮件地址</param>
        /// <param name="github">GitHub 地址</param>
        /// <param name="website">个人网站地址</param>
        public UserProfile(string name, string email, string github, string website)
        {
            this.Name = name;
            this.Email = email;
            this.Github = github;
            this.Website = website;
        }

        public bool AddUser(UserProfile userDto)
        {
            return true;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}
