namespace FirstNotebook.Search
{
    public class FindMatchingPagesEvent
    {
        public FindMatchingPagesEvent(Book book, string searchToken)
        {
            MatchingPages = book;
            SearchToken = searchToken;
        }

        public Book MatchingPages { get; set; }

        public string SearchToken { get; set;  }
    }
}
