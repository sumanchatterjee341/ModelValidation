
namespace ModelValidation.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
    public class Student : Person
    {
        public int RollNumber { get; set; }
        public string SchoolName { get; set; }
    }   
    public class Response
    {
        public bool SuccessIn { get; set; }
        public string ErrorMessage { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
    public enum ErrorCode
    {
        ERR1,
        ERR2,
        ERR3
    }

}
