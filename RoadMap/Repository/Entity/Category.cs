using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository.Entity
{
	public class Category
	{
		[BsonId]
		[BsonRepresentation((BsonType.ObjectId))]
		public string Id { get; set; }
		[BsonElement("Name")]
		public string BookName { get; set; }
		public decimal Price { get; set; }
		public string Author { get; set; }
	}
}
