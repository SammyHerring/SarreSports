//Project Name: SarreSports | File Name: Watch.cs
//Author Name: Samuel Steven David Herring
//Author Email: s.s.herring1042@canterbury.ac.uk
//Author URI: http://sherring.me
//UserID: sh1042
//Created On: 4/1/2019 | 15:12
//Last Updated On:  11/1/2019 | 01:16
namespace SarreSports
{
    public class Watch : Accessory
    {
        //Watch Attributes
        public enum watchType
        {
            Simple = 0, 
            HeartRate = 1, 
            GPS = 2,
            GPSandHeartRate = 3
        }
        private watchType type;

        //Watch Constructor
        public Watch(string name, Type itemType, decimal cost, int stockLevel, int restockLevel, accessoryType accessoryType, watchType type) :
            base(name, itemType, cost, stockLevel, restockLevel, accessoryType)
        {
            this.type = type;
        }

        //Watch Accessor
        public watchType WatchType => type;
    }
}