using System.ComponentModel.DataAnnotations.Schema;
using Ola.Extensions.Categories;

namespace Ola.Apis.Entities
{
    /// <summary>
    /// 分类。
    /// </summary>
    [Table("apis_Categories")]
    public class Category : CategoryBase
    {

    }
}