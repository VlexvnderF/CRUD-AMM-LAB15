using System;
using Database2022.Models;
using Database2022.Services;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Database2022.ViewModels
{
    public class ViewModelPeople: BaseViewModel
    {
        private string color;
        public string Color
        {
            get { return this.color; }
            set { SetValue(ref this.color, value); }
        }


        private string firstName;

        public string FirstName
        {
            get { return this.firstName; }
            set { SetValue(ref this.firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return this.lastName; }
            set { SetValue(ref this.lastName, value); }
        }


        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }
        }

        private List<Person> people;
        public List<Person> People
        {
            get { return this.people; }
            set { SetValue(ref this.people, value); }
        }


        public ICommand SearchCommand { get; set; }

        public ICommand InsertCommand { get; set; }
        public ViewModelPeople()
        {

            SearchCommand = new Command(() =>
            {
                PersonService service = new PersonService();
                People = service.GetByText(Filter);
                //if (People.Count > 3)
                 //   Color = "Red";
                //else
                 //   Color = "Blue";

            });

            InsertCommand = new Command(() =>
            {
               

                PersonService service = new PersonService();
                int newPersonId = service.Get().Count + 1;
                service.Create(new Person { FirstName = FirstName, LastName = LastName, PersonId = 1 });
            });


        }


    }
}
