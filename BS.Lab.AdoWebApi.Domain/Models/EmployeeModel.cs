using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Lab.AdoWebApi.Domain.Models
{
    public class EmployeeModel : IEquatable<EmployeeModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Function { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DismissalDate { get; set; }

        /// <summary>
        /// Gets the service time in string format (years, months, days).
        /// </summary>
        /// <value>
        /// The service time.
        /// </value>
        /// <exception cref="System.NullReferenceException">The 'Hire Date' cannot be null</exception>
        public string ServiceTime
        {
            get
            {
                // If the auto property of this class HiredDate is default value (DateTime.MinValue) it throws an exception of type NullReferenceException
                if (HireDate == DateTime.MinValue) throw new NullReferenceException("The 'Hire Date' cannot be null");

                // Subtract to dismissal date (if not null otherwise the current date) the hired date, it will return a timespan
                var dateDifferenceTimeSpan = (DismissalDate ?? DateTime.Now) - HireDate;

                // Create a new DateTime object from the timespan's ticks
                var dateDifferenceDateTime = new DateTime(dateDifferenceTimeSpan.Ticks);

                // Format the resultant string with years, month and days from DateTime object
                return $"{dateDifferenceDateTime.Year - 1} year(s) {dateDifferenceDateTime.Month - 1} month(s) {dateDifferenceDateTime.Day - 1} day(s)";
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is currently employed (if DismissalDate is null).
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is currently employed; otherwise, <c>false</c>.
        /// </value>
        public bool IsCurrentlyEmployed
        {
            get
            {
                return (DismissalDate == null);
            }
        }

        public RoomModel Room { get; set; }

        // The IEquatable implementation is usefull in list's elements when u have to check if two instance are equals or not
        #region IEquatable implementation
        public override bool Equals(object obj)
        {
            return Equals(obj as EmployeeModel);
        }

        public bool Equals(EmployeeModel other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(EmployeeModel left, EmployeeModel right)
        {
            return EqualityComparer<EmployeeModel>.Default.Equals(left, right);
        }

        public static bool operator !=(EmployeeModel left, EmployeeModel right)
        {
            return !(left == right);
        } 
        #endregion
    }
}
