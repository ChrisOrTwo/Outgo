using System;
using System.Collections.Generic;
using Outgo.Contracts.Contract;

namespace Outgo.Service.Data
{
	public class PaymentRepository : RepositoryBase, IPaymentRepository
	{
		public PaymentRepository(IDatabaseHost host) : base(host)
		{
		}

		public IList<PaymentType> GetPaymentTypes()
		{
			return Call<List<PaymentType>>(db => db.Session.PaymentType.All());
		}

		public IList<Payment> GetAllUserPayments(int userId)
		{
			return Call<List<Payment>>(db => db.Session.Payment.FindAllByUserId(userId).WithPaymentType());
		}

		public IList<Payment> GetUserPaymentsInGroup(int userId, int groupId)
		{
			return Call<List<Payment>>(db => db.Session.Payment.FindAllByUserIdAndGroupId(userId, groupId).WithPaymentType());
		}

		public IList<Payment> GetAllPaymentsInGroup(int groupId)
		{
			return Call<List<Payment>>(db => db.Session.Payment.FindAllByGroupId(groupId).WithPaymentType());
		}

		public Payment AddPayment(int userId, int groupId, PaymentType paymentType, decimal amount, DateTime date)
		{
			var payment = new Payment()
			{
				UserId = userId,
				GroupId = groupId,
				Amount = amount,
				Date = date,
				PaymentTypeId = paymentType.PaymentTypeId
			};
			return Call<Payment>(db => db.Session.Payments.Insert(payment));
		}
	}
}