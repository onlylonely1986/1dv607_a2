
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace model
{
    /**
     * Represents the class handeling writing and reading from the textfile.
     */
    class TextFileSave
    {
        public List<Member> ReadAllMembersFromFile()
        {   
            string jsonFromFile;
            using (StreamReader sr = new StreamReader("register.txt")) 
            {
                jsonFromFile = sr.ReadToEnd();
                List<Member> members = new List<Member>();
                members = JsonConvert.DeserializeObject<List<Member>>(jsonFromFile);
                return members;
            }
        }

        public void WriteToFile(List<Member> members)
        {
            string jsonData = JsonConvert.SerializeObject(members);
            using (StreamWriter sw = new StreamWriter("register.txt"))
            {
                sw.WriteLine(jsonData);
            }
        }
    }
}
