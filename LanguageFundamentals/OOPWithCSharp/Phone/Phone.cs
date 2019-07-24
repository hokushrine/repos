using System;
using System.Collections.Generic;
using System.Text;

namespace Phone
{
    public abstract class Phone
    {
        private string _versionNumber;
        private string _carrier;
        private string _ringtone;
        private int _batteryPercentage;

        public Phone(string number, string carrier, string ringtone, int batPercentage)
        {
            _versionNumber = number;
            _carrier = carrier;
            _ringtone = ringtone;
            _batteryPercentage = batPercentage;
        }

        // Getters and setters - auto-implement doesn't work?
        public string VersionNumberProp 
        { 
            get{return _versionNumber;}
            set{_versionNumber = value;}
        }
        public string CarrierProp 
        { 
            get{return _carrier;}
            set{_carrier = value;}
        }
        public string RingtoneProp 
        { 
            get{return _ringtone;}
            set{_ringtone = value;}
         }
        public int BatteryPercentageProp 
        {
            get{return _batteryPercentage;}
            set{_batteryPercentage = value;}
        }

        public abstract void DisplayInfo();
    }
}
