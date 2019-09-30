using System;

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

        private BoatType _boatType;

        private int _lengthInFeet;

        public BoatType Type
        {
            get { return _boatType;}
            set
            {
                _boatType = value;
            }
        }

        public int LengthInFeet
        {
            get { return _lengthInFeet;}
            set
            {
                if(value > 2 && value < 100)
                {
                    _lengthInFeet = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }
        public BoatType PickBoatType(string input)
        {
            int typeNr = Int32.Parse(input);
            Boat.BoatType t = Boat.BoatType.Other;
            if (typeNr == 1)
            {
                t = Boat.BoatType.Sailboat;
            } else if (typeNr == 2)
            {
                t = Boat.BoatType.Motorsailer;
            } else if (typeNr == 3)
            {
                t = Boat.BoatType.KayakorCanoe;
            } else if (typeNr == 4)
            {
                t = Boat.BoatType.Other;
            }
            return t;
        }

        public Boat(int lengthInFeet)
        {
            _lengthInFeet = lengthInFeet;
        }

        public override string ToString()
        {
            return $"[ Boattype: {_boatType}, Length: {_lengthInFeet} feet. ]";
        }
    }
}
