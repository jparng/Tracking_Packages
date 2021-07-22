using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Packages
    {
        private string address, city, state, time;
        private int zipCode, packageId;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public int PackageID
        {
            get { return packageId; }
            set { packageId = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

    }
}
