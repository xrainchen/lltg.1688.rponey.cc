namespace lltg._1688.rponey.cc.Model.Entity
{
    /// <summary>
    /// 数据库表接口
    /// </summary>
    public interface IEntity
    {

    }
    /// <summary>
    /// 唯一实体
    /// </summary>
    public interface IIdentityEntity : IEntity
    {
        long Id { get; set; }
    }
}
