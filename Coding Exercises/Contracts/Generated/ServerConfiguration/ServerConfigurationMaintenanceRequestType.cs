namespace Retalix.Jumbo.Contracts.Generated.ServerConfiguration
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute("ServerConfigurationMaintenanceRequest", Namespace="http://retalix.com/R10/services", IsNullable=false)]
    public partial class ServerConfigurationMaintenanceRequestType : Retalix.Contracts.Interfaces.IHeaderRequest
    {
        
        private RetalixCommonHeaderType headerField;
        
        private ServerConfigurationType[] serverConfigurationField;
        
        private ActionTypeCodes actionField;
        
        private bool ActionFieldSpecified;
        
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
        
        [System.Xml.Serialization.XmlElementAttribute("ServerConfiguration")]
        public ServerConfigurationType[] ServerConfiguration
        {
            get
            {
                return this.serverConfigurationField;
            }
            set
            {
                this.serverConfigurationField = value;
            }
        }
        
        public ActionTypeCodes Action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
                this.ActionSpecified = true;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool ActionSpecified
        {
            get
            {
                return this.ActionFieldSpecified;
            }
            set
            {
                this.ActionFieldSpecified = value;
            }
        }
    }
}
