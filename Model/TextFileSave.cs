
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace model
{
    /**
     * Represents the class handeling writing and reading from the textfile.
     */
    public class TextFileSave
    {
        private string _fileName = "register.txt";
        public List<Member> ReadDataFromFile()
        {
            string jsonFromFile;
            using (StreamReader sr = new StreamReader(_fileName)) 
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
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                 sw.WriteLine(jsonData);
            }
        }
    }
}
