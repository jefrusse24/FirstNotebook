namespace FirstNotebook.Search
{
    public class FindMatchingPagesEvent
    {
        private Book _matchingPages;

        public FindMatchingPagesEvent(Book book)
        {
            _matchingPages = book;
        }
    }
}
