using trendy.shopping.domain.Data;

namespace trendy.shopping.domain.UnitOfWork;

public interface ITrendyShoppingUnitOfWork : IUnitOfWork { }
public class TrendyShoppingUnitOfWork : UnitOfWork, ITrendyShoppingUnitOfWork
{
    public TrendyShoppingUnitOfWork(TrendyShoppingContext context) : base(context) { }
}
