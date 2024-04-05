using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value;
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                lastName = value;
            }
        }

        private string drivingLicenseNumber;

        public string DrivingLicenseNumber
        {
            get { return drivingLicenseNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                drivingLicenseNumber = value;
            }
        }

        private double rating;

        public double Rating
        {
            get { return rating; }
            private set { rating = value; }
        }

        private bool isBlocked;

        public bool IsBlocked
        {
            get { return isBlocked; }
            private set { isBlocked = value; }
        }


        public void IncreaseRating()
        {
            if (this.rating + 0.5 < 10.0)
            {
                this.rating += 0.5;
            }
            else
            {
                this.rating = 10.0;
            }
        }

        public void DecreaseRating()
        {
            if (this.rating - 2.0 >= 0)
            {
                this.rating -= 2.0;
            }
            else
            {
                this.rating = 0.0;
                IsBlocked = true;
            }

        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }

    }
}
