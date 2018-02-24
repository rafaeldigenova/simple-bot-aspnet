using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Infra
{
    public abstract class AggregateRoot : IEquatable<AggregateRoot>
    {
        public Guid Id { get; protected set; }

        protected AggregateRoot()
        {
            Id = Guid.NewGuid();
        }

        protected AggregateRoot(Guid id)
        {
            Id = id;
        }

        public bool Equals(AggregateRoot other)
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

        public static bool operator ==(AggregateRoot entidade1, AggregateRoot entidade2)
        {
            if (Equals(entidade1, null) && Equals(entidade2, null)) return true;

            if (Equals(entidade1, null) || Equals(entidade2, null)) return false;

            return entidade1.Equals(entidade2);
        }

        public static bool operator !=(AggregateRoot entidade1, AggregateRoot entidade2)
        {
            return !(entidade1 == entidade2);
        }
    }
}