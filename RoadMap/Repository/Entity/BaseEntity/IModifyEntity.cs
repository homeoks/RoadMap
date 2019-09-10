using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entity.BaseEntity
{
	public interface IModifyEntity
	{
		 string CreatedBy { get; set; }
		 DateTime? CreatedTime { get; set; }
		 string LastModifyBy { get; set; }
		 DateTime? LastModifyTime { get; set; }
	}
}
