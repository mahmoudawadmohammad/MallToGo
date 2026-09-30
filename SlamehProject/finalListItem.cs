using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlamehProject
{
    class finalListItem
    {
        #region proplist
        private string name;
        private string category;
        private double prise;
        private int amont;
        private int id;
        private string img;
        public string Name
        {
            get { return name; }
            set { name = value;  }
        }
        public string Img
        {
            get { return img; }
            set { img = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public double Prise
        {
            get { return prise; }
            set { prise = value; }
        }
        public int Amont
        {
            get { return amont; }
            set { amont = value;  }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}
