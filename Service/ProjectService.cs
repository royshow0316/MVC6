using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using MVC.Models.Interface;
using MVC.Models.Repository;
using Service.Interface;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _repository;

        public ProjectService(IRepository<Project> repository)
        {
            this._repository = repository;
        }

        public void Create(Project entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _repository.Create(entity);
            }
        }

        public void Update(Project entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _repository.Update(entity);
            }
        }

        public void Delete(Guid id)
        {
            if (!IsExists(id))
            {

            }
            else
            {
                var entity = GetById(id);
                _repository.Delete(entity);
            }
        }

        public bool IsExists(Guid id)
        {
            return _repository.GetAll().Any(x => x.Id == id);
        }

        public Project GetById(Guid id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
