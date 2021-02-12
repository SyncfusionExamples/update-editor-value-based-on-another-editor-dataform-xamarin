using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataformXamarin
{
    public class DataFormModel : INotifyPropertyChanged
    {
        private string name;
        private string contactNo;
        private string city;
        private string country;
        private string password;
        private DateTime? birthDate;
        private int? age;

        public DataFormModel()
        {

        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != name)
                {
                    this.name = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        [Display(Name = "Contact Number")]
        public string ContactNumber
        {
            get { return contactNo; }
            set
            {
                if (value != contactNo)
                {
                    this.contactNo = value;
                    this.RaisePropertyChanged("ContactNumber");
                }
            }
        }
        [DataType(DataType.Password)]
        public string Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }

        public String Country
        {
            get { return country; }
            set
            {
                if (value != country)
                {
                    country = value;
                    this.RaisePropertyChanged("Country");
                }
            }
        }

        public String City
        {
            get { return city; }
            set
            {
                if (value != city)
                {
                    city = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        [Display(Name = "Birth date")]
        public DateTime? BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value != birthDate)
                {
                    birthDate = value;
                    this.RaisePropertyChanged("BirthDate");
                }
            }
        }
        public int? Age
        {
            get { return age; }
            set
            {
                if (value != age)
                {
                    age = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String PropertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}

