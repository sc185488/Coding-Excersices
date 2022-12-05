namespace Retalix.Jumbo.Contracts.Generated.ServerConfiguration
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=true)]
    public partial class ServerConfigurationType
    {
        
        private string serverConfigurationIdField;
        
        private string serverConfigurationNameField;
        
        private string entityTypeField;
        
        private string entityParameterField;
        
        private string valueField;
        
        public string ServerConfigurationId
        {
            get
            {
                return this.serverConfigurationIdField;
            }
            set
            {
                this.serverConfigurationIdField = value;
            }
        }
        
        public string ServerConfigurationName
        {
            get
            {
                return this.serverConfigurationNameField;
            }
            set
            {
                this.serverConfigurationNameField = value;
            }
        }
        
        public string EntityType
        {
            get
            {
                return this.entityTypeField;
            }
            set
            {
                this.entityTypeField = value;
            }
        }
        
        public string EntityParameter
        {
            get
            {
                return this.entityParameterField;
            }
            set
            {
                this.entityParameterField = value;
            }
        }
        
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}
