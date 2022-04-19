using System.ComponentModel.DataAnnotations;
using System.Windows;


namespace CarWash_DB
{
    public class Service
    {
        [Key]
        public Guid IdService { get; set; }
        public string NameService { get; set; }
        public int PriceService { get; set; }
       // public bool Choise { get; set; }



        private bool _isSelected;
        public bool Choise
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                
            }
        }

        public void SetProperty(ref bool myProperty)
        {
            Choise = myProperty;
        }

    }
}
