
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

        public int BoatId
        {
            get { return _boatId;}
            set
            {
                _boatId = value;
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
