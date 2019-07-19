namespace Phone
{
    class Nokia : Phone
    {
        public Nokia(string versionNumber, string carrier, string ringTone, int batteryPercentage)
            : base(versionNumber, carrier, ringTone, batteryPercentage) { }


        // Methods
        //public string Ring()
        //{
        //    System.Console.WriteLine(Phone.ringTone);
        //}

        //public string Unlock()
        //{}

        public override void DisplayInfo()
        {
            System.Console.WriteLine("################################################################");
            System.Console.WriteLine(VersionNumberProp);
            System.Console.WriteLine(CarrierProp);
            System.Console.WriteLine(RingtoneProp);
            System.Console.WriteLine(BatteryPercentageProp);
            System.Console.WriteLine("################################################################");
        }
    }
}
