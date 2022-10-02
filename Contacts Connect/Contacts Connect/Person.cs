namespace Contacts_Connect
{
    // a holder class for incoming data
    public class Person
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phoneNumber { get; set; }

        public string fullInfo
        {
            get
            {
                return $"{firstname} {lastname}\t\t{phoneNumber}";
            }
        }
    }
}