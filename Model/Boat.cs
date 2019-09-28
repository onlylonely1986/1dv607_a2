using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace model
{
    /**
    * Represents the boat-object.
    *    
     */
    class Boat
    {
        public enum BoatType {
			Sailboat,
			Motorsailer,
			KayakorCanoe,
			Other
		}

        private int _boatId;

        private BoatType _boatType;

        private int _lengthInFeet;

        private int _berthId;

        public Boat()
        {

        }
    }
}
