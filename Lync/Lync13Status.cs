using System;
using System.Collections.Generic;
using Microsoft.Lync.Model;
using PomidoroNet;

namespace LyncStatus
{
    public class Lync13Status:IMessengerStatus
    {
        private readonly LyncClient _lyncClient;
        public Lync13Status()
        {
            _lyncClient = OpenClient();

        }
        public void SetStatus(MessengerStatus status)
        {
            try
            {
                //Add the availability to the contact information items to be published
                var newInformation = new Dictionary<PublishableContactInformationType, object>
                {
                    {PublishableContactInformationType.Availability, GetLinqStatus(status)}
                };

                //Publish the new availability value
                _lyncClient.Self.BeginPublishContactInformation(newInformation, PublishContactInformationCallback,
                    null);

            }
            catch
            {
                //do nothing
            }
        }

        public void SetText(string msg)
        {
            throw new NotImplementedException();
        }

        private static object GetLinqStatus(MessengerStatus status)
        {
            switch (status)
            {
                case MessengerStatus.Free:
                    return ContactAvailability.Free;
                case MessengerStatus.Busy:
                    return ContactAvailability.Busy;
                case MessengerStatus.DoNotDisturb:
                    return ContactAvailability.DoNotDisturb;
                case MessengerStatus.Away:
                    return ContactAvailability.Away;
                default:
                    return ContactAvailability.Free;
            }
        }

        private LyncClient OpenClient()
        {
            return LyncClient.GetClient();
        }
        private void PublishContactInformationCallback(IAsyncResult result)
        {
            _lyncClient.Self.EndPublishContactInformation(result);
        }

    }
}
