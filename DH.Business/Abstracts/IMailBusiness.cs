using DH.Entities.Entities;
using System.Collections.Generic;

namespace DH.Business.Abstracts
{
    public interface IMailBusiness
    {
        Mail Get(int mailId);

        List<Mail> GetAll();

        void Insert(Mail mail);

        void Update(Mail mail);

        void MarkAsDeleted(int mailId);
    }
}
