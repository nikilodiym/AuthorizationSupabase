using WPFIntroPlusDBMy.Entity;
using DatabaseService.Abstractions;

namespace WPFIntroPlusDBMy.Abstractions;

public interface IModelToEntity
{
    public IEntity ToEntity(IModel model);
}