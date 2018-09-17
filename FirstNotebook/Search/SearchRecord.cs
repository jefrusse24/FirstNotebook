using System;

namespace FirstNotebook.Search
{
    public class SearchRecord
    {
        public SearchRecord()
        {
            Page = null;
            InTitle = false;
            Location = 0;
            StringComparison = StringComparison.OrdinalIgnoreCase;
        }

        public Page Page { get; set; }

        public string Token { get; set; }

        public int Location { get; set; }

        public bool InTitle { get; set; }

        public StringComparison StringComparison { get; set; }

        public void Clear()
        {
            Page = null;
            Location = 0;
        }

        public bool IsClear()
        {
            if (Page == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
