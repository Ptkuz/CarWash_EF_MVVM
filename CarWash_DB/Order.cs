using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CarWash_DB
{
    public class Order : INotifyPropertyChanged
    {
        [Key]
        public Guid IdOrder { get; set; }
        public Guid IdCar { get; set; }
        public Car? Car { get; set; }
        public Guid IdClient { get; set; }
        public Client? Client { get; set; }
        public DateTime Dateorder { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdBox { get; set; }
        public Box? Box { get; set; }
        private int price;
        public int Price 
        { 
            get { return price; } 
            set 
            {
                price = value; 
                OnPropertyChanged("Price");
            } 
        }
        public int IdStatus { get; set; }
        public Status? Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
