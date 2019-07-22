﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using FirstNotebook.PubSub;
using FirstNotebook.Search;

namespace FirstNotebook
{
    public partial class Form1 : Form
    {
        public const int Indent = 25;
        public const string ApplicationName = "jNotebook";
        public const string Version = "1.4";
        private Page _currentPage;
        private bool _pageIsDirty;
        private Book _book;
        private Book _activeView;  // Usually same as _book, unless a search
        private string _searchToken;
        private SearchRecord _searchRecord;
        private int _lastSelectedRow;  // Keep track of currently selected row in listview - used to update title if the selected row changes.
        private SearchEngine _searchEngine;

        public Form1()
        {
            InitializeComponent();
            EventAggregator eve = new EventAggregator();
            _book = new Book();
            _searchEngine = new SearchEngine(_book, eve);
            eve.Subscribe<FindMatchingPagesEvent>(ReceivePageMatches);

            Text = $@"{ApplicationName} - {Path.GetFileName(_book.FileName)}";
            _currentPage = _book.GetNewPage();
            _pageIsDirty = false;
            _activeView = _book;
            _searchRecord = new SearchRecord();

            ListViewItem listViewItem = new ListViewItem($"{_currentPage.PageNumber}");
            listViewItem.SubItems.Add(DateTime.Now.ToLocalTime().ToString());
            listViewItem.SubItems.Add(_currentPage.GetPageTitle());
            titleListView.Items.Add(listViewItem);
            _lastSelectedRow = 0;

            pageNumberLabel.Text = "Page " + _currentPage.PageNumber;
            dateLabel.Text = _currentPage.CreatedDate.ToString("yyyy-MM-dd h:mm tt");
            titleListView.Items[_currentPage.PageNumber - 1].Selected = true;

            // LOOK AT THIS FOR the tag drop down.
            //https://social.msdn.microsoft.com/Forums/en-US/73ccbbee-0f77-48bb-9189-0af00c9a339f/combo-box-item-separator?forum=winappswithcsharp
            var dataSource = new List<string>();
            dataSource.Add("Tag Filter");
            dataSource.Add("Tag1");
            dataSource.Add("Tag2");
            tagFilterComboBox.DataSource = dataSource;
            //tagFilterComboBox.DataSource = _book.PageTags;
        }

        /**********************************************************************************
         * Event Handlers
         * *******************************************************************************/
        private void NewPageButton_Click(object sender, EventArgs e)
        {
            PrepareForNewPage();
            noteAreaTextBox.Clear();
            titleTextBox.Clear();
            titleTextBox.Focus();
            pageNumberLabel.Text = "Page " + _currentPage.PageNumber;
            dateLabel.Text = _currentPage.CreatedDate.ToString("yyyy-MM-dd h:mm tt");

            // hilight the correct row.
            titleListView.SelectedIndices.Clear();
            _lastSelectedRow = titleListView.Items.Count - 1;
            titleListView.Items[_lastSelectedRow].Selected = true;
            titleListView.Items[_lastSelectedRow].EnsureVisible();
            _pageIsDirty = false;
            _book.Dirty = true;
        }

        private void ListView_MouseUp(object sender, EventArgs e)
        {
            if (sender == titleListView)
            {
                if (titleListView.SelectedItems.Count == 1)
                {
                    if (_pageIsDirty)
                    {
                        SavePageChanges();
                    }

                    var nextLastRow = titleListView.SelectedItems[0].Index;
                    if (nextLastRow > _activeView.PageCount)
                    {
                        // ERROR.  This should not happen
                        MessageBox.Show("Hmmm", $"Not that many visible pages. {nextLastRow} > {_activeView.PageCount}. ", MessageBoxButtons.OK);
                        return;
                    }

                    _lastSelectedRow = nextLastRow;
                    UpdateViewWithPage(_activeView.GetPage(_lastSelectedRow));
                }
            }
        }

        private void NoteView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt || e.Control)
            {
                return;
            }

            if ((e.Modifiers == Keys.Control) || (e.Modifiers == Keys.Alt))
            {
                return;
            }

            if ((e.KeyData == Keys.ControlKey) || (e.KeyData == Keys.Alt) || (e.KeyData == Keys.ShiftKey) || (e.KeyData == Keys.Menu) || (e.KeyData == Keys.Apps))
            {
                return;
            }

            NoteView_TextChanged();
        }

        // Called when I set the rich text box with data.  Not quite what you want because
        // this is triggered when I change pages.
        private void NoteView_TextChanged()
        {
            if (_pageIsDirty)
            {
                return;
            }

            _pageIsDirty = true;
            if (_book.Dirty == false)
            {
                _book.Dirty = true;
                Text = $@"{ApplicationName} - {Path.GetFileName(_book.FileName)} *";
            }
        }

        private void TitleView_KeyUp(object sender, EventArgs e)
        {
            NoteView_TextChanged();
            titleListView.Items[_lastSelectedRow].SubItems[2].Text = titleTextBox.Text;
        }

        private void PrepareForNewPage()
        {
            if (_pageIsDirty)
            {
                SavePageChanges();
            }

            if (!string.IsNullOrEmpty(_searchToken))
            {
                _searchToken = null;
                searchBox.Text = string.Empty;
                _searchEngine.CancelFindMatchingPages();
                _activeView = _book;
                RebuildTitleList();
            }

            // Create a new page
            _currentPage = _book.GetNewPage();

            ListViewItem listViewItem = new ListViewItem($"{_currentPage.PageNumber}");
            listViewItem.SubItems.Add(DateTime.Now.ToLocalTime().ToString());
            listViewItem.SubItems.Add(string.Empty);
            titleListView.Items.Add(listViewItem);
        }

        private void SavePageChanges()
        {
            var title = titleTextBox.Text;
            _currentPage.PageTitle = title;
            _currentPage.PageData = noteAreaTextBox.Rtf;
            if (string.IsNullOrEmpty(titleTextBox.Text))
            {
                title = noteAreaTextBox.Text.Substring(0, noteAreaTextBox.TextLength < 60 ? noteAreaTextBox.TextLength : 60);
                if (noteAreaTextBox.TextLength > 60)
                {
                    title += "...";
                }

                _currentPage.DerivedTitle = title;
            }

            if (titleListView.Items.Count > _lastSelectedRow)
            {
                titleListView.Items[_lastSelectedRow].SubItems[2].Text = title;
            }

            _book.Dirty = true;
            _pageIsDirty = false;
        }

        private void UpdateViewWithPage(Page page)
        {
            _currentPage = page;
            titleTextBox.Text = page.PageTitle;
            noteAreaTextBox.Rtf = page.PageData;
            pageNumberLabel.Text = "Page " + page.PageNumber;
            dateLabel.Text = _currentPage.CreatedDate.ToString("yyyy-MM-dd h:mm tt");
        }

        private void UpdateViewWithBook()
        {
            RebuildTitleList();

            UpdateViewWithPage(_activeView.GetLastPage());
            _lastSelectedRow = _activeView.PageCount - 1;
            titleListView.Items[_lastSelectedRow].Selected = true;
            titleListView.Items[_lastSelectedRow].EnsureVisible();
            titleListView.Focus();
        }

        private void RebuildTitleList()
        {
            titleListView.Items.Clear();

            foreach (var page in _activeView.GetPages())
            {
                ListViewItem listViewItem = new ListViewItem($"{page.PageNumber}");
                listViewItem.SubItems.Add(page.CreatedDate.ToLocalTime().ToString());
                listViewItem.SubItems.Add(page.GetPageTitle());
                titleListView.Items.Add(listViewItem);
            }
        }

        private void PageInfoButton_Clicked(object sender, EventArgs e)
        {
        }

        // Is this the same as ListView_MouseUp?  No.  It can change with arrow keys... up down.
        private void TitleList_SelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (titleListView.SelectedItems.Count == 1)
            {
                if (_pageIsDirty)
                {
                    SavePageChanges();
                }

                _lastSelectedRow = titleListView.SelectedItems[0].Index;
                UpdateViewWithPage(_activeView.GetPage(_lastSelectedRow));
            }
        }

        /**********************************************************************************
         * Edit Menu Item
         * *******************************************************************************/
        private void MenuEdit_Undo(object sender, EventArgs e)
        {
            if (noteAreaTextBox.Focused)
            {
                noteAreaTextBox.Undo();
                NoteView_TextChanged();
            }
            else if (titleTextBox.Focused)
            {
                titleTextBox.Undo();
            }
        }

        private void MenuEdit_Redo(object sender, EventArgs e)
        {
            if (noteAreaTextBox.Focused)
            {
                noteAreaTextBox.Redo();
                NoteView_TextChanged();
            }
        }

        private void MenuEdit_Cut(object sender, EventArgs e)
        {
            if (noteAreaTextBox.Focused)
            {
                noteAreaTextBox.Cut();
                NoteView_TextChanged();
            }
            else if (titleTextBox.Focused)
            {
                titleTextBox.Cut();
            }
        }

        private void MenuEdit_Copy(object sender, EventArgs e)
        {
            if (noteAreaTextBox.Focused)
            {
                noteAreaTextBox.Copy();
                NoteView_TextChanged();
            }
            else if (titleTextBox.Focused)
            {
                titleTextBox.Copy();
            }
        }

        private void MenuEdit_Paste(object sender, EventArgs e)
        {
            if (noteAreaTextBox.Focused)
            {
                noteAreaTextBox.Paste();
                NoteView_TextChanged();
            }
            else if (titleTextBox.Focused)
            {
                titleTextBox.Paste();
            }
        }

        private void MenuEdit_SelectAll(object sender, EventArgs e)
        {
            if (noteAreaTextBox.Focused)
            {
                noteAreaTextBox.SelectAll();
            }
            else if (titleTextBox.Focused)
            {
                titleTextBox.SelectAll();
            }
        }

        private void MenuEdit_Find(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_searchToken) && (searchBox.Text == "Search"))
            {
                searchBox.Text = string.Empty;
            }
            else
            {
                searchBox.SelectAll();
            }

            searchBox.Focus();
        }

        private void MenuEdit_FindNext(object sender, EventArgs e)
        {
            if ((_searchRecord == null) || string.IsNullOrEmpty(_searchRecord.Token) || (_searchToken == null))
            {
                return;
            }

            _searchToken = searchBox.Text;
            searchBox.Focus();

            SearchRecord nextMatch = FindNextMatch(_searchRecord);

            if (nextMatch == null)
            {
                HiliteSearch();
                SystemSounds.Beep.Play();
            }
            else
            {
                if (nextMatch.Location >= noteAreaTextBox.TextLength)
                {
                    SystemSounds.Beep.Play();
                    ErrorHandler.Error(GetType(), "MenuEdit_FindNext", "Search Location is after the end of the text.", null);
                    return;
                }

                _searchRecord = nextMatch;
                HiliteSearch();
            }
        }

        private SearchRecord FindNextMatch(SearchRecord startingPoint)
        {
            bool startFromTop = false;

            // This happens if while in a search, the person clicks on a different page.
            if (startingPoint.Page != _currentPage)
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
                nextMatch.Page = _currentPage;
                nextMatch.Location = 0;
                startFromTop = true;
            }

            int rangeLocation = 0;

            while (true)
            {
                if (startFromTop == true)
                {
                    rangeLocation = titleTextBox.Text.IndexOf(startingPoint.Token, startingPoint.StringComparison);
                    if (rangeLocation != -1)
                    {
                        nextMatch.InTitle = true;
                        nextMatch.Page = _currentPage;
                        nextMatch.Location = rangeLocation;
                        return nextMatch;
                    }
                    else
                    {
                        nextMatch.Location = 0;
                        start = 0;
                    }
                }

                if (startingPoint.InTitle && (titleTextBox.Text.Length >= start))
                {
                    rangeLocation = titleTextBox.Text.IndexOf(startingPoint.Token, start, startingPoint.StringComparison);
                    if (rangeLocation == -1)
                    {
                        start = 0;
                    }
                    else
                    {
                        nextMatch.Location = rangeLocation;
                        nextMatch.Page = _currentPage;
                        nextMatch.InTitle = true;
                        nextMatch.Token = _searchToken;
                        return nextMatch;
                    }
                }

                rangeLocation = noteAreaTextBox.Text.IndexOf(_searchToken, start, startingPoint.StringComparison);
                if (rangeLocation == -1)
                {
                    Page curPage = _currentPage;
                    NextPage();
                    if (_currentPage == curPage)
                    {
                        return null;
                    }

                    startFromTop = true;
                    start = 0;
                }
                else
                {
                    nextMatch.Location = rangeLocation;
                    nextMatch.Page = _currentPage;
                    nextMatch.InTitle = false;
                    return nextMatch;
                }
            }
        }

        private void NextPage()
        {
            if (_lastSelectedRow >= _activeView.PageCount - 1)
            {
                return;
            }

            int nextRow = _lastSelectedRow + 1;
            if (_pageIsDirty)
            {
                SavePageChanges();
            }

            titleListView.Items[nextRow].Selected = true;
            titleListView.Items[nextRow].EnsureVisible();
            _lastSelectedRow = nextRow;
            UpdateViewWithPage(_activeView.GetPage(_lastSelectedRow));
        }

        private void SearchTextBox_Focus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_searchToken) && (searchBox.Text == "Search"))
            {
                searchBox.Text = string.Empty;
            }
        }

        private void NoteView_Focus(object sender, EventArgs e)
        {
            // if searchtoken contins simething, then when we focus in the noteview, we need to redraw it.
            // This helps fix the hilighted formatting that is done with the find.
            if (!string.IsNullOrEmpty(_searchToken))
            {
                // redraw page with no search hilighting
                UpdateViewWithPage(_currentPage);
                _searchToken = string.Empty;
            }
        }

        private void SearchTextBox_Change(object sender, EventArgs e)
        {
            _searchRecord.Clear();

            noteAreaTextBox.Enabled = true;

            if (_pageIsDirty)
            {
                SavePageChanges();
            }

            if (string.IsNullOrEmpty(searchBox.Text))
            {
                // Clear the searching
                _searchToken = null;
                _searchEngine.CancelFindMatchingPages();
                _activeView = _book;

                RebuildTitleList();

                if (_activeView.PageCount > 0)
                {
                    titleListView.Items[_currentPage.PageNumber - 1].Selected = true;
                    titleListView.Items[_currentPage.PageNumber - 1].EnsureVisible();
                    _lastSelectedRow = _currentPage.PageNumber - 1;
                    searchBox.Focus();
                    UpdateViewWithPage(_currentPage);
                }

                return;
            }

            _searchToken = searchBox.Text;
            _searchRecord.Token = _searchToken;
            GetApplicablePages();
        }

        private void ReceivePageMatches(FindMatchingPagesEvent obj)
        {
            System.Diagnostics.Debug.WriteLine($"Receive Matching Pages for {obj.SearchToken}");

            // Make sure we still care about the search results
            if (!searchBox.ContainsFocus || !searchBox.Text.Equals(obj.SearchToken, StringComparison.OrdinalIgnoreCase))
            {
                System.Diagnostics.Debug.WriteLine($"Ignoring Matching Pages for {obj.SearchToken}");
                return;
            }

            _activeView = obj.MatchingPages;
            RebuildTitleList();

            if (_activeView.PageCount > 0)
            {
                titleListView.Items[0].Selected = true;
                titleListView.Items[0].EnsureVisible();
                _lastSelectedRow = 0;
                UpdateViewWithPage(_activeView.GetPage(0));
                _searchRecord.Page = _currentPage;
                _searchRecord.Token = _searchToken;
                int location = _currentPage.PageTitle.IndexOf(_searchToken, _searchRecord.StringComparison);
                if (location != -1)
                {
                    _searchRecord.InTitle = true;
                    _searchRecord.Location = location;
                }
                else
                {
                    location = noteAreaTextBox.Text.IndexOf(_searchToken, _searchRecord.Location, _searchRecord.StringComparison);
                    _searchRecord.InTitle = false;
                    _searchRecord.Location = location;
                }

                HiliteSearch();
            }
            else
            {
                // No page was found.  Remove all references to any page.
                noteAreaTextBox.Text = string.Empty;
                noteAreaTextBox.Enabled = false;
                titleTextBox.Text = string.Empty;
                pageNumberLabel.Text = string.Empty;
                dateLabel.Text = string.Empty;
            }

            searchBox.Focus();
        }

        private void HiliteSearch()
        {
            if (_searchRecord.InTitle)
            {
                // Do Nothing.
            }
            else
            {
                try
                {
                    noteAreaTextBox.Find(_searchRecord.Token, _searchRecord.Location, noteAreaTextBox.TextLength, RichTextBoxFinds.None);
                    noteAreaTextBox.SelectionBackColor = Color.Yellow;
                    noteAreaTextBox.SelectionStart = _searchRecord.Location;
                    noteAreaTextBox.ScrollToCaret();
                }
                catch (Exception e)
                {
                    ErrorHandler.Error(GetType(), "HiliteSearch", "Problem in with hilighting the desired text.", e);
                }
            }
        }

        /// <summary>
        /// This will call an asynchronous event that will perform a search for the pages that meet the search criteria.
        /// This asynchronous call will be responsible for sending a message which we will listen for.
        /// </summary>
        private void GetApplicablePages()
        {
            // TODO: Filter on tags, then search for token in tag result.
            _searchEngine.FindMatchingPages(_searchToken, _searchRecord.StringComparison);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            searchBox.Text = string.Empty;
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_book.Dirty)
            {
                string filename = Path.GetFileName(_book.FileName);
                var status = MessageBox.Show($"Do you want to save changes to notebook {filename}?", "jNotebook",
                   MessageBoxButtons.YesNoCancel);

                if (status == DialogResult.Yes)
                {
                    e.Cancel = true;
                    MenuFile_Save(sender, e);
                }
                else if (status == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void FormatBulletAction(object sender, EventArgs e)
        {
            noteAreaTextBox.SelectionBullet = noteAreaTextBox.SelectionBullet ? false : true;

            noteAreaTextBox.Focus();
            NoteView_TextChanged();
        }

        // Indent or Outdent
        private void FormatDentAction(object sender, EventArgs e)
        {
            string action;
            if (sender.GetType().Equals(typeof(ToolStripMenuItem)))
            {
                action = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            }
            else if (sender.GetType().Equals(typeof(Button)))
            {
                action = (sender as Button).Name.Replace("Button", string.Empty);
            }
            else
            {
                return;
            }

            try
            {
                if (action.Equals("Indent"))
                {
                    noteAreaTextBox.SelectionIndent += Indent;
                }
                else if (action.Equals("Outdent"))
                {
                    noteAreaTextBox.SelectionIndent -= Indent;
                }

                NoteView_TextChanged();
                noteAreaTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void ButtonZoom_Click(object sender, EventArgs e)
        {
            try
            {
                string name = (sender as Button).Name;
                if (name.Equals("ButtonZoomIn"))
                {
                    noteAreaTextBox.ZoomFactor += 0.2f;
                }
                else if (name.Equals("ButtonZoomOut"))
                {
                    noteAreaTextBox.ZoomFactor -= 0.2f;
                }

                noteAreaTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void FormatBaseAction(object sender, EventArgs e)
        {
            string action;
            if (sender.GetType().Equals(typeof(ToolStripMenuItem)))
            {
                action = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            }
            else if (sender.GetType().Equals(typeof(Button)))
            {
                action = (sender as Button).Name.Replace("Button", string.Empty);
            }
            else
            {
                return;
            }

            if (!(noteAreaTextBox.SelectionFont == null))
            {
                try
                {
                    Font currentFont = noteAreaTextBox.SelectionFont;
                    FontStyle newFontStyle = noteAreaTextBox.SelectionFont.Style;
                    if (action.Equals("Bold"))
                    {
                        newFontStyle = noteAreaTextBox.SelectionFont.Style ^ FontStyle.Bold;
                    }
                    else if (action.Equals("Italics"))
                    {
                        newFontStyle = noteAreaTextBox.SelectionFont.Style ^ FontStyle.Italic;
                    }
                    else if (action.Equals("Underline"))
                    {
                        newFontStyle = noteAreaTextBox.SelectionFont.Style ^ FontStyle.Underline;
                    }

                    noteAreaTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                    noteAreaTextBox.Focus();
                    NoteView_TextChanged();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error");
                }
            }
        }

        private void Link_Clicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void ButtonFGColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.AllowFullOpen = false;
            colorDialog1.AnyColor = false;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (noteAreaTextBox.SelectionLength > 0)
                {
                    noteAreaTextBox.SelectionColor = colorDialog1.Color;
                    NoteView_TextChanged();
                }
            }
        }

        private void ButtonBGColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.AllowFullOpen = false;
            colorDialog1.AnyColor = false;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (noteAreaTextBox.SelectionLength > 0)
                {
                    noteAreaTextBox.SelectionBackColor = colorDialog1.Color;
                    NoteView_TextChanged();
                }
            }
        }

        private void ButtonTodo_Click(object sender, EventArgs e)
        {
            int startPos = noteAreaTextBox.SelectionStart;
            if (noteAreaTextBox.TextLength == startPos)
            {
                // BUG: If at the end of text, your cursor is left in the formatting of the TODO tag.
            }

            noteAreaTextBox.SelectedText = "TODO";
            noteAreaTextBox.Select(startPos, 4);
            noteAreaTextBox.SelectionBackColor = Color.Violet;
            noteAreaTextBox.Select(startPos + 4, 0);
            noteAreaTextBox.Select();
            NoteView_TextChanged();
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            int startPos = noteAreaTextBox.SelectionStart;
            noteAreaTextBox.SelectedText = "DONE";
            noteAreaTextBox.Select(startPos, 4);
            noteAreaTextBox.SelectionBackColor = Color.LightGray;
            noteAreaTextBox.Select(startPos + 4, 0);
            noteAreaTextBox.Select();
            NoteView_TextChanged();
        }
    }
}
