using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Infra
{
    public abstract class EntidadeBase : IEquatable<EntidadeBase>
    {
        public Guid Id { get; protected set; }

        [BsonExtraElements]
        public BsonDocument etc { get; set; }

        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        protected EntidadeBase(Guid id)
        {
            Id = id;
        }

        public bool Equals(EntidadeBase other)
        {
            if (Equals(null, other)) return false;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var entidade = obj as AggregateRoot;

            if (Equals(null, entidade)) return false;

            return Equals(entidade);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(EntidadeBase entidade1, EntidadeBase entidade2)
        {
            if (Equals(entidade1, null) && Equals(entidade2, null)) return true;

            if (Equals(entidade1, null) || Equals(entidade2, null)) return false;

            return entidade1.Equals(entidade2);
        }

        public static bool operator !=(EntidadeBase entidade1, EntidadeBase entidade2)
        {
            return !(entidade1 == entidade2);
        }
    }
}