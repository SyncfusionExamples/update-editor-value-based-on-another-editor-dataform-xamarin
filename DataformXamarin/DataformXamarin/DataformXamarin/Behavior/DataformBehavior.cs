using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DataformXamarin
{
    public class DataformBehavior : Behavior<ContentPage>
    {
        SfDataForm dataForm;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            dataForm.DataObject = new DataFormModel();
            dataForm.SourceProvider = new SourceProviderExt();
            dataForm.RegisterEditor("Country", "DropDown");
            dataForm.RegisterEditor("City", "DropDown");
            this.WireEvents();
        }
        private void WireEvents()
        {
            (dataForm.DataObject as DataFormModel).PropertyChanged += OnDataObjectPropertyChanged;
            dataForm.AutoGeneratingDataFormItem += OnAutoGeneratingDataFormItem;
        }
        private void OnAutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (e.DataFormItem.Name == "Country" || e.DataFormItem.Name == "City")
                {
                    (e.DataFormItem as DataFormDropDownItem).DisplayMemberPath = "Name";
                    (e.DataFormItem as DataFormDropDownItem).SelectedValuePath = "Name";
                }
            }
        }

        private void OnDataObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var dataObject = sender as DataFormModel;
            if (e.PropertyName == "Country")
            {
                var country = dataObject.Country;
                var cityDataFormItem = dataForm.ItemManager.DataFormItems["City"];
                (cityDataFormItem as DataFormDropDownItem).ItemsSource = this.GetCityItemsSource(country);
                dataForm.UpdateEditor("City");
            }
            else if (e.PropertyName == "BirthDate" && dataObject.BirthDate != null && dataObject.BirthDate < DateTime.Now)
            {
                dataObject.Age = DateTime.Now.Year - dataObject.BirthDate.Value.Year;
                dataForm.UpdateEditor("Age");
            }
        }

        private List<City> GetCityItemsSource(String country)
        {
            List<City> cities = new List<City>();
            if (country == "USA")
            {
                cities.Add(new City { Code = 1, Name = "New York" });
                cities.Add(new City { Code = 2, Name = "Los angeles" });
                cities.Add(new City { Code = 3, Name = "Houston" });
            }
            else if (country == "UK")
            {
                cities.Add(new City { Code = 1, Name = "Birmingham" });
                cities.Add(new City { Code = 2, Name = "Cambridge" });
                cities.Add(new City { Code = 3, Name = "London" });
            }
            else if (country == "India")
            {
                cities.Add(new City { Code = 1, Name = "Mumbai" });
                cities.Add(new City { Code = 2, Name = "Chennai" });
                cities.Add(new City { Code = 3, Name = "New Delhi" });
            }

            return cities;
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }
        private void UnWireEvents()
        {
            (dataForm.DataObject as DataFormModel).PropertyChanged -= OnDataObjectPropertyChanged;
            this.dataForm.AutoGeneratingDataFormItem -= OnAutoGeneratingDataFormItem;
        }
    }
    public class SourceProviderExt : SourceProvider
    {
        public override IList GetSource(string sourceName)
        {
            var countries = new List<Country>();
            if (sourceName == "Country")
            {
                countries.Add(new Country { Code = 1, Name = "USA" });
                countries.Add(new Country { Code = 2, Name = "UK" });
                countries.Add(new Country { Code = 3, Name = "India" });
            }
            return countries;
        }
    }
}

