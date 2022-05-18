using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Patient
    {

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Doctor Doctor { get; set; }
        public string ReservedTime { get; set; }

        public Patient(string? name, string? surname, string? email, string? phoneNumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
           
        }


        public override string ToString()
        {
            return $"Patient name: {Name}\nPatient surname: {Surname}\nEmail: {Email}\nPhone number:{PhoneNumber}\nDoctor Name: {Doctor.Name}\n" +
                $"Doctor Surname: {Doctor.Surname}\nDoctor Branch: {Doctor.Branch}\n Reserved time: {DateOnly.FromDateTime(DateTime.Now)}, {ReservedTime}";
        }
    }
}
