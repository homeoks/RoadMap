using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entity.BaseEntity
{
	public interface ISoftDeleted
	{
		 bool IsDeleted { get; set; }
		 string DeletedBy { get; set; }
		 DateTime? DeletedTime { get; set; }
	}
}
