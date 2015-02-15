using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Services
{
    public interface IPaymentService
    {
        IList<Payment> GetPaymentsByUser(int userId, int groupId);
        IList<Payment> GetPaymentsByGroup(int groupId);
        IList<Payment> AddPayment(int userId, int groupId, int paymentTypeId, decimal amount, DateTime date);
    }
}