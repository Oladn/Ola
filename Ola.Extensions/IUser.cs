namespace Ola.Extensions
{
    /// <summary>
    /// 用户接口。
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 用户Id。
        /// </summary>
        int UserId { get; }

        /// <summary>
        /// 登录名称。
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// 电子邮件。
        /// </summary>
        string Email { get; }
    }
}