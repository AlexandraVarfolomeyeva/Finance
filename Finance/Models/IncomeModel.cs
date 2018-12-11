using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Models
{
    public class
        IncomeModel : BaseModel
    {
        private int id;
        public int Id
        {
            get
            { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date { get; set; }

        public double Sum { get; set; }



        //in repository

    }
}
