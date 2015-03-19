using System;

namespace Outgo.Contracts.Contract
{
	public class Payment
	{
		public int PaymentId { get; set; }
		public int UserId { get; set; }
		public int GroupId { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
	}
}