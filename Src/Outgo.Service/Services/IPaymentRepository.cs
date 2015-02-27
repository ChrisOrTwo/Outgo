using System;
using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Services
{
    public interface IPaymentRepository
    {
        IList<Payment> GetAllUserPayments(int userId);

        IList<Payment> GetUserPaymentsInGroup(int userId, int groupId);
 
        IList<Payment> GetAllPaymentsInGroup(int groupId);
        
        IList<Payment> AddPayment(int userId, int groupId, int paymentTypeId, decimal amount, DateTime date);
    }
}