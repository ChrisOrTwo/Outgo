using System;
using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Services
{
    public class PaymentRepository : RepositoryBase, IPaymentRepository
    {
        
        public PaymentRepository(IDatabaseHost host) : base(host)
        {
        }

        public IList<Payment> GetAllUserPayments(int userId)
        {
            return Call<List<Payment>>(db => db.DatabaseConnection.Payments.FindAllByUserId(userId));
        }

        public IList<Payment> GetUserPaymentsInGroup(int userId, int groupId)
        {
            return Call<List<Payment>>(db => db.DatabaseConnection.Payments.FindAllByUserIdAndGroupId(userId,groupId));
        }

        public IList<Payment> GetAllPaymentsInGroup(int groupId)
        {
            return Call<List<Payment>>(db => db.DatabaseConnection.Payments.FindAllByGroupId(groupId));
        }

        public IList<Payment> AddPayment(int userId, int groupId, int paymentTypeId, decimal amount, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}