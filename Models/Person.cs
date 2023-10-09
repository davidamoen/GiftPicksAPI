using giftpicksapi.Enums;

namespace giftpicksapi.Models;
public class Person 
{
        public Person(Members name)
        {
            Name = name;
            Siblings = new List<Members>();
            Children = new List<Members>();
        }
        public Members Name { get; set; }
        public Members Spouse { get; set; }
        public List<Members> Siblings { get; set; }
        public List<Members> Children { get; set; }
}