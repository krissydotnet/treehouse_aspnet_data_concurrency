using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookLibraryManagerWebApp.ViewModels
{
    public class ComicBooksDeleteViewModel 
    {
        public ComicBook ComicBook { get; set; } = new ComicBook();

        /// <summary>
        /// This property enables model binding to be able to bind the "id"
        /// route parameter value to the "ComicBook.Id" model property.
        /// </summary>
        public int Id
        {
            get { return ComicBook.Id; }
            set { ComicBook.Id = value; }
        }
        public bool ComicBookHasBeenDeleted { get; set; }
    }
}