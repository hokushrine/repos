namespace Phone
{
    class Nokia : Phone, IRingable
    {
        public Nokia(string versionNumber, string carrier, string ringTone, int batteryPercentage)
            : base(versionNumber, carrier, ringTone, batteryPercentage) { }


        private bool isUnlocked;

        // Methods
        public string Ring()
        {
           return RingtoneProp;
        }

        public string Unlock() 
        {
            return "Unlocked with passcode";
        }

        public override void DisplayInfo()
        {
            System.Console.WriteLine("################################################################");
            System.Console.WriteLine($"Version number: {VersionNumberProp}");
            System.Console.WriteLine($"Carrier: \t{CarrierProp}");
            System.Console.WriteLine($"Ringtone: \t{RingtoneProp}");
            System.Console.WriteLine($"Remaining battery: \t{BatteryPercentageProp}");
            System.Console.WriteLine("################################################################");
        }
    }
}
