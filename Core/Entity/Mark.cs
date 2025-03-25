using DatabaseService.Abstractions;
using WPFIntroPlusDBMy.Abstractions;

namespace WPFIntroPlusDBMy.Entity;

public class Mark : IEntity, IModelToEntity
{
    public IEntity ToEntity(IModel model)
    {
        throw new NotImplementedException();
    }
}