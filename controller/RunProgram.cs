using System;
using System.Collections.Generic;
using System.Linq;

namespace controller 
{
    public class Controller
    {
        
        private view.BoatView _bView;
        private view.ConsoleView _cView;
        private view.Event _e;
        IEnumerable<model.Member> _enumMembers;     
        private model.MemberRegister _memberRegister;
        private view.MemberView _mView;
        private model.Member _pickedMember;
        private int _pickedMemberId;
        private model.Boat _pickedBoat;
        private int _pickedBoatId;
        private model.TextFileSave _savedData;


        public Controller()
        {
            _savedData = new model.TextFileSave();
            _memberRegister = new model.MemberRegister(_savedData);
            _cView = new view.ConsoleView();
            _mView = new view.MemberView();
            _bView = new view.BoatView();
        }
    
        public bool RunProgram()
        {
            _cView.ShowMenu();
            _e = _cView.GetEvent();
            if (_e == view.Event.Quit)
            {
                return false;
            }
            if (_e == view.Event.NewMember)
            {
                EventNewMember();
            }
            if (_e == view.Event.SearchMemberName)
            {
                EventSearchMemberName();
            }
            if (_e == view.Event.SearchMemberId)
            {
                EventSearchMemberId();
            }
            if (_e == view.Event.CompactList)
            {
                _mView.PrintCompactList(_memberRegister.GetMembersAsEnums(_savedData));
            }
            if (_e == view.Event.VerboseList)
            {
                _mView.PrintVerboseList(_memberRegister.GetMembersAsEnums(_savedData), _bView);
            }
            return true;
        }

        private void SetPickedMember(string searchNr)
        { 
            int id = Int32.Parse(searchNr);
            _enumMembers = _memberRegister.GetMembersAsEnums(_savedData);
            foreach (var mem in _enumMembers.Where(mem => mem.MemberId == id).Select(mem => mem))
            {
                _pickedMember = mem;
                _pickedMemberId = mem.MemberId;
            }
        }

        private void SetPickedBoat(int pickedBoat)
        {
            pickedBoat--;
            for (int i = 0; i < _pickedMember.Boats.Count; i++)
            {
                if(i == pickedBoat)
                {
                    _pickedBoat = _pickedMember.Boats[i];
                    _pickedBoatId = i;
                }
            }
        }

        private void EventNewMember()
        {
            string fName = _mView.AskForMemberDetailName(Action.New);
            string lName = _mView.AskForMemberDetailLastName();
            long persNum = _mView.AskForMemberDetailNum();
            _memberRegister.SaveNewMember(fName, lName, persNum);
            _enumMembers = _memberRegister.GetMembersAsEnums(_savedData);
        }

        private void EventSearchMemberName()
        {
            view.Event e2 = _mView.ShowSearchMenu(Action.Name);
            if (e2 == view.Event.SearchWordGiven)
            {
                string word = _mView.AskForSearchWord(Action.Name);
                _enumMembers = _memberRegister.GetMembersAsEnums(_savedData);
                _mView.SearchMemberByName(_enumMembers, word);
            }
        }

        private void EventSearchMemberId()
        {
            view.Event e = _mView.ShowSearchMenu(Action.Id);
            if (e == view.Event.SearchWordGiven)
            {
                string id = _mView.AskForSearchWord(Action.Id);
                SetPickedMember(id);
                if (_mView.SearchById(_pickedMember, id, _bView))
                {
                    view.Event e3 = _mView.ShowMemberActivities();
                    if(e3 == view.Event.ChangeMember)
                    {
                        EventChangeMember();
                    }

                    if(e3 == view.Event.RemoveMember)
                    {
                        EventRemoveMember(id);
                    }

                    if(e3 == view.Event.AddBoat)
                    {
                        EventAddBoat();
                    }

                    if(e3 == view.Event.ChangeBoat)
                    {
                        EventChangeBoat();
                    }

                    if(e3 == view.Event.RemoveBoat)
                    {
                        EventRemoveBoat();
                    }
                    _pickedMember = null;
                    _pickedMemberId = 1000;
                }
            }  
        }

        private void EventChangeMember()
        {
            string fName = _mView.AskForMemberDetailName(Action.Change);
            string lName = _mView.AskForMemberDetailLastName();
            long persNum = _mView.AskForMemberDetailNum();
            _memberRegister.ChangeMember(_pickedMemberId, fName, lName, persNum);
            _enumMembers = _memberRegister.GetMembersAsEnums(_savedData);
        }
        
        private void EventRemoveMember(string id)
        {
            if(_cView.AskForOkey(Action.Member))
            {
                _memberRegister.RemoveMember(_pickedMember, id);
                _enumMembers = _memberRegister.GetMembersAsEnums(_savedData);
            }
        }

        private void EventAddBoat()
        {
            string t = _bView.GetBoatTypesListed();  
            int pickedType = _bView.AskForBoatType(t);
            int length = _bView.AskForBoatLength();
            _memberRegister.RegistryBoat(_pickedMemberId, pickedType, length);
            _enumMembers = _memberRegister.GetMembersAsEnums(_savedData);
        }
 
        private void EventChangeBoat()
        {
            _bView.AskForBoatToPickText(Action.Change);
            _bView.PrintBoatInfo(_pickedMember);
            int pickBoat = _bView.PickBoatToHandle(_pickedMember);
            if (pickBoat != 0)
            {
                SetPickedBoat(pickBoat);
                string t = _bView.GetBoatTypesListed();
                int pickedType = _bView.AskForBoatType(t);
                int length = _bView.AskForBoatLength();
                _memberRegister.ChangeBoat(_pickedMemberId, _pickedBoatId, pickedType, length);
                _enumMembers = _memberRegister.GetMembersAsEnums(_savedData);
            }
        }

        private void EventRemoveBoat()
        {
            _bView.AskForBoatToPickText(Action.Remove);
            _bView.PrintBoatInfo(_pickedMember);
            int pickBoat = _bView.PickBoatToHandle(_pickedMember);
            if (pickBoat != 0)
            {
                SetPickedBoat(pickBoat);
                if(_cView.AskForOkey(Action.Boat))
                {
                    _memberRegister.RemoveBoat(_pickedMemberId, _pickedBoatId);
                    _enumMembers = _memberRegister.GetMembersAsEnums(_savedData);
                }
            }
        }  
    }    
}
