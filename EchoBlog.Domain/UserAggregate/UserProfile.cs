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
        /// 用户头像（地址）
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        /// 用户介绍
        /// </summary>
        public string Introduction { get; private set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string Roles { get; private set; }

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

        public UserProfile(string name, string avatar, string introduction,
            string roles, string email, string github, string website)
        {
            this.Name = name;
            this.Avatar = avatar;
            this.Introduction = introduction;
            this.Roles = roles;
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
