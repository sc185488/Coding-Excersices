using Retalix.Jumbo.Common.TLog;
using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Document.ControlTransaction;
using Retalix.StoreServices.Model.Infrastructure.Globalization;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;
using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Retalix.Jumbo.BusinessComponents.TLog
{
    [RegisterAddition]
    public class TransactionTimeCalculationVisitor : IRetailTransactionLogDocumentCreationVisitor
    {

        private readonly IEnumerable<ILogDocumentExtenderVisitor> _visitors;

        public TransactionTimeCalculationVisitor(IEnumerable<ILogDocumentExtenderVisitor> visitors)
        {
            _visitors = visitors;
        }

        public TransactionTimeCalculationVisitor()
        {
            _visitors = GlobalEnvironment.StoreApplication.Resolver.ResolveAll<ILogDocumentExtenderVisitor>().ToList();
        }

        public void Visit(IRetailTransaction retailTransaction, IRetailTransactionLogDocumentWriter writer)
        {
            var tranasction = writer.LogDocument.ObjectContent as TransactionDomainSpecific;
            XmlElement transactionDurationElement =
            ToXmlElement(new XElement("TransactionTime", (retailTransaction.EndTime - retailTransaction.StartTime).ToString(@"hh\:mm\:ss"), new XAttribute("format", "hh:mm:ss")));
            tranasction.Any = new List<XmlElement> { transactionDurationElement };
            writer.UpdateArtsTransaction(tranasction);
        }

        private static XmlElement ToXmlElement(XElement el)
        {
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }
    }
}
