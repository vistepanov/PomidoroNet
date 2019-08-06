using System;
using System.Collections.Generic;
using Microsoft.Lync.Model;
using PomidoroInterfaces;

namespace LyncStatus
{
    public class Lync13Status : IMessengerStatus
    {
        private readonly LyncClient _lyncClient;
        private string _statusText;
        private ContactAvailability _statusAvailability;

        public Lync13Status()
        {
            _lyncClient = OpenClient();
        }

        public void SetStatus(MessengerStatus status)
        {
            SetStatus(GetLinqStatus(status));
        }

        private void SetStatus(ContactAvailability status)
        {
            try
            {
                //Add the availability to the contact information items to be published
                var newInformation = new Dictionary<PublishableContactInformationType, object>
                {
                    {PublishableContactInformationType.Availability, status}
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
            try
            {
                var newInformation = new Dictionary<PublishableContactInformationType, object>
                {
                    {PublishableContactInformationType.PersonalNote, msg}
                };
                _lyncClient.Self.BeginPublishContactInformation(newInformation, PublishContactInformationCallback,
                    null);
            }
            catch
            {
                //do nothing
            }
        }

        public void GetInitialStatus()
        {
            _statusText = ReadLinqStatusText();
            _statusAvailability = ReadLinqStatus();
        }

        private ContactAvailability ReadLinqStatus()
        {
            try
            {
                return (ContactAvailability) _lyncClient.Self.Contact.GetContactInformation(ContactInformationType
                    .Availability);
            }
            catch
            {
                return ContactAvailability.Free;
            }
        }

        private string ReadLinqStatusText()
        {
            try
            {
                return _lyncClient.Self.Contact.GetContactInformation(ContactInformationType.PersonalNote) as string;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void RestoreInitialStatus()
        {
            SetText(_statusText);
            SetStatus(_statusAvailability);
        }

        private static ContactAvailability GetLinqStatus(MessengerStatus status)
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
            try
            {
                _lyncClient.Self.EndPublishContactInformation(result);
            }
            catch
            {
                //do nothing
            }
        }
    }
}