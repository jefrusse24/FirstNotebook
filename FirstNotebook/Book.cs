using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FirstNotebook
{
    [Serializable]
    public class Book : ISerializable
    {
        private List<Page> _pages;
        private List<string> _pageTags;

        public Book()
        {
            _pages = new List<Page>();
            FileName = "Untitled";
            Version = 1;
            Dirty = false;
            _pageTags = null;
        }

        public Book(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            FileName = (string)info.GetValue("FileName", typeof(string));
            Version = (int)info.GetValue("Version", typeof(int));
            _pages = (List<Page>)info.GetValue("Pages", typeof(List<Page>));
        }

        public string FileName { get; set; }

        public int Version { get; set; }

        // Flag if there have been any modifications to the book since last save.
        public bool Dirty { get; set; } = false;

        public List<string> PageTags
        {
            get
            {
                if (_pageTags == null)
                {
                    _pageTags = GetPageTagsInBook();
                }

                return _pageTags;
            }
        }

        public List<string> GetPageTagsInBook()
        {
            var tags = new List<string>();

            foreach (Page page in _pages)
            {
                tags.AddRange(page.GetPageTags());
            }

            return tags;
        }

        public int PageCount
        {
            get
            {
                return _pages.Count;
            }
        }

        public Page GetNewPage()
        {
            if (_pages.Count != 0)
            {
                Dirty = true;
            }

            Page page = new Page(_pages.Count + 1);
            _pages.Add(page);
            return page;
        }

        /// <summary>
        /// Gets a Page from the book.  A book does not necessarily have sequential page numbers (like when a book is a sub-book
        /// caused by a search).
        /// </summary>
        /// <param name="pageNumber">integer 0 reference</param>
        /// <returns>0 index page of the book</returns>
        public Page GetPage(int pageNumber)
        {
            if ((pageNumber < 0) || (pageNumber >= _pages.Count))
            {
                return null;
            }

            return _pages[pageNumber];
        }

        public Page GetLastPage()
        {
            return _pages[_pages.Count - 1];
        }

        public ICollection<Page> GetPages()
        {
            return _pages;
        }

        public void AddPage(Page page)
        {
            _pages.Add(page);
        }

        public void InsertPage(Page newPage)
        {
            if (newPage == null)
            {
                return;
            }

            bool added = false;
            for (int i = 0; i < _pages.Count; i++)
            {
                Page page = _pages[i];
                if (newPage.CreatedDate >= page.CreatedDate)
                {
                    _pages.Insert(i, newPage);
                    added = true;

                    // Renumber the remaining pages
                    for (int j = i; j < _pages.Count; j++)
                    {
                        _pages[j].PageNumber = j + 1;
                    }

                    break;
                }
            }

            if (!added)
            {
                newPage.PageNumber = _pages.Count + 1;
                _pages.Add(newPage);
            }
        }

        // Delete then renumber
        public void DeletePage(Page page)
        {
            _pages.Remove(page);
        }

        public Book FindMatching(string token, StringComparison comparison)
        {
            Book matchingPages = new Book();
            foreach (Page page in _pages)
            {
                if (page.ContainsMatching(token, comparison))
                {
                    matchingPages.AddPage(page);
                }
            }

            return matchingPages;
        }

        //public Book FindPageTags(ICollection<string> tags, bool includeEmpty)
        //{
        //    throw new NotImplementedException();
        //}

        //public Page GetPageByUUID(string uuid)
        //{
        //    return _pages.Find(p => p.UUID == uuid);
        //}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            info.AddValue("FileName", FileName);
            info.AddValue("Version", Version);
            info.AddValue("Pages", _pages);
        }
    }
}
