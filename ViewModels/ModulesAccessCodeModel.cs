using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace smpc_admin.ViewModels
{
   public class ModulesAccessCodeModel : INotifyPropertyChanged
    {
        private List<string> _codes = new List<string>();

        public List<string> Codes
        {
            get => _codes;
            set
            {
                _codes = value;
                OnPropertyChanged(nameof(Codes));
                OnPropertyChanged(nameof(CodesString));
            }
        }




        public void AddCode(string code)
        {
            if (!_codes.Contains(code))
            {
                _codes.Add(code);
                OnPropertyChanged(nameof(Codes));
                OnPropertyChanged(nameof(CodesString));
            }
        }

        public void RemoveCode(string code)
        {
            if (_codes.Contains(code))
            {
                _codes.Remove(code);
                OnPropertyChanged(nameof(Codes));
                OnPropertyChanged(nameof(CodesString));
            }
        }


        public string CodesString => string.Join(", ", _codes);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
