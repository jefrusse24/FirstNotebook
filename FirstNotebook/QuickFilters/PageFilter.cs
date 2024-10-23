using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FirstNotebook.QuickFilters
{
    [Serializable]
    public class PageFilter : ISerializable
    {
        public PageFilter(string filtername)
        {
            Version = 1;
            Title = filtername;
            PageUUIDS = new List<string>();
        }

        public PageFilter(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            Version = (int)info.GetValue("Version", typeof(int));
            Title = (string)info.GetValue("Title", typeof(string));
            PageUUIDS = (List<string>)info.GetValue("Pageuuids", typeof(List<string>));
        }

        public int Version { get; set; }

        public string Title { get; set; }

        public List<string> PageUUIDS { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            info.AddValue("Version", Version);
            info.AddValue("Title", Title);
            info.AddValue("Pageuuids", PageUUIDS);
        }

        public bool Contains(string uuid)
        {
            return PageUUIDS.Contains(uuid);
        }
    }
}