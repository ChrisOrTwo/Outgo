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
		PaymentViewModel _model = new PaymentViewModel();

		public PaymentsModule(IUserRepository userRepository, IPaymentRepository paymentRepository)
		{
			Get["/Payments"] = x =>
			{
				PopulateModel(userRepository, paymentRepository);
				_model.Payments = paymentRepository.GetAllPaymentsInGroup(_model.Group.GroupId).ToList();

				return View["Payments.html", _model];
			};

			Post["/Payments"] = x =>
			{
				Payment payment = this.Bind<Payment>();
				PopulateModel(userRepository, paymentRepository);
				payment.PaymentType = _model.Types.First(p => p.PaymentTypeId == payment.PaymentTypeId);
				paymentRepository.AddPayment(payment.UserId, payment.GroupId, payment.PaymentType, payment.Amount, payment.Date);
				_model.Payments = paymentRepository.GetAllPaymentsInGroup(_model.Group.GroupId).ToList();
				return View["Payments.html", _model];
			};
		}

		private void PopulateModel(IUserRepository userRepository, IPaymentRepository paymentRepository)
		{
			_model.Group = userRepository.GetGroup(1);
			_model.Users = userRepository.GetUsersByGroup(_model.Group.GroupId);
			_model.Types = paymentRepository.GetPaymentTypes().ToList();
		}

		public class PaymentViewModel
		{
			public List<Payment> Payments { get; set; }

			public List<PaymentType> Types { get; set; }

			public List<User> Users { get; set; }

			public Group Group { get; set; }
		}
	}
}