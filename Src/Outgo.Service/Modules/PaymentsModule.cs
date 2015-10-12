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
		readonly PaymentModel _model = new PaymentModel();

		public PaymentsModule(IUserRepository userRepository, IPaymentRepository paymentRepository)
		{
			Get["/Payments"] = x =>
			{
				PopulateModel(userRepository, paymentRepository);
				_model.Payments = paymentRepository.GetAllPaymentsInGroup(1).ToList();

				return View["Payments.html", _model];
			};

			Post["/Payments"] = x =>
			{
				Payment payment = this.Bind<Payment>();
				PopulateModel(userRepository, paymentRepository);
				payment.PaymentType = _model.Types.First(p => p.PaymentTypeId == payment.PaymentTypeId);
				paymentRepository.AddPayment(payment.UserId, payment.GroupId, payment.PaymentType, payment.Amount, payment.Date);
				
				return Response.AsRedirect("~/Payments");
			};
		}

		private void PopulateModel(IUserRepository userRepository, IPaymentRepository paymentRepository)
		{
			_model.Groups = userRepository.GetAllGroups();
			_model.Users = userRepository.GetAllUsers();
			_model.Types = paymentRepository.GetPaymentTypes().ToList();
		}

		public class PaymentModel
		{
			public List<Payment> Payments { get; set; }

			public List<PaymentType> Types { get; set; }

			public List<User> Users { get; set; }

			public List<Group> Groups { get; set; }
		}
	}
}