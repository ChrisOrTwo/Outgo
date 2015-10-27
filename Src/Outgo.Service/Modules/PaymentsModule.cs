using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using Outgo.Contracts.Contract;
using Outgo.Service.Data;

namespace Outgo.Service.Service.Modules
{
	public class PaymentsModule : NancyModule
	{
		public PaymentsModule(IUserRepository userRepository, IPaymentRepository paymentRepository)
		{
			Get["/Payments"] = x =>
			{
				var payments = paymentRepository.GetAllPaymentsInGroup(1).ToList();
				return Response.AsJson(payments);
			};

			//Post["/Payments"] = x =>
			//{
			//	Payment payment = this.Bind<Payment>();
			//	payment.PaymentType = _model.Types.First(p => p.PaymentTypeId == payment.PaymentTypeId);
			//	paymentRepository.AddPayment(payment.UserId, payment.GroupId, payment.PaymentType, payment.Amount, payment.Date);
				
			//	return Response.AsRedirect("~/Payments");
			//};
		}
	}
}