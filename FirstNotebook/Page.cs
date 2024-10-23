using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.Serialization;

namespace FirstNotebook
{
    [Serializable]
    public class Page : ISerializable
    {
        // If the file format changes, then you need a new version.
        private static int pageVersion = 1;

        private List<string> _pageTags = new List<string>();
        private string _pageTitle;
        private string _pageData;

        public Page(int pageNumber)
        {
            PageNumber = pageNumber;
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            DerivedTitle = string.Empty;
            _pageTitle = string.Empty;
            _pageData = string.Empty;
            UUID = Guid.NewGuid().ToString();

            Version = pageVersion;
        }

        public Page(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            Version = (int)info.GetValue("Version", typeof(int));
            PageNumber = (int)info.GetValue("Number", typeof(int));
            _pageTitle = (string)info.GetValue("Title", typeof(string));
            DerivedTitle = (string)info.GetValue("DerivedTitle", typeof(string));
            CreatedDate = (DateTime)info.GetValue("CreatedDate", typeof(DateTime));
            ModifiedDate = (DateTime)info.GetValue("ModifiedDate", typeof(DateTime));
            _pageTags = (List<string>)info.GetValue("Tags", typeof(List<string>));
            _pageData = (string)info.GetValue("Data", typeof(string));
            BackgroundColor = (Color)info.GetValue("BGColor", typeof(Color));
            UUID = (string)info.GetValue("UUID", typeof(string));
            LockEncryptionFlags = (string)info.GetValue("LEFlags", typeof(string));
            PasskeyHash = (string)info.GetValue("PasskeyHash", typeof(string));
            if (string.IsNullOrEmpty(UUID))
            {
                UUID = Guid.NewGuid().ToString();
            }
        }

        public int Version { get; set; }

        public int PageNumber { get; set; }

        public string PageTitle
        {
            get
            {
                return _pageTitle;
            }

            set
            {
                _pageTitle = value;
                UpdateModifiedTime();
            }
        }

        public string DerivedTitle { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Color BackgroundColor { get; set; }

        public string UUID { get; set; }

        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "This is really flags.")]
        public string LockEncryptionFlags { get; set; }

        public string PasskeyHash { get; set; }

        public string PageData
        {
            get
            {
                return _pageData;
            }

            set
            {
                _pageData = value;
                UpdateModifiedTime();
            }
        }

        public ICollection<string> GetPageTags()
        {
            return _pageTags;
        }

        public void AddPageTag(string tag)
        {
            if ((!string.IsNullOrEmpty(tag)) && (!_pageTags.Contains(tag)))
            {
                _pageTags.Add(tag);
                UpdateModifiedTime();
            }
        }

        public void RemovePageTag(string tag)
        {
            if (_pageTags.Remove(tag))
            {
                UpdateModifiedTime();
            }
        }

        public string GetPageTitle()
        {
            if (string.IsNullOrEmpty(PageTitle))
            {
                return DerivedTitle;
            }
            else
            {
                return PageTitle;
            }
        }

        public void AddPageBreak()
        {
            _pageData += "-------------- BREAK ------------------";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            info.AddValue("Version", Version);
            info.AddValue("Number", PageNumber);
            info.AddValue("Title", _pageTitle);
            info.AddValue("DerivedTitle", DerivedTitle);
            info.AddValue("CreatedDate", CreatedDate);
            info.AddValue("ModifiedDate", ModifiedDate);
            info.AddValue("Tags", _pageTags);
            info.AddValue("Data", _pageData);
            info.AddValue("BGColor", BackgroundColor);
            info.AddValue("UUID", UUID);
            info.AddValue("LEFlags", LockEncryptionFlags);
            info.AddValue("PasskeyHash", PasskeyHash);
        }

        internal bool ContainsMatching(string token, StringComparison comparison)
        {
            if (_pageTitle.IndexOf(token, comparison) != -1)
            {
                return true;
            }

            // Look in the context.  But this is RTF, so convert it to text so you can search it.
            var noteAreaTextBox = new System.Windows.Forms.RichTextBox
            {
                Rtf = _pageData
            };
            if (noteAreaTextBox.Text.IndexOf(token, comparison) != -1)
            {
                noteAreaTextBox.Dispose();
                return true;
            }

            noteAreaTextBox.Dispose();
            return false;
        }

        private void UpdateModifiedTime()
        {
            ModifiedDate = DateTime.Now;
        }
    }
}