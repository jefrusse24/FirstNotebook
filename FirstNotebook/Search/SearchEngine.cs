using FirstNotebook.PubSub;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FirstNotebook.Search
{

    public class SearchEngine
    {
        CancellationTokenSource cts;
        EventAggregator _eventAggregator;
        private Book _masterBook;
        private bool _isStillSearching;

        public SearchEngine(Book book, EventAggregator eventAggregator)
        {
            _masterBook = book;
            _isStillSearching = false;
            _eventAggregator = eventAggregator;
        }

        // This method is responsible for getting the desired pages from the MasterBook that meet
        // the search criteria.  This method will be asychronous so the user can still continue
        // their work, which may send a new search request.  If this happens, and we have not
        // completed our search, we will cancel the original search, and start a new search.
        // When the method completes, this will send an event to indicate the search is complete.
        // There will have to be an event listener to listen for the completed search result.
        // This is a Single-Invocation call.
        // This could use ProgressChangedEventArgs if you want to provide feedback on how much you have searched.
        // Optionally Provide Support for Returning Incremental Results

        // Use EventAggregator Publish/Subscribe, and publish a FindMatchingPagesEvent 

        public async void FindMatchingPages(string searchToken, StringComparison comparison)
        {
            if (_isStillSearching)
            {
                CancelFindMatchingPages();
            }

            cts = new CancellationTokenSource();

            try
            {
                _isStillSearching = true;
                Book resultingBook = await FindMatchingPagesAsync(cts.Token, searchToken, comparison);
                _eventAggregator.Publish(new FindMatchingPagesEvent(resultingBook));
                _isStillSearching = false;
            }
            catch (OperationCanceledException)
            {
                // Cancelled.  Do nothing
            }
            catch (Exception)
            {
            }

        }

        private async Task<Book> FindMatchingPagesAsync(CancellationToken ct, string searchToken, StringComparison comparison)
        {
            //Book matchingPages = new Book();
            //foreach (Page page in _pages)
            //{
            //    if (page.ContainsMatching(token, comparison))
            //    {
            //        matchingPages.AddPage(page);
            //    }
            //}
            //return matchingPages;

            await Task.Delay(250);
            return new Book();


        }

        private void CancelFindMatchingPages()
        {
            if (cts != null)
            {
                cts.Cancel();
                _isStillSearching = false;
            }
        }


        /*
        public SearchRecord DoSearch(SearchRecord startingPoint, Page currentPage, string searchToken)
        {
            bool startFromTop = false;

            // This happens if while in a search, the person clicks on a different page.
            if (startingPoint.Page != currentPage)
            {
                startFromTop = true;
            }

            SearchRecord nextMatch = new SearchRecord();
            nextMatch.Token = startingPoint.Token;
            nextMatch.StringComparison = startingPoint.StringComparison;

            int start = startingPoint.Location + 1;
            if (startingPoint.IsClear())
            {
                // Happens when you click in a page during a search.
                nextMatch.Page = currentPage;
                nextMatch.Location = 0;
                startFromTop = true;
            }

            int rangeLocation = 0;

            while (true)
            {
                if (startFromTop == true)
                {
                    rangeLocation = currentPage.PageTitle.IndexOf(startingPoint.Token, startingPoint.StringComparison);
                    if (rangeLocation != -1)
                    {
                        nextMatch.InTitle = true;
                        nextMatch.Page = currentPage;
                        nextMatch.Location = rangeLocation;
                        return nextMatch;
                    }
                    else
                    {
                        nextMatch.Location = 0;
                        start = 0;
                    }
                }

                if (startingPoint.InTitle && (currentPage.PageTitle.Length >= start))
                {
                    rangeLocation = currentPage.PageTitle.IndexOf(startingPoint.Token, start, startingPoint.StringComparison);
                    if (rangeLocation == -1)
                    {
                        start = 0;
                    }
                    else
                    {
                        nextMatch.Location = rangeLocation;
                        nextMatch.Page = currentPage;
                        nextMatch.InTitle = true;
                        nextMatch.Token = searchToken;
                        return nextMatch;
                    }
                }

                rangeLocation = noteAreaTextBox.Text.IndexOf(searchToken, start, startingPoint.StringComparison);
                if (rangeLocation == -1)
                {
                    Page curPage = currentPage;
                    NextPage();
                    if (currentPage == curPage)
                    {
                        return null;
                    }

                    startFromTop = true;
                    start = 0;
                }
                else
                {
                    nextMatch.Location = rangeLocation;
                    nextMatch.Page = currentPage;
                    nextMatch.InTitle = false;
                    return nextMatch;
                }
            }
        }
    */
    }
}
