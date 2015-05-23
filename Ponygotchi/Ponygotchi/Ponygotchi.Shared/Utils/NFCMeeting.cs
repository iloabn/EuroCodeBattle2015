using System;
using System.Collections.Generic;
using System.Text;
using Windows.Networking.Proximity;

namespace Ponygotchi.Utils
{
    public class NFCMeeting
    {
        static ProximityDevice device;

        public static void GetReadyToMeetPony()
        {
            device = ProximityDevice.GetDefault();
            if(device != null)
            {
                device.DeviceArrived += Device_DeviceArrived;
            }
        }

        private static void Device_DeviceArrived(ProximityDevice sender)
        {

        }
    }
}
