using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SimpleBot.Infra
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; protected set; }

        [BsonExtraElements]
        public BsonDocument etc { get; set; }
    }
}