using ProtoBuf;
using Retalix.Jumbo.Model.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.ServerConfiguration
{

    [Serializable]
    [ProtoContract]
    public class ServerConfiguration : IServerConfiguration
    {
        [ProtoMember(1)]
        public string ServerConfigurationId { get; set; }

        [ProtoMember(2)]
        public string ServerConfigurationName { get; set; }

        [ProtoMember(3)]
        public string EntityType { get; set; }

        [ProtoMember(4)]
        public string EntityParameter { get; set; }

        [ProtoMember(5)]
        public string Value { get; set; }

        [ProtoMember(6)]
        public string EntityName
        {
            get { return "ServerConfiguration"; }
            set { }
        }

        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ServerConfiguration)) return false;
            return Equals((ServerConfiguration)obj);
        }


        public bool Equals(ServerConfiguration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.ServerConfigurationId , ServerConfigurationId);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (ServerConfigurationId != null ? ServerConfigurationId.GetHashCode() : 0);
                //result = (result * 397) ^ (EntityType != null ? EntityType.GetHashCode() : 0);
                //result = (result * 397) ^ (EntityParameter != null ? EntityParameter.GetHashCode() : 0);
                return result;
            }
        }
    }
}
