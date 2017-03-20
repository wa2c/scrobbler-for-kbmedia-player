using NDde.Client;
using ScrobblerForKbMediaPlayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;



namespace ScrobblerForKbMediaPlayer
{
    class KbMediaPlayerManager : IDisposable
    {
        private const string ServiceName = "KbMedia Player";
        private const string TopicName = "KbMedia Player";
        private readonly Encoding DdeEncoding = Encoding.Unicode;

        private readonly HashSet<KbMediaProperty> minPropertySet = new HashSet<KbMediaProperty>()
        {
            KbMediaProperty.Title,
            KbMediaProperty.Artist,
            KbMediaProperty.Album,
            KbMediaProperty.AlbumArtist,
            KbMediaProperty.Length,
            KbMediaProperty.Status
        };


        private DdeClient client;

        public KbMediaPlayerManager()
        {
            client = new DdeClient(ServiceName, TopicName);
        }

        public void Connect()
        {
            if (!client.IsConnected)
                client.Connect();
        }

        public void Disconnect()
        {
            if (client.IsConnected)
                client.Disconnect();
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public Dictionary<KbMediaProperty, string> GetCurrentPropertyMap(bool isFull = false)
        {
            Dictionary<KbMediaProperty, string> valueMap = new Dictionary<KbMediaProperty, string>();

            byte[] data;
            foreach (KbMediaProperty type in Enum.GetValues(typeof(KbMediaProperty)))
            {
                if (!isFull && !minPropertySet.Contains(type))
                    continue;

                int result = client.TryRequest(type.GetDdeCommand(), 4, 100, out data); // ANSI(Shift_JIS) = 1, Unicode = 4?
                if (result != 0)
                    continue;
                string val = DdeEncoding.GetString(data).Trim('\0');
                if (string.IsNullOrEmpty(val))
                    continue;
                valueMap.Add(type, val);
            }

            return valueMap;
        }

    }
}
