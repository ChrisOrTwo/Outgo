using System;
using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Data
{
	public interface IPaymentRepository : IRepositoryBase
	{
		IList<PaymentType> GetPaymentTypes();
		IList<Payment> GetAllUserPayments(int userId);
		IList<Payment> GetUserPaymentsInGroup(int userId, int groupId);
		IList<Payment> GetAllPaymentsInGroup(int groupId);
		Payment AddPayment(int userId, int groupId, PaymentType paymentType, decimal amount, DateTime date);
	}
}