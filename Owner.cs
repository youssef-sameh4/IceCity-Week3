
    public class Owner
    {
      public string OwnerName { get; set; }
      public string PhoneNumber {  get; set; }
     public string Email {  get; set; }
    public string Address { get; set; }
    public List<House>houses=new List<House>();
    public Owner()
    { }
    public Owner( string ownerName, string phoneNumber, string email, string address, List<House> houses)
    {
        OwnerName = ownerName;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        this.houses = houses;
    }
}
