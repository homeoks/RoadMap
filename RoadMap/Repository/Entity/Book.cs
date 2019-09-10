using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Repository.Entity.BaseEntity;

namespace Repository.Entity
{
	public class Book : BasicEntity
	{
		[BsonElement("Name")]
		public string BookName { get; set; }
		public decimal Price { get; set; }
		public string Category { get; set; }
		public string Author { get; set; }
	}
}
