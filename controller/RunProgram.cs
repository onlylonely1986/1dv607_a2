using System.Collections.Generic;

namespace controller 
{
    public class Controller
    {
        public bool RunProgram()
        {
            model.MemberRegister m = new model.MemberRegister();
            view.ConsoleView v = new view.ConsoleView();
            view.Event e;

            v.ShowMenu();
            e = v.GetEvent();
            if (e == view.Event.Quit)
            {
                return false;
            }
            if (e == view.Event.NewMember)
            {
            string action = "new";
            string fName = v.AskForMemberDetailName(action);
            string lName = v.AskForMemberDetailLastName();
            string persNum = v.AskForMemberDetailNum();
            m.RegistryMember(fName, lName, persNum);
            }
            if (e == view.Event.SearchMemberName)
            {
                // TODO egen metod för dessa alternativ
                string word;
                string focusName = "name";
                view.Event e2 = v.ShowSearchMenu(focusName);
                if (e2 == view.Event.SearchWordGiven)
                {
                    word = v.AskForSearchWord(focusName);
                    string result = m.SearchByName(word);
                    v.ShowMessage(result);
                }
                if (e2 == view.Event.GoBack)
                {
                    // return false;
                }
            }
            if (e == view.Event.SearchMemberId)
            {
                string id;
                string focusId = "id";
                string thing = "member";
                view.Event e2 = v.ShowSearchMenu(focusId);
                if (e2 == view.Event.SearchWordGiven)
                {
                    id = v.AskForSearchWord(focusId);
                    string result = m.SearchById(id);
                    v.ShowMessage(result);
                    view.Event e3 = v.ShowMemberActivities();
                    if(e3 == view.Event.ChangeMember)
                    {
                        string action = "change";
                        string fName = v.AskForMemberDetailName(action);
                        string lName = v.AskForMemberDetailLastName();
                        string persNum = v.AskForMemberDetailNum();
                        m.ChangeMember(fName, lName, persNum);
                    }

                    if(e3 == view.Event.RemoveMember)
                    {
                        bool ok = v.AskForOkey(thing);
                        if(ok == false)
                        {
                            // return false; 
                        } else
                        {
                            m.RemoveMember(id);
                        }
                    }

                    if(e3 == view.Event.AddBoat)
                    {
                        string t = m.GetBoatTypesListed();  
                        string pickedType = v.AskForBoatType(t);
                        string length = v.AskForBoatLength();
                        string respons = m.RegistryBoat(pickedType, length);
                        v.ShowMessage(respons);
                    }

                    if(e3 == view.Event.ChangeBoat)
                    {
                        string handle = "change";
                        v.AskForBoatToPickText(handle);
                        string boats = m.GetBoatInfo();
                        if (boats == "Sorry you have not added any boats to this member yet.")
                        {
                            v.ShowMessage(boats);
                        }
                        else
                        {
                            string pickBoat = v.ShowBoatInfo(boats);
                            m.SetPickedBoat(pickBoat);
                            string t = m.GetBoatTypesListed();  
                            string pickedType = v.AskForBoatType(t);
                            string length = v.AskForBoatLength();
                            string respons = m.ChangeBoat(pickedType, length);
                            v.ShowMessage(respons);
                        }
                    }

                    if(e3 == view.Event.RemoveBoat)
                    {
                        string handle = "remove";
                        v.AskForBoatToPickText(handle);
                        string boats = m.GetBoatInfo();
                        if (boats == "Sorry you have not added any boats to this member yet.")
                        {
                            v.ShowMessage(boats);
                        }
                        else
                        {
                            string pickBoat = v.ShowBoatInfo(boats);
                            m.SetPickedBoat(pickBoat);
                            thing = "boat";
                            bool ok = v.AskForOkey(thing);
                            if(ok == false)
                            {
                                // return false; 
                            } else
                            {
                                string respons =  m.RemoveBoat();
                                v.ShowMessage(respons);
                            }
                        }
                    }
                }  
            }
            if (e == view.Event.CompactList)
            {
                string all = m.PrintAllMembersCompact();
                v.ShowMessage(all);
            }
            if (e == view.Event.VerboseList)
            {
                string all = m.PrintAllMembersVerbose();
                v.ShowMessage(all);
            }
            return true;
        }            
    }    
}
