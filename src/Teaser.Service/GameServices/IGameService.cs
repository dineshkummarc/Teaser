using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teaser.Entities;


namespace Teaser.Service.GameServices
{
    public interface IGameService
    {
        IList<Game> GetGamesByWeekId(int weekId);
        Game Save(Game item);
        bool Delete(Game item);  

        /*
         * 
         * 
    public interface IRepository<T> where T : class

    IEnumerable<T> FindAll(Func<T, bool> exp);

          IList<Shape> threeSidedShapes = 
  _genericShapeRepository.FindAll(shape => 
       shape.NumberOfSides == 3).Take(5).ToList();
         
         * 
        Func<T, bool> exp
                    return FindAll(shape => shape.NumberOfSides == sideCount);
        
    public IEnumerable<T> FindAll(Func<T, bool> exp)
    {
        return GetTable.Where<T>(exp);
    }
         * 
         * public interface IShapeRepository : IRepository<Shape>
{
    Shape RetrieveByNumberOfSides(int sideCount)
}

public class ShapeRepository : Repository<Shape>, IShapeRepository
{
    public Shape RetrieveByNumberOfSides(int sideCount)
    {
        return FindAll(shape => shape.NumberOfSides == sideCount);
    }
}
         * 
         *         IList<Shape> threeSidedShapes = 
          _genericShapeRepository.FindAll(shape => shape.NumberOfSides == 3).ToList();


         * 
         * 


        IQueryable<HtmlContent> Get(DateTime dt);
        IQueryable<HtmlContent> Get();
        IQueryable<HtmlContent> Get(int pageIndex, int pageSize, out int totalCount);
        HtmlContent Get(int id);
        HtmlContent Get(string name, DateTime dt);
        HtmlContent Save(HtmlContent item);
        bool Delete(HtmlContent item); 

      * */

    }
}
