using System;

namespace model
{
    class Person
    {
        private string _firstName;

        private string _lastName;

        private string _persNum;

        // TODO: är det här korrekt inkapslat?
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
    
       public Person(string firstName, string lastName, string persNum)
        {
            _firstName = firstName;
            _lastName = lastName;
            _persNum =  persNum;
        }
    }
}
