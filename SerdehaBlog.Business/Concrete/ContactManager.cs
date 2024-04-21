using SerdehaBlog.Business.Absract;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Concrete
{
	public class ContactManager : IContactService
	{
		private readonly IUnitOfWork _unitOfWork;
        public ContactManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Contact entity)
		{
			if(entity != null)
			{
				_unitOfWork.Contact.Add(entity);
				_unitOfWork.SaveChanges();
			}
		}

		public async Task<int> AddAsync(Contact entity)
		{
			if(entity != null )
			{
				await _unitOfWork.Contact.AddAsync(entity);
				return await _unitOfWork.SaveChangesAsync();
			}

			return 0;
		}

		public void Delete(Contact entity)
		{
			if(entity != null )
			{
				entity.IsActive = false;
				entity.IsDeleted = true;
				_unitOfWork.Contact.Update(entity);
				_unitOfWork.SaveChanges();
			}
		}

		public async Task<int> DeleteAsync(Contact entity)
		{
			if (entity != null)
			{
				entity.IsActive = false;
				entity.IsDeleted = true;
				await _unitOfWork.Contact.UpdateAsync(entity);
				return await _unitOfWork.SaveChangesAsync();
			}

			return 0;
		}

        public async Task<Contact?> GetContact()
        {
            return await _unitOfWork.Contact.GetContact();
        }

        public List<Contact> GetAll(Expression<Func<Contact, bool>>? filter = null)
		{
			return filter == null ? _unitOfWork.Contact.GetAll() : _unitOfWork.Contact.GetAll(filter);
		}

		public List<Contact> GetAllWithFilter(Expression<Func<Contact, bool>>? predicate = null, params Expression<Func<Contact, object>>[] includeProperties)
		{
			return _unitOfWork.Contact.GetAllWithFilter(predicate, includeProperties);
		}

		public async Task<List<Contact>> GetAllWithFilterAsync(Expression<Func<Contact, bool>>? predicate = null, params Expression<Func<Contact, object>>[] includeProperties)
		{
			return await _unitOfWork.Contact.GetAllWithFilterAsync(predicate, includeProperties);
		}

		public Contact? GetById(int entityId)
		{
			return _unitOfWork.Contact.GetById(x => x.Id == entityId);
		}

		public async Task<Contact?> GetByIdAsync(int entityId)
		{
			return await _unitOfWork.Contact.GetByIdAsync(x => x.Id == entityId);
		}

		public int GetCount(Expression<Func<Contact, bool>>? filter = null)
		{
			return filter == null ? _unitOfWork.Contact.GetCount() : _unitOfWork.Contact.GetCount(filter);
		}

		public async Task<int> GetCountAsync(Expression<Func<Contact, bool>>? filter = null)
		{
			return filter == null ? await _unitOfWork.Contact.GetCountAsync() : await _unitOfWork.Contact.GetCountAsync(filter);
		}

		public Contact? GetWithFilter(Expression<Func<Contact, bool>>? predicate = null, params Expression<Func<Contact, object>>[] includeProperties)
		{
			return _unitOfWork.Contact.GetWithFilter(predicate, includeProperties);	
		}

		public async Task<Contact?> GetWithFilterAsync(Expression<Func<Contact, bool>>? predicate = null, params Expression<Func<Contact, object>>[] includeProperties)
		{
			return await _unitOfWork.Contact.GetWithFilterAsync(predicate, includeProperties); 
		}

		public void HardDelete(Contact entity)
		{
			if(entity != null)
			{
				_unitOfWork.Contact.HardDelete(entity);
				_unitOfWork.SaveChanges();
			}
		}

		public async Task<int> HardDeleteAsync(Contact entity)
		{
			if(entity != null)
			{
				await _unitOfWork.Contact.HardDeleteAsync(entity);
				return await _unitOfWork.SaveChangesAsync();
			}

			return 0;
		}

		public void Update(Contact entity)
		{
			if(entity != null)
			{
				_unitOfWork.Contact.Update(entity);
				_unitOfWork.SaveChanges();
			}
		}

		public async Task<int> UpdateAsync(Contact entity)
		{
			if(entity != null)
			{
				await _unitOfWork.Contact.UpdateAsync(entity);
				return await _unitOfWork.SaveChangesAsync();
			}

			 return 0;
		}
	}
}
