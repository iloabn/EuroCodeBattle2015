using System;
using System.Collections.Generic;
using System.Text;
using Windows.Networking.Proximity;

namespace Ponygotchi.Utils
{
    public class NFCMeeting
    {
        static ProximityDevice device;

        public delegate void MetPonyHandler();
        public static event MetPonyHandler OnPonyMet;

        public static void GetReadyToMeetPony()
        {
            try
            { 
            device = ProximityDevice.GetDefault();
            if(device != null)
            {
                device.DeviceArrived += Device_DeviceArrived;
            }
            }catch(Exception)
            {

            }
        }

        private static void Device_DeviceArrived(ProximityDevice sender)
        {
            if (OnPonyMet == null) return;

            OnPonyMet();
        }
    }
}
