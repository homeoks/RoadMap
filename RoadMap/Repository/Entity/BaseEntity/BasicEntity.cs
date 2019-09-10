using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository.Entity.BaseEntity
{
	public class BasicEntity: IdentityEntity,IModifyEntity, ISoftDeleted
	{
	
		public string CreatedBy { get; set; }
		 public DateTime? CreatedTime { get; set; }
		 public string LastModifyBy { get; set; }
		 public DateTime? LastModifyTime { get; set; }
		
		 public bool IsDeleted { get; set; }
		 public string DeletedBy { get; set; }
		 public DateTime? DeletedTime { get; set; }
	}
}
