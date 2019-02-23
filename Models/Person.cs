using System;

namespace vmf2.Models
{
  public class Person
  {
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Person(int personId, string firstName, string lastName)
    {
      PersonId = personId;
      FirstName = firstName;
      LastName = lastName;
    }
  }
}