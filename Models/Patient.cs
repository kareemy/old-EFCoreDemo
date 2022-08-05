using System;
using System.Collections.Generic;

namespace EFCoreDemo
{
    public class Patient
    {
        public int PatientID {get; set;} // Primary Key
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;

        // ToString() method tells C# how we want to format this entity class
        // when we display it to the console
        public override string ToString()
        {
            return $"({PatientID}) {LastName}, {FirstName}";
        }
    }
}