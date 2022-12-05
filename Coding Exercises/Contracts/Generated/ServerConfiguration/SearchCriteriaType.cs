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
    public partial class SearchCriteriaType
    {
        
        private string serverConfigurationIdField;
        
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
    }
}
