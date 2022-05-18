using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Doctor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public string? Branch { get; set; }

        public string[] WorkingHours { get; set; }
        public string[] ReservedHours { get; set; }

        public Doctor(string name, string surname, int experience, string? branch, string[] workingHours, string[] reservedHours)
        {
            Name = name;
            Surname = surname;
            Experience = experience;
            Branch = branch;
            WorkingHours = workingHours;
            ReservedHours = reservedHours;
        }


        public override string ToString()
        {
            return $"Doctor name: {Name}\nDoctor surname: {Surname}\nExperience: {Experience}years\nBranch: {Branch}\n" +
                         $"{WorkingHours[0]}:{ReservedHours[0]}\n{WorkingHours[1]}:{ReservedHours[1]}\n{WorkingHours[2]}:{ReservedHours[2]}\n\n\n";
        }

    }
}
