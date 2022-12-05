namespace Retalix.Jumbo.Contracts.Generated.ServerConfiguration
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute("ServerConfigurationLookupResponse", Namespace="http://retalix.com/R10/services", IsNullable=false)]
    public partial class ServerConfigurationLookupResponseType : Retalix.Contracts.Interfaces.IHeaderResponse
    {
        
        private RetalixCommonHeaderType headerField;
        
        private ServerConfigurationType[] serverConfigurationsField;
        
        public RetalixCommonHeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("ServerConfigurations")]
        public ServerConfigurationType[] ServerConfigurations
        {
            get
            {
                return this.serverConfigurationsField;
            }
            set
            {
                this.serverConfigurationsField = value;
            }
        }
    }
}
