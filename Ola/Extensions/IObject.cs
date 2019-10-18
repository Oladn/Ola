namespace Ola.Extensions
{
    /// <summary>
    /// 唯一Id对象接口。
    /// </summary>
    /// <typeparam name="TKey">Id类型。</typeparam>
    public interface IObject<TKey>
    {
        /// <summary>
        /// 获取或设置唯一Id。
        /// </summary>
        TKey Id { get; set; }
    }

    /// <summary>
    /// 唯一Id对象接口。
    /// </summary>
    public interface IObject : IObject<int>
    {
    }
}