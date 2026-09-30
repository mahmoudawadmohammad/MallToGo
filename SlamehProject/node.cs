using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlamehProject
{
    class node
    {
        finalListItem data =new finalListItem();
        node next;
        public finalListItem Data 
        {

            get { return data; }
      
            set {data =value ; } 
        }
        public node Next
        {

            get { return next; }

            set { next = value; }
        }

    }                             
}
