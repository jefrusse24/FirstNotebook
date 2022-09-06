using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace FirstNotebook
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.titleListView = new System.Windows.Forms.ListView();
            this.pageHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.titleHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tagsHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.noteAreaTextBox = new System.Windows.Forms.RichTextBox();
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.pageTagsComboBox = new System.Windows.Forms.ComboBox();
            this.RTBPannel = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonBold = new System.Windows.Forms.Button();
            this.ButtonItalics = new System.Windows.Forms.Button();
            this.ButtonUnderline = new System.Windows.Forms.Button();
            this.ButtonFGColor = new System.Windows.Forms.Button();
            this.ButtonBGColor = new System.Windows.Forms.Button();
            this.ButtonBullet = new System.Windows.Forms.Button();
            this.ButtonIndent = new System.Windows.Forms.Button();
            this.ButtonOutdent = new System.Windows.Forms.Button();
            this.ButtonZoomIn = new System.Windows.Forms.Button();
            this.ButtonZoomOut = new System.Windows.Forms.Button();
            this.ButtonTodo = new System.Windows.Forms.Button();
            this.ButtonDone = new System.Windows.Forms.Button();
            this.ButtonLineBreak = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.tagFilterComboBox = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.pageInfoButton = new System.Windows.Forms.Button();
            this.NewPageButton = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatBoldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatItalicsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatUnderlineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatBulletMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatIndentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatOutdentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockUnlockPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.previousPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncWithDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsTodoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsDoneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FrormatLineBreakMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.RTBPannel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.titleListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.pageNumberLabel);
            this.splitContainer1.Panel2.Controls.Add(this.dateLabel);
            this.splitContainer1.Panel2.Controls.Add(this.titleTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.pageTagsComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.RTBPannel);
            this.splitContainer1.TabStop = false;
            // 
            // titleListView
            // 
            resources.ApplyResources(this.titleListView, "titleListView");
            this.titleListView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.titleListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pageHeader,
            this.dateHeader,
            this.titleHeader,
            this.tagsHeader});
            this.titleListView.FullRowSelect = true;
            this.titleListView.GridLines = true;
            this.titleListView.HideSelection = false;
            this.titleListView.MultiSelect = false;
            this.titleListView.Name = "titleListView";
            this.titleListView.ShowItemToolTips = true;
            this.titleListView.UseCompatibleStateImageBehavior = false;
            this.titleListView.View = System.Windows.Forms.View.Details;
            this.titleListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.TitleList_SelectionChanged);
            this.titleListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseUp);
            // 
            // pageHeader
            // 
            resources.ApplyResources(this.pageHeader, "pageHeader");
            // 
            // dateHeader
            // 
            resources.ApplyResources(this.dateHeader, "dateHeader");
            // 
            // titleHeader
            // 
            resources.ApplyResources(this.titleHeader, "titleHeader");
            // 
            // tagsHeader
            // 
            resources.ApplyResources(this.tagsHeader, "tagsHeader");
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.noteAreaTextBox);
            this.panel1.Name = "panel1";
            // 
            // noteAreaTextBox
            // 
            this.noteAreaTextBox.AcceptsTab = true;
            resources.ApplyResources(this.noteAreaTextBox, "noteAreaTextBox");
            this.noteAreaTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.noteAreaTextBox.HideSelection = false;
            this.noteAreaTextBox.Name = "noteAreaTextBox";
            this.noteAreaTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.Link_Clicked);
            //this.noteAreaTextBox.GotFocus += new System.EventHandler(this.NoteView_Focus);
            this.noteAreaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteView_KeyUp);
            // 
            // pageNumberLabel
            // 
            resources.ApplyResources(this.pageNumberLabel, "pageNumberLabel");
            this.pageNumberLabel.Name = "pageNumberLabel";
            // 
            // dateLabel
            // 
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.Name = "dateLabel";
            // 
            // titleTextBox
            // 
            resources.ApplyResources(this.titleTextBox, "titleTextBox");
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TitleView_KeyUp);
            // 
            // pageTagsComboBox
            // 
            resources.ApplyResources(this.pageTagsComboBox, "pageTagsComboBox");
            this.pageTagsComboBox.FormattingEnabled = true;
            this.pageTagsComboBox.Items.AddRange(new object[] {
            resources.GetString("pageTagsComboBox.Items")});
            this.pageTagsComboBox.Name = "pageTagsComboBox";
            this.pageTagsComboBox.TabStop = false;
            // 
            // RTBPannel
            // 
            resources.ApplyResources(this.RTBPannel, "RTBPannel");
            this.RTBPannel.Controls.Add(this.ButtonBold);
            this.RTBPannel.Controls.Add(this.ButtonItalics);
            this.RTBPannel.Controls.Add(this.ButtonUnderline);
            this.RTBPannel.Controls.Add(this.ButtonFGColor);
            this.RTBPannel.Controls.Add(this.ButtonBGColor);
            this.RTBPannel.Controls.Add(this.ButtonBullet);
            this.RTBPannel.Controls.Add(this.ButtonIndent);
            this.RTBPannel.Controls.Add(this.ButtonOutdent);
            this.RTBPannel.Controls.Add(this.ButtonZoomIn);
            this.RTBPannel.Controls.Add(this.ButtonZoomOut);
            this.RTBPannel.Controls.Add(this.ButtonTodo);
            this.RTBPannel.Controls.Add(this.ButtonDone);
            this.RTBPannel.Controls.Add(this.ButtonLineBreak);
            this.RTBPannel.Name = "RTBPannel";
            // 
            // ButtonBold
            // 
            resources.ApplyResources(this.ButtonBold, "ButtonBold");
            this.ButtonBold.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ButtonBold.Name = "ButtonBold";
            this.ButtonBold.TabStop = false;
            this.ButtonBold.UseVisualStyleBackColor = true;
            this.ButtonBold.Click += new System.EventHandler(this.FormatBaseAction);
            // 
            // ButtonItalics
            // 
            resources.ApplyResources(this.ButtonItalics, "ButtonItalics");
            this.ButtonItalics.Name = "ButtonItalics";
            this.ButtonItalics.TabStop = false;
            this.ButtonItalics.UseVisualStyleBackColor = true;
            this.ButtonItalics.Click += new System.EventHandler(this.FormatBaseAction);
            // 
            // ButtonUnderline
            // 
            resources.ApplyResources(this.ButtonUnderline, "ButtonUnderline");
            this.ButtonUnderline.Name = "ButtonUnderline";
            this.ButtonUnderline.TabStop = false;
            this.ButtonUnderline.UseVisualStyleBackColor = true;
            this.ButtonUnderline.Click += new System.EventHandler(this.FormatBaseAction);
            // 
            // ButtonFGColor
            // 
            resources.ApplyResources(this.ButtonFGColor, "ButtonFGColor");
            this.ButtonFGColor.Name = "ButtonFGColor";
            this.ButtonFGColor.UseVisualStyleBackColor = true;
            this.ButtonFGColor.Click += new System.EventHandler(this.ButtonFGColor_Click);
            // 
            // ButtonBGColor
            // 
            resources.ApplyResources(this.ButtonBGColor, "ButtonBGColor");
            this.ButtonBGColor.Name = "ButtonBGColor";
            this.ButtonBGColor.UseVisualStyleBackColor = true;
            this.ButtonBGColor.Click += new System.EventHandler(this.ButtonBGColor_Click);
            // 
            // ButtonBullet
            // 
            resources.ApplyResources(this.ButtonBullet, "ButtonBullet");
            this.ButtonBullet.Name = "ButtonBullet";
            this.ButtonBullet.TabStop = false;
            this.ButtonBullet.UseVisualStyleBackColor = true;
            this.ButtonBullet.Click += new System.EventHandler(this.FormatBulletAction);
            // 
            // ButtonIndent
            // 
            resources.ApplyResources(this.ButtonIndent, "ButtonIndent");
            this.ButtonIndent.Name = "ButtonIndent";
            this.ButtonIndent.TabStop = false;
            this.ButtonIndent.UseVisualStyleBackColor = true;
            this.ButtonIndent.Click += new System.EventHandler(this.FormatDentAction);
            // 
            // ButtonOutdent
            // 
            resources.ApplyResources(this.ButtonOutdent, "ButtonOutdent");
            this.ButtonOutdent.Name = "ButtonOutdent";
            this.ButtonOutdent.TabStop = false;
            this.ButtonOutdent.UseVisualStyleBackColor = true;
            this.ButtonOutdent.Click += new System.EventHandler(this.FormatDentAction);
            // 
            // ButtonZoomIn
            // 
            resources.ApplyResources(this.ButtonZoomIn, "ButtonZoomIn");
            this.ButtonZoomIn.Name = "ButtonZoomIn";
            this.ButtonZoomIn.TabStop = false;
            this.ButtonZoomIn.UseVisualStyleBackColor = true;
            this.ButtonZoomIn.Click += new System.EventHandler(this.ButtonZoom_Click);
            // 
            // ButtonZoomOut
            // 
            resources.ApplyResources(this.ButtonZoomOut, "ButtonZoomOut");
            this.ButtonZoomOut.Name = "ButtonZoomOut";
            this.ButtonZoomOut.TabStop = false;
            this.ButtonZoomOut.UseVisualStyleBackColor = true;
            this.ButtonZoomOut.Click += new System.EventHandler(this.ButtonZoom_Click);
            // 
            // ButtonTodo
            // 
            resources.ApplyResources(this.ButtonTodo, "ButtonTodo");
            this.ButtonTodo.Name = "ButtonTodo";
            this.ButtonTodo.UseVisualStyleBackColor = true;
            this.ButtonTodo.Click += new System.EventHandler(this.ButtonTodo_Click);
            // 
            // ButtonDone
            // 
            resources.ApplyResources(this.ButtonDone, "ButtonDone");
            this.ButtonDone.Name = "ButtonDone";
            this.ButtonDone.UseVisualStyleBackColor = true;
            this.ButtonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // ButtonLineBreak
            // 
            resources.ApplyResources(this.ButtonLineBreak, "ButtonLineBreak");
            this.ButtonLineBreak.Name = "ButtonLineBreak";
            this.ButtonLineBreak.UseVisualStyleBackColor = true;
            this.ButtonLineBreak.Click += new System.EventHandler(this.ButtonLineBreak_Click);
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // tagFilterComboBox
            // 
            resources.ApplyResources(this.tagFilterComboBox, "tagFilterComboBox");
            this.tagFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagFilterComboBox.FormattingEnabled = true;
            this.tagFilterComboBox.Items.AddRange(new object[] {
            resources.GetString("tagFilterComboBox.Items")});
            this.tagFilterComboBox.Name = "tagFilterComboBox";
            this.tagFilterComboBox.TabStop = false;
            // 
            // searchBox
            // 
            this.searchBox.AcceptsReturn = true;
            resources.ApplyResources(this.searchBox, "searchBox");
            this.searchBox.BackColor = System.Drawing.SystemColors.Info;
            this.searchBox.Name = "searchBox";
            this.searchBox.TextChanged += new System.EventHandler(this.SearchTextBox_Change);
            this.searchBox.GotFocus += new System.EventHandler(this.SearchTextBox_Focus);
            this.searchBox.LostFocus += new System.EventHandler(this.SearchTextBox_LooseFocus);
            // 
            // pageInfoButton
            // 
            resources.ApplyResources(this.pageInfoButton, "pageInfoButton");
            this.pageInfoButton.Name = "pageInfoButton";
            this.pageInfoButton.UseVisualStyleBackColor = true;
            this.pageInfoButton.Click += new System.EventHandler(this.PageInfoButton_Clicked);
            // 
            // NewPageButton
            // 
            resources.ApplyResources(this.NewPageButton, "NewPageButton");
            this.NewPageButton.Name = "NewPageButton";
            this.NewPageButton.UseVisualStyleBackColor = true;
            this.NewPageButton.Click += new System.EventHandler(this.NewPageButton_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.MenuFile_New);
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.MenuFile_Open);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.MenuFile_Save);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.MenuFile_SaveAs);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // printToolStripMenuItem
            // 
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            // 
            // printPreviewToolStripMenuItem
            // 
            resources.ApplyResources(this.printPreviewToolStripMenuItem, "printPreviewToolStripMenuItem");
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuFile_Exit);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator6,
            this.findToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.findPreviousToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            resources.ApplyResources(this.undoToolStripMenuItem, "undoToolStripMenuItem");
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_Undo);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            resources.ApplyResources(this.redoToolStripMenuItem, "redoToolStripMenuItem");
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_Redo);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // cutToolStripMenuItem
            // 
            resources.ApplyResources(this.cutToolStripMenuItem, "cutToolStripMenuItem");
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_Cut);
            // 
            // copyToolStripMenuItem
            // 
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_Copy);
            // 
            // pasteToolStripMenuItem
            // 
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_Paste);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_SelectAll);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // findToolStripMenuItem
            // 
            resources.ApplyResources(this.findToolStripMenuItem, "findToolStripMenuItem");
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_Find);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            resources.ApplyResources(this.findNextToolStripMenuItem, "findNextToolStripMenuItem");
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_FindNext);
            // 
            // findPreviousToolStripMenuItem
            // 
            this.findPreviousToolStripMenuItem.Name = "findPreviousToolStripMenuItem";
            resources.ApplyResources(this.findPreviousToolStripMenuItem, "findPreviousToolStripMenuItem");
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormatBoldMenuItem,
            this.FormatItalicsMenuItem,
            this.FormatUnderlineMenuItem,
            this.FormatBulletMenuItem,
            this.FormatIndentMenuItem,
            this.FormatOutdentMenuItem,
            this.FrormatLineBreakMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            resources.ApplyResources(this.formatToolStripMenuItem, "formatToolStripMenuItem");
            // 
            // FormatBoldMenuItem
            // 
            this.FormatBoldMenuItem.Name = "FormatBoldMenuItem";
            resources.ApplyResources(this.FormatBoldMenuItem, "FormatBoldMenuItem");
            this.FormatBoldMenuItem.Click += new System.EventHandler(this.FormatBaseAction);
            // 
            // FormatItalicsMenuItem
            // 
            this.FormatItalicsMenuItem.Name = "FormatItalicsMenuItem";
            resources.ApplyResources(this.FormatItalicsMenuItem, "FormatItalicsMenuItem");
            this.FormatItalicsMenuItem.Click += new System.EventHandler(this.FormatBaseAction);
            // 
            // FormatUnderlineMenuItem
            // 
            this.FormatUnderlineMenuItem.Name = "FormatUnderlineMenuItem";
            resources.ApplyResources(this.FormatUnderlineMenuItem, "FormatUnderlineMenuItem");
            this.FormatUnderlineMenuItem.Click += new System.EventHandler(this.FormatBaseAction);
            // 
            // FormatBulletMenuItem
            // 
            this.FormatBulletMenuItem.Name = "FormatBulletMenuItem";
            resources.ApplyResources(this.FormatBulletMenuItem, "FormatBulletMenuItem");
            this.FormatBulletMenuItem.Click += new System.EventHandler(this.FormatBulletAction);
            // 
            // FormatIndentMenuItem
            // 
            this.FormatIndentMenuItem.Name = "FormatIndentMenuItem";
            resources.ApplyResources(this.FormatIndentMenuItem, "FormatIndentMenuItem");
            this.FormatIndentMenuItem.Click += new System.EventHandler(this.FormatDentAction);
            // 
            // FormatOutdentMenuItem
            // 
            this.FormatOutdentMenuItem.Name = "FormatOutdentMenuItem";
            resources.ApplyResources(this.FormatOutdentMenuItem, "FormatOutdentMenuItem");
            this.FormatOutdentMenuItem.Click += new System.EventHandler(this.FormatDentAction);
            // 
            // pageToolStripMenuItem
            // 
            this.pageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPageToolStripMenuItem,
            this.pageInfoToolStripMenuItem,
            this.lockUnlockPageToolStripMenuItem,
            this.deletePageToolStripMenuItem,
            this.toolStripSeparator7,
            this.previousPageToolStripMenuItem,
            this.nextPageToolStripMenuItem,
            this.syncWithDBToolStripMenuItem});
            this.pageToolStripMenuItem.Name = "pageToolStripMenuItem";
            resources.ApplyResources(this.pageToolStripMenuItem, "pageToolStripMenuItem");
            // 
            // newPageToolStripMenuItem
            // 
            this.newPageToolStripMenuItem.Name = "newPageToolStripMenuItem";
            resources.ApplyResources(this.newPageToolStripMenuItem, "newPageToolStripMenuItem");
            this.newPageToolStripMenuItem.Click += new System.EventHandler(this.NewPageButton_Click);
            // 
            // pageInfoToolStripMenuItem
            // 
            this.pageInfoToolStripMenuItem.Name = "pageInfoToolStripMenuItem";
            resources.ApplyResources(this.pageInfoToolStripMenuItem, "pageInfoToolStripMenuItem");
            // 
            // lockUnlockPageToolStripMenuItem
            // 
            this.lockUnlockPageToolStripMenuItem.Name = "lockUnlockPageToolStripMenuItem";
            resources.ApplyResources(this.lockUnlockPageToolStripMenuItem, "lockUnlockPageToolStripMenuItem");
            this.lockUnlockPageToolStripMenuItem.Click += new System.EventHandler(this.LockUnlockPageToolStripMenuItem_Click);
            // 
            // deletePageToolStripMenuItem
            // 
            this.deletePageToolStripMenuItem.Name = "deletePageToolStripMenuItem";
            resources.ApplyResources(this.deletePageToolStripMenuItem, "deletePageToolStripMenuItem");
            this.deletePageToolStripMenuItem.Click += new System.EventHandler(this.DeletePageToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // previousPageToolStripMenuItem
            // 
            this.previousPageToolStripMenuItem.Name = "previousPageToolStripMenuItem";
            resources.ApplyResources(this.previousPageToolStripMenuItem, "previousPageToolStripMenuItem");
            // 
            // nextPageToolStripMenuItem
            // 
            this.nextPageToolStripMenuItem.Name = "nextPageToolStripMenuItem";
            resources.ApplyResources(this.nextPageToolStripMenuItem, "nextPageToolStripMenuItem");
            // 
            // syncWithDBToolStripMenuItem
            // 
            this.syncWithDBToolStripMenuItem.Name = "syncWithDBToolStripMenuItem";
            resources.ApplyResources(this.syncWithDBToolStripMenuItem, "syncWithDBToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.ToolsTodoMenuItem,
            this.ToolsDoneMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            resources.ApplyResources(this.customizeToolStripMenuItem, "customizeToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // ToolsTodoMenuItem
            // 
            this.ToolsTodoMenuItem.Name = "ToolsTodoMenuItem";
            resources.ApplyResources(this.ToolsTodoMenuItem, "ToolsTodoMenuItem");
            this.ToolsTodoMenuItem.Click += new System.EventHandler(this.ButtonTodo_Click);
            // 
            // ToolsDoneMenuItem
            // 
            this.ToolsDoneMenuItem.Name = "ToolsDoneMenuItem";
            resources.ApplyResources(this.ToolsDoneMenuItem, "ToolsDoneMenuItem");
            this.ToolsDoneMenuItem.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            resources.ApplyResources(this.contentsToolStripMenuItem, "contentsToolStripMenuItem");
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            resources.ApplyResources(this.indexToolStripMenuItem, "indexToolStripMenuItem");
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            resources.ApplyResources(this.searchToolStripMenuItem, "searchToolStripMenuItem");
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.MenuHelp_About);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.pageToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // FrormatLineBreakMenuItem
            // 
            this.FrormatLineBreakMenuItem.Name = "FrormatLineBreakMenuItem";
            resources.ApplyResources(this.FrormatLineBreakMenuItem, "FrormatLineBreakMenuItem");
            this.FrormatLineBreakMenuItem.Click += new System.EventHandler(this.ButtonLineBreak_Click);

            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.tagFilterComboBox);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pageInfoButton);
            this.Controls.Add(this.NewPageButton);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.RTBPannel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MenuFile_New(object sender, EventArgs e)
        {
            if (_pageIsDirty || _book.Dirty)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save first?", "New Document", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    MenuFile_Save(sender, e);
                    if (_pageIsDirty || _book.Dirty)
                    {
                        return;
                    }
                }
            }

            _book = new Book();
            _searchEngine.UpdateBook(_book);
            _book.GetNewPage();
            _activeView = _book;
            UpdateViewWithBook();
            _pageIsDirty = false;
        }

        private void MenuFile_Open(object sender, EventArgs e)
        {

            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Notebook File (*.eno)|*.eno|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var shouldWeReallyOpen = true;
                var backupFilename = openFileDialog1.FileName + ".bak";
                if (File.Exists(backupFilename))
                {
                    var shouldWeUseBackup = MessageBox.Show("Backup of file exists.  Do you want to use the backup?", "Oops", MessageBoxButtons.YesNo);
                    //MessageBox.Show("Cannot open file.  Backup file exists.  Please resolve.\n" + backupFilename, "Oops", MessageBoxButtons.OK);
                    if (shouldWeUseBackup == DialogResult.Yes)
                    {
                        File.Copy(openFileDialog1.FileName, openFileDialog1.FileName+".bak2",true);
                        File.Delete(openFileDialog1.FileName);
                        File.Move(openFileDialog1.FileName+".bak", openFileDialog1.FileName);
                        shouldWeReallyOpen = true;
                    }
                    else
                    {
                        shouldWeReallyOpen = false;
                    }
                }

                if (shouldWeReallyOpen)
                {
                    try
                    {
                        if ((myStream = openFileDialog1.OpenFile()) != null)
                        {
                            openFileDialog1.Dispose();
                            BinaryFormatter bf = new BinaryFormatter();
                            _book = (Book)bf.Deserialize(myStream);
                            _searchEngine.UpdateBook(_book);
                            _activeView = _book;
                            myStream.Close();
                            myStream.Dispose();
                            UpdateViewWithBook();
                            _pageIsDirty = false;
                            Text = $"{ApplicationName} - {Path.GetFileName(_book.FileName)}";
                            _book.Dirty = false;
                        }
                    }
                    catch (Exception)
                    {
                        // Issue opening file.
                    }
                }
            }
            openFileDialog1.Dispose();
        }

        private void MenuFile_Save(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_book.FileName))
            {
                MenuFile_SaveAs(sender, e);
                return;
            }

            SavePageChanges();
            Stream stream = null;
            try
            {
                stream = File.Open(_book.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, _book);
                stream.Close();
                stream.Dispose();
            }
            catch (Exception)
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
            _book.Dirty = false;
            _pageIsDirty = false;
            Text = $"{ApplicationName} - {Path.GetFileName(_book.FileName)}";
            StopBackgroundSaving();
        }

        private void MenuFile_SaveAs(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Notebook File (*.eno)|*.eno|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    SavePageChanges();
                    _book.FileName = saveFileDialog1.FileName;
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(myStream, _book);
                    myStream.Close();
                    myStream.Dispose();
                    _book.Dirty = false;
                    _pageIsDirty = false;
                    Text = $"{ApplicationName} - {Path.GetFileName(_book.FileName)}";
                    StopBackgroundSaving();
                }
            }
            saveFileDialog1.Dispose();
        }

        private void MenuFile_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuHelp_About(object sender, EventArgs e)
        {
            MessageBox.Show($"jNotebook by Jeff Russell.  Version {Version}", "About", MessageBoxButtons.OK);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label pageNumberLabel;
        private System.Windows.Forms.Button NewPageButton;
        private System.Windows.Forms.ListView titleListView;
        private System.Windows.Forms.ColumnHeader pageHeader;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader titleHeader;
        private System.Windows.Forms.ColumnHeader tagsHeader;
        private Button pageInfoButton;
        private Label dateLabel;
        private TextBox searchBox;
        private ComboBox tagFilterComboBox;
        private ComboBox pageTagsComboBox;
        private Button clearButton;
        private FlowLayoutPanel RTBPannel;
        private Button ButtonBold;
        private Button ButtonItalics;
        private Button ButtonUnderline;
        private Button ButtonBullet;
        private Button ButtonIndent;
        private Button ButtonOutdent;
        private Button ButtonZoomIn;
        private Button ButtonZoomOut;
        private RichTextBox noteAreaTextBox;
        private Button ButtonFGColor;
        private Button ButtonBGColor;
        private Button ButtonTodo;
        private Button ButtonDone;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripMenuItem findNextToolStripMenuItem;
        private ToolStripMenuItem findPreviousToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem FormatBoldMenuItem;
        private ToolStripMenuItem FormatItalicsMenuItem;
        private ToolStripMenuItem FormatUnderlineMenuItem;
        private ToolStripMenuItem FormatBulletMenuItem;
        private ToolStripMenuItem FormatIndentMenuItem;
        private ToolStripMenuItem FormatOutdentMenuItem;
        private ToolStripMenuItem pageToolStripMenuItem;
        private ToolStripMenuItem newPageToolStripMenuItem;
        private ToolStripMenuItem pageInfoToolStripMenuItem;
        private ToolStripMenuItem lockUnlockPageToolStripMenuItem;
        private ToolStripMenuItem deletePageToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem previousPageToolStripMenuItem;
        private ToolStripMenuItem nextPageToolStripMenuItem;
        private ToolStripMenuItem syncWithDBToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem ToolsTodoMenuItem;
        private ToolStripMenuItem ToolsDoneMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Panel panel1;
        private Button ButtonLineBreak;
        private ToolStripMenuItem FrormatLineBreakMenuItem;
    }
}

