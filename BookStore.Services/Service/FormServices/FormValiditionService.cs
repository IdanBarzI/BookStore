using BookStore.Services.Service.FormServices.IFormServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service.FormServices
{
    public abstract class FormValiditionService : BaseProductDataService , IFormValiditionService
    {

        public string Error { get { return null; } }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        private bool isValidForm;
        public bool IsValidForm
        {
            get { return isValidForm; }
            set
            {
                if (isValidForm != value)
                {
                    isValidForm = value;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string value = null;

        public string this[string fieldName]
        {
            get
            {
                string result = null;

                switch (fieldName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            result = "Name Can Not Be Empty";
                            break;
                        }

                        if (Name.Length < 2)
                            result = "Name Can Not Be Less The 2 Characters";

                        break;

                    case nameof(Price):
                    case nameof(Quantity):
                    case nameof(Isbn):

                        Type t = typeof(BaseProductDataService);
                        var property = t.GetProperty(fieldName);
                        string displayName = property.Name;
                        var propertyValue = property.GetValue(this, null);

                        if (propertyValue != null)
                        { value = propertyValue.ToString(); }

                        if (string.IsNullOrWhiteSpace(value))
                        {
                            result = $"{displayName} Can Not Be Empty";
                            break;
                        }
                        else if (value.Length >= 1)
                        {
                            foreach (char number in value)
                            {
                                if (number < '0' || number > '9')
                                {
                                    result = $"{displayName} Can Not Have Letters";
                                    break;
                                }
                            }
                        }

                        break;
                }


                if (ErrorCollection.ContainsKey(fieldName))
                    ErrorCollection[fieldName] = result;
                else if (result != null)
                    ErrorCollection.Add(fieldName, result);

                FormValiditionCheck();

                RaisePropertyChanged(nameof(ErrorCollection));

                return result;
            }
        }

        public void FormValiditionCheck()
        {
            if (ErrorCollection.All(v => v.Value == null))
            {
                IsValidForm = true;
                RaisePropertyChanged(nameof(IsValidForm));
            }
            else
            {
                IsValidForm = false;
                RaisePropertyChanged(nameof(IsValidForm));
            }
        }

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
