using System.Collections.Generic;

namespace controller 
{

    public class RunProgram
    {
        public bool runProgram()
        {
            model.MemberRegister m = new model.MemberRegister();
            view.ConsoleView v = new view.ConsoleView();
            view.ConsoleView.Event e;
            
            v.showConsole();
            e = v.GetEvent();             
            if (e == view.ConsoleView.Event.Quit)
            {
                return false;
            }
            if (e == view.ConsoleView.Event.NewMember)
            {
                string action = "new";
                string fName = v.AskForMemberDetailName(action);
                string lName = v.AskForMemberDetailLastName();
                string persNum = v.AskForMemberDetailNum();
                m.RegistryMember(fName, lName, persNum);
            }
            if (e == view.ConsoleView.Event.SearchMemberName)
            {
                // TODO egen metod för dessa alternativ
                string word;
                string focusName = "name";
                view.ConsoleView.Event e2 = v.ShowSearchMenu(focusName);
                if (e2 == view.ConsoleView.Event.SearchWordGiven)
                {
                    word = v.AskForSearchWord(focusName);
                    m.SearchByName(word);
                }
                if (e2 == view.ConsoleView.Event.GoBack)
                {
                    return false;
                }
            }
            if (e == view.ConsoleView.Event.SearchMemberId)
            {
                // TODO egen metod för dessa alternativ
                string id;
                string focusId = "id";
                string thing = "member";
                view.ConsoleView.Event e2 = v.ShowSearchMenu(focusId);
                if (e2 == view.ConsoleView.Event.SearchWordGiven)
                {
                    id = v.AskForSearchWord(focusId);
                    m.SearchById(id);
                    view.ConsoleView.Event e3 = v.ShowMemberActivities();
                    if(e3 == view.ConsoleView.Event.ChangeMember)
                    {
                        string action = "change";
                        string fName = v.AskForMemberDetailName(action);
                        string lName = v.AskForMemberDetailLastName();
                        string persNum = v.AskForMemberDetailNum();
                        m.ChangeMember(fName, lName, persNum);
                    }

                    if(e3 == view.ConsoleView.Event.RemoveMember)
                    {
                        bool ok = v.AskForOkey(thing);
                        if(ok == false)
                        {
                            return false; 
                        } else
                        {
                            m.RemoveMember(id);
                        }
                    }

                    if(e3 == view.ConsoleView.Event.AddBoat)
                    {
                        string type = v.AskForBoatType();
                        string length = v.AskForBoatLength();
                        string respons = m.RegistryBoat(type, length);
                        System.Console.WriteLine(respons);
                    }

                    if(e3 == view.ConsoleView.Event.ChangeBoat)
                    {
                        string handle = "change";
                        v.AskForBoatToPickText(handle);
                        string boats = m.GetBoatInfo();
                        if (boats == "Sorry you have not added any boats to this member yet.")
                        {
                            System.Console.WriteLine(boats);
                            return false;
                        } else
                        {
                            string pickBoat = v.ShowBoatInfo(boats);
                            m.SetPickedBoat(pickBoat);
                            string type = v.AskForBoatType();
                            string length = v.AskForBoatLength();
                            string respons = m.ChangeBoat(type, length);
                            System.Console.WriteLine(respons);
                        }
                    }

                    if(e3 == view.ConsoleView.Event.RemoveBoat)
                    {
                        string handle = "remove";
                        v.AskForBoatToPickText(handle);
                        string boats = m.GetBoatInfo();
                        if (boats == "Sorry you have not added any boats to this member yet.")
                        {
                            System.Console.WriteLine(boats);
                            return false;
                        } else
                        {
                            string pickBoat = v.ShowBoatInfo(boats);
                            m.SetPickedBoat(pickBoat);
                            thing = "boat";
                            bool ok = v.AskForOkey(thing);
                            if(ok == false)
                            {
                                return false; 
                            } else
                            {
                                string respons =  m.RemoveBoat();
                                System.Console.WriteLine(respons);
                                return true;
                            }
                        }
                    }
                }
                if (e2 == view.ConsoleView.Event.GoBack)
                {
                    return false;
                }   
            }
            if (e == view.ConsoleView.Event.CompactList)
            {
                m.PrintAllMembersCompact();
            }
            if (e == view.ConsoleView.Event.VerboseList)
            {
                m.PrintAllMembersVerbose();
            }
            return true;
        }
    }    
}

