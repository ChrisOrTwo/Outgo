namespace Outgo.Contracts
{
    public class User : Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}