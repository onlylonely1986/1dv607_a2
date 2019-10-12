using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class Member
    {
        private string _firstName;

        private string _lastName;

        private string _persNum;
        private int _memberId;

        private List<Boat> _boats = new List<Boat>();

        public List<Boat> Boats
        {
            get { return _boats;}
        }
        public string FirstName
        {
            get { return _firstName;}
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException();
                } else 
                {
                    _firstName = value;
                }   
            }
        }

        public string LastName
        {
            get { return _lastName;}
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException();
                } else 
                {
                    _lastName = value;
                }
            }
        }

        public int MemberId
        {
            get { return _memberId;}
            set
            {
                _memberId = value;
            }
        }

        
        // TODO: wrong type on this
        public string PersNum
        {
            get { return _persNum;}
            set
            {
                // if (value.Length != 11)
                // {
                //     throw new ArgumentOutOfRangeException();
                // }
                _persNum = value;
            }
        }

        public void AddBoat(string t, int l)
        {
            Boat b = new Boat(l);
            BoatType type = b.PickBoatType(t);
            b.Type = type;
            if (_boats.Count < 100)
            {
                _boats.Add(b);
            } else
            {
                throw new ArgumentOutOfRangeException("You have to many boots in your harbor.");
            }
        }

        public void ChangeBoat(Boat b, string t, int l)
        {
            BoatType type = b.PickBoatType(t);
            b.Type = type;
            b.LengthInFeet = l;
        }

        public void RemoveBoat(int boatId)
        {
            _boats.RemoveAt(boatId); 
        }

        public string GetBoatInfo()
        {
            int ind = 1;
            string boats = String.Concat(_boats.Select(b=> $"[{ind++}]: {b.ToString()}\n"));
            return boats;
        }

        public Member(string firstName, string lastName, string personalNum) 
        {
            _firstName = firstName;
            _lastName = lastName;
            _persNum =  personalNum;
        }
    }
}
