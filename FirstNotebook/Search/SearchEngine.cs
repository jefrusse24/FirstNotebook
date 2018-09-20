using System;
using System.Threading;
using System.Threading.Tasks;
using FirstNotebook.PubSub;

namespace FirstNotebook.Search
{
    public class SearchEngine
    {
        private CancellationTokenSource _cts;
        private EventAggregator _eventAggregator;
        private Book _masterBook;

        public SearchEngine(Book book, EventAggregator eventAggregator)
        {
            _masterBook = book;
            _eventAggregator = eventAggregator;
            _cts = null;
        }

        public void UpdateBook(Book book)
        {
            _masterBook = book;
        }

        // This method is responsible for getting the desired pages from the MasterBook that meet
        // the search criteria.  This method will be asychronous so the user can still continue
        // their work, which may send a new search request.  If this happens, and we have not
        // completed our search, we will cancel the original search, and start a new search.
        // When the method completes, this will send an event to indicate the search is complete.
        // There is an event listener to listen for the completed search result.
        // This is a Single-Invocation call.
        // This could use ProgressChangedEventArgs if you want to provide feedback on how much you have searched.
        // Optionally Provide Support for Returning Incremental Results

        // Use EventAggregator Publish/Subscribe, and publish a FindMatchingPagesEvent

        public async void FindMatchingPages(string searchToken, StringComparison comparison)
        {
            CancelFindMatchingPages();

            _cts = new CancellationTokenSource();
            try
            {
                System.Diagnostics.Debug.WriteLine($"Begin search for {searchToken}");
                Book resultingBook = await FindMatchingPagesAsync(_cts.Token, searchToken, comparison);
                _eventAggregator.Publish(new FindMatchingPagesEvent(resultingBook, searchToken));
                _cts = null;
            }
            catch (OperationCanceledException)
            {
                System.Diagnostics.Debug.WriteLine("Cancel Exeption");
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Unknown Exception.");
            }
        }

        public void CancelFindMatchingPages()
        {
            System.Diagnostics.Debug.WriteLine("Want to Cancel Active Search");
            if (_cts != null)
            {
                _cts.Cancel();
                System.Diagnostics.Debug.WriteLine("Cancel Active Search");
            }
        }

        private async Task<Book> FindMatchingPagesAsync(CancellationToken ct, string searchToken, StringComparison comparison)
        {
            if (ct.IsCancellationRequested)
            {
                System.Diagnostics.Debug.WriteLine($"Canceled Search before it even began {searchToken}");
                ct.ThrowIfCancellationRequested();
            }

            // This will group any searches together, and also allow the UI to be responsive by running this in its own thread.
            await Task.Delay(150).ConfigureAwait(false);

            Book matchingPages = new Book();
            foreach (Page page in _masterBook.GetPages())
            {
                if (ct.IsCancellationRequested)
                {
                    System.Diagnostics.Debug.WriteLine($"Canceled Search for {searchToken}");
                    ct.ThrowIfCancellationRequested();
                    break;
                }

                if (page.ContainsMatching(searchToken, comparison))
                {
                    matchingPages.AddPage(page);
                }
            }

            return matchingPages;
        }
    }
}
