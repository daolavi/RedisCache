using System;
using ProtoBuf;

namespace AwsElastiCache
{
    [ProtoContract]
    public class ProtoUser
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public DateTime Dob { get; set; }
    }

    [Serializable]
    public class BinaryUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }
    }

    public class JsonUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }
    }
}
