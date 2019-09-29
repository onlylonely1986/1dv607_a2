
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
                _lengthInFeet = value;
            }
        }
        public Boat(BoatType boatType, int lengthInFeet)
        {
            _boatType = boatType;
            _lengthInFeet = lengthInFeet;
        }

        public override string ToString()
        {
            return $"[ Boattype: {_boatType}, Length: {_lengthInFeet} feet. ]";
        }
    }
}
