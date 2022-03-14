using System;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.SMTPClient
{
    public interface ISMTPservice : IDisposable
    {
        void SendNew(string thesType, string name, int bankCode);
        void SendUpd(string thesType, string name, int ncpiCode);
    }
}
