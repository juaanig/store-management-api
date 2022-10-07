using System.Collections;
using System;

namespace store_management_api.Entities
{
    public class Ubicacion
    {
        public string nameLocation { get; set; }
        public int capacity { get; set; }

        public Ubicacion (string nameLocation, int capacity)
        {
            this.nameLocation = nameLocation;
            this.capacity = capacity;
        }

        public List<string> dataLocation()
        {
            List<string> dataLocations = new List<string>()
            {
                this.nameLocation , (this.capacity).ToString() 
            };

            return dataLocations ; 
        }

    }
}
