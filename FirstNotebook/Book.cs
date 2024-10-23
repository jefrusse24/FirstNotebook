using FirstNotebook.QuickFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

/*
 * Class: Book
 *
 * Book Version 1:
 *  Filename - String
 *  Version - Int
 *  Pages - List<Page>
 *
 * Book Version 2:
 *  Filename - String
 *  Version - Int
 *  Pages - List<Page>
 *  FilterList - List<List<UUID>>
 *
 *
 */

namespace FirstNotebook
{
    [Serializable]
    public class Book : ISerializable
    {
        // If the file format changes, then you need a new version.
        private static int bookVersion = 2;

        private List<Page> _pages;
        private List<string> _pageTags;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// Default Book constructor.
        /// </summary>
        public Book()
        {
            _pages = new List<Page>();
            FileName = "Untitled";
            Version = bookVersion;
            Dirty = false;
            _pageTags = null;
            FilterList = new List<PageFilter>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// Deseralize the info stream into a book object.
        /// </summary>
        /// <param name="info">serilization info</param>
        /// <param name="context">streaming context</param>
        public Book(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            FileName = (string)info.GetValue("FileName", typeof(string));
            Version = (int)info.GetValue("Version", typeof(int));
            _pages = (List<Page>)info.GetValue("Pages", typeof(List<Page>));

            if (Version > 1)
            {
                FilterList = (List<PageFilter>)info.GetValue("FilterList", typeof(List<PageFilter>));
            }
            else
            {
                FilterList = new List<PageFilter>();
            }
        }

        /// <summary>
        /// Gets or sets name of the file.  Not sure if this field is really relevant.  It is stored inside the book object which is somewhat strange.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets version of the book.  This helps when deserializing the stream so we know what
        /// objects make up a book.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether flag if there have been any modifications to the book since last save.
        /// </summary>
        public bool Dirty { get; set; } = false;

        /// <summary>
        /// Gets list of tags that are in the book.  Sort of like bookmarks.
        /// This is derived from the pages in the book.
        /// </summary>
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

        public List<PageFilter> FilterList { get; set; }

        /// <summary>
        /// Gets returns the number of pages in the book.
        /// </summary>
        public int PageCount
        {
            get
            {
                return _pages.Count;
            }
        }

        /// <summary>
        /// Gets the page tags in the book by looking at all of the pages.
        /// </summary>
        /// <returns>list of tags</returns>
        public List<string> GetPageTagsInBook()
        {
            var tags = new List<string>();

            foreach (Page page in _pages)
            {
                tags.AddRange(page.GetPageTags());
            }

            return tags;
        }

        /// <summary>
        /// Create a new page, and add it to the end of the book.
        /// </summary>
        /// <returns>The new page that was created</returns>
        public Page GetNewPage()
        {
            if (_pages.Count != 0)
            {
                Dirty = true;
            }

            var page = new Page(_pages.Count + 1);
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

        /// <summary>
        /// Gets the last page in the book.
        /// </summary>
        /// <returns>Last Page in the book</returns>
        public Page GetLastPage()
        {
            return _pages[_pages.Count - 1];
        }

        /// <summary>
        /// Gets all the pages in the book.
        /// </summary>
        /// <returns>All of the pages.</returns>
        public ICollection<Page> GetPages()
        {
            return _pages;
        }

        /// <summary>
        /// Add a specified page to the end of the book
        /// </summary>
        /// <param name="page">The page to add to the end of the book.</param>
        public void AddPage(Page page)
        {
            _pages.Add(page);
        }

        /// <summary>
        /// Insert the specified page into the book. Insertion point is determined by the
        /// page CreateDate value.  The subsequent pages are renumbered accordingly.
        /// </summary>
        /// <param name="newPage">The page to insert into the book</param>
        public void InsertPage(Page newPage)
        {
            if (newPage == null)
            {
                return;
            }

            bool added = false;
            for (var i = 0; i < _pages.Count; i++)
            {
                Page page = _pages[i];
                if (newPage.CreatedDate >= page.CreatedDate)
                {
                    _pages.Insert(i, newPage);
                    added = true;

                    // Renumber the remaining pages
                    for (var j = i; j < _pages.Count; j++)
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

        /// <summary>
        /// Delete the specified page from the book.  Then renumber the book.
        /// </summary>
        /// <param name="page">The page to delete</param>
        public void DeletePage(Page page)
        {
            _pages.Remove(page);
        }

        /// <summary>
        /// Renumber the entire book using the sequence determined by the list structure.
        /// </summary>
        public void RenumberPages()
        {
            for (var i = 0; i < _pages.Count; i++)
            {
                _pages[i].PageNumber = i + 1;
            }
        }

        /// <summary>
        /// Find all of the pages that meet the search criteria.  All of the relevant
        /// pages are compiled and a new book is created with the result.
        /// </summary>
        /// <param name="token">search string</param>
        /// <param name="comparison">String comparator</param>
        /// <returns>New Book that all containe the search token</returns>
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

        public Book GetBookFromFilter(string filter)
        {
            var currentFilter = FilterList.Find(f => f.Title == filter);
            var matching = _pages.Where(p => currentFilter.Contains(p.UUID));
            Book matchingPages = new Book();
            matchingPages._pages = matching.ToList();
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

        /// <summary>
        /// Serialize the current book
        /// </summary>
        /// <param name="info">Serilization info</param>
        /// <param name="context">streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            if (Version < bookVersion)
            {
                Version = bookVersion;
            }

            info.AddValue("FileName", FileName);
            info.AddValue("Version", Version);
            info.AddValue("Pages", _pages);

            if (Version > 1)
            {
                // Version 2 new fields
                info.AddValue("FilterList", FilterList);
            }
        }

        /// <summary>
        /// Update a quick filter.  This will either add or remove a page from a given quick filter.  If "add" is true,
        /// it will add it.
        /// </summary>
        /// <param name="filter">The filter index</param>
        /// <param name="page">The page to add/remove</param>
        /// <param name="add">True to add page, false to remove page.</param>
        public void UpdatePageFilter(string filter, Page page, bool add)
        {
            PageFilter pf = FilterList.Find(f => f.Title == filter);
            if (pf != null)
            {
                if (add)
                {
                    if (!pf.Contains(page.UUID))
                    {
                        pf.PageUUIDS.Add(page.UUID);
                    }
                }
                else
                {
                    pf.PageUUIDS.Remove(page.UUID);
                }
            }

        }
    }
}
