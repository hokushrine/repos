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

        // Getters and setters
        public string VersionNumberProp { get; set; }
        public string CarrierProp { get; set; }
        public string RingtoneProp { get; set; }
        public int BatteryPercentageProp { get; set; }

        public abstract void DisplayInfo();
    }
}
