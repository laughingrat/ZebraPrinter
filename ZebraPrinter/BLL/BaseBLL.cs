using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ZebraPrinter.DAL;
using ZebraPrinter.Entity;

namespace ZebraPrinter.BLL
{
  public abstract class BaseBLL<T, K, M>
    where T : BaseEntity
    where K : BaseSearchEntity
    where M : OperationDao<T, K>
  {

    protected M dao;

    public BaseBLL(M dao)
    {
      this.dao = dao;
    }

    protected string[] Validate(T entity)
    {
      var results = new List<ValidationResult>();
      var isValid = Validator.TryValidateObject(entity, new ValidationContext(entity, null, null), results);

      if (isValid)
        return new string[] { };

      var sb = new StringBuilder();
      foreach (var result in results)
      {
        sb.AppendLine(result.ErrorMessage);
      }

      return results.Select(r => r.ErrorMessage).ToArray();
    }

    protected void HandleValidation(T entity)
    {
      var validationMessages = Validate(entity);
      if (validationMessages.Length > 0)
      {
        throw new ArgumentException("请添加正确的属性" + string.Join("\n", validationMessages));
      }
    }

    public T Create(T entity)
    {
      entity.Id = 0;
      entity.InsertedOn = DateTime.Now;
      entity.UpdatedOn = entity.InsertedOn;

      HandleValidation(entity);

      return dao.Create(entity);
    }

    public bool Update(T entity)
    {
      if (entity.Id < 1)
      {
        throw new ArgumentException("不正确的id");
      }

      entity.UpdatedOn = DateTime.Now;
      HandleValidation(entity);

      return dao.Update(entity);
    }

    public bool Delete(int id)
    {
      if (id < 1)
      {
        throw new ArgumentException("不正确的id");
      }

      return dao.Delete(id);
    }

    public T Retrieve(int id)
    {
      if (id < 1)
      {
        throw new ArgumentException("不正确的id");
      }

      return dao.Retrieve(id);
    }

    public virtual List<T> Search(List<int> ids)
    {
      if (ids == null || ids.Count == 0)
      {
        return new List<T>();
      }

      return dao.Search(ids);
    }

    public virtual List<T> Search(K search)
    {
      if (search == null)
      {
        throw new ArgumentNullException();
      }

      return dao.Search(search);
    }

   
  }
}
