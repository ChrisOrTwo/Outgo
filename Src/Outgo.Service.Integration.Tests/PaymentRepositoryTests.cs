using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Outgo.Contracts.Contract;
using Outgo.Service.Data;

namespace Outgo.Service.Integration.Tests
{
	[TestFixture]
	public class PaymentRepositoryTests : RepositoryTestsBase
	{
		IPaymentRepository Sut { get; set; }

		private IUserRepository _userRepository;

		[SetUp]
		public void Setup()
		{
			Sut = new PaymentRepository(TestingHost);
			_userRepository = new UserRepository(TestingHost);
		}

		[Test]
		public void GetPaymentTypes_returns_all_payment_types()
		{
			List<PaymentType> payments = Sut.GetPaymentTypes().ToList();
			Assert.IsNotEmpty(payments);
		}

		[Test]
		public void AddPayment_adds_payment()
		{
			User user = _userRepository.RegisterUser("user", "user");
			Group group = _userRepository.RegisterGroup("group");
			List<PaymentType> paymentTypes = Sut.GetPaymentTypes().ToList();

			Payment payment = Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));

			Assert.IsNotNull(payment);
			Assert.AreEqual(payment.GroupId,group.GroupId);
			Assert.AreEqual(payment.UserId, user.UserId);
			Assert.AreEqual(payment.PaymentTypeId,paymentTypes.First().PaymentTypeId);
			Assert.AreEqual(payment.Amount,100);
			Assert.AreEqual(payment.Date,new DateTime(2,2,2));
		}

		[Test]
		public void GetAllUserPayments_returns_payments_of_given_user()
		{
			User user = _userRepository.RegisterUser("user", "user");
			User userSecond = _userRepository.RegisterUser("userSecond", "userSecond");
			Group group = _userRepository.RegisterGroup("group");
			Group groupSecond = _userRepository.RegisterGroup("groupSecond");
			List<PaymentType> paymentTypes = Sut.GetPaymentTypes().ToList();

			Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(userSecond.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(userSecond.UserId, @groupSecond.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));

			var payments = Sut.GetAllUserPayments(user.UserId);

			Assert.AreEqual(payments.Count, 2);
			Assert.AreEqual(payments.First().PaymentType.Description, paymentTypes.First().Description);
		}

		[Test]
		public void GetAllPaymentsInGroup_returns_payments_of_given_group()
		{
			User user = _userRepository.RegisterUser("user", "user");
			User userSecond = _userRepository.RegisterUser("userSecond", "userSecond");
			Group group = _userRepository.RegisterGroup("group");
			Group groupSecond = _userRepository.RegisterGroup("groupSecond");
			List<PaymentType> paymentTypes = Sut.GetPaymentTypes().ToList();

			Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(userSecond.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(userSecond.UserId, @groupSecond.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));

			var payments = Sut.GetAllPaymentsInGroup(group.GroupId);

			Assert.AreEqual(payments.Count, 3);
		}

		[Test]
		public void GetUserPaymentsInGroup_returns_payments_of_given_user_in_group()
		{
			User user = _userRepository.RegisterUser("user", "user");
			User userSecond = _userRepository.RegisterUser("userSecond", "userSecond");
			Group group = _userRepository.RegisterGroup("group");
			Group groupSecond = _userRepository.RegisterGroup("groupSecond");
			List<PaymentType> paymentTypes = Sut.GetPaymentTypes().ToList();

			Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(userSecond.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(userSecond.UserId, @groupSecond.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));

			var payments = Sut.GetUserPaymentsInGroup(userSecond.UserId ,groupSecond.GroupId);

			Assert.AreEqual(payments.Count, 1);
		}

		[Test]
		public void GetUserPaymentsInGroup_returns_empty_payments_if_user_has_no_payments_in_group()
		{
			User user = _userRepository.RegisterUser("user", "user");
			User userSecond = _userRepository.RegisterUser("userSecond", "userSecond");
			Group group = _userRepository.RegisterGroup("group");
			Group groupSecond = _userRepository.RegisterGroup("groupSecond");
			List<PaymentType> paymentTypes = Sut.GetPaymentTypes().ToList();

			Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(user.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(userSecond.UserId, @group.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));
			Sut.AddPayment(userSecond.UserId, @groupSecond.GroupId, paymentTypes.First(), 100, new DateTime(2, 2, 2));

			var payments = Sut.GetUserPaymentsInGroup(user.UserId, groupSecond.GroupId);

			Assert.AreEqual(payments.Count, 0);
		}
	}
}