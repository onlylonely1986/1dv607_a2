using System;

namespace model
{
    /**
    * Represents the boat-object.
    *    
    */
    public class Boat
    {
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

        public BoatType PickBoatType(int typeNr)
        {
            BoatType t = BoatType.Other;
            if (typeNr == 1)
            {
                t = BoatType.Sailboat;
            } else if (typeNr == 2)
            {
                t = BoatType.Motorsailer;
            } else if (typeNr == 3)
            {
                t = BoatType.KayakorCanoe;
            } else if (typeNr == 4)
            {
                t = BoatType.Other;
            }
            return t;
        }

        public Boat(int lengthInFeet)
        {
            _lengthInFeet = lengthInFeet;
        }
    }
}
