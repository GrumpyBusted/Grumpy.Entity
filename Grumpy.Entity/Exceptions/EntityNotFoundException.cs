using System;
using System.Runtime.Serialization;
using Grumpy.Json;

namespace Grumpy.Entity.Exceptions
{
    // ReSharper disable once UnusedMember.Global
    [Serializable]
    public sealed class EntityNotFoundException : Exception
    {
        private EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EntityNotFoundException(object obj) : base("Entity not Found")
        {
            Data.Add("Object", obj.TrySerializeToJson());
        }
    }
}