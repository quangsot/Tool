namespace CapCutTool.Service
{
    public interface IPersonService
    {
        (string, int) GetInfo();
    }
    public class PersonService : IPersonService
    {
        public string NamePerson { get; set; } = "Quang";
        public int Age { get; set; } = 20;
        public (string, int) GetInfo()
        {
            return (NamePerson, Age);
        }
    }

}
