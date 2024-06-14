namespace VKRWebAPI.Clients
{
    public class Clients
    {
        public int ID { get; set; }
        public string? City { get; set; }

        public string? Contract { get; set; }

        public string? Address { get; set; }

        public string? IPAddress { get; set; }

        public string? Service { get; set; }

        public string? VLAN { get; set; }

        public bool ServicePaid { get; set; }
    }
}
