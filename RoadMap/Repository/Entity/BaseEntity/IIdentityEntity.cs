﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository.Entity.BaseEntity
{
	public class IdentityEntity
	{
		[BsonId]
		[BsonRepresentation((BsonType.ObjectId))]
		public string Id { get; set; }
	}
}
