﻿using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Absract
{
	public interface IContactService : IBaseService<Contact>
	{
        Task<Contact?> GetContact();
    }
}
