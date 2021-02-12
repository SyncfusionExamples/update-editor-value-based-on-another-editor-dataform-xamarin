using System;
using System.Collections.Generic;
using System.Text;

namespace DataformXamarin
{
    public class DataFormViewModel
    {
        private DataFormModel dataformmodel;
        public DataFormModel Dataformmodel
        {
            get { return dataformmodel; }
            set { dataformmodel = value; }
        }

        public DataFormViewModel()
        {
            dataformmodel = new DataFormModel();
        }
    }
}
