select BookName, AuthorName, Genre, BookDescribtion, ReleaseDate
from Book, Genre, Book_Genre, Author, Book_Author
where Book_Genre.Book_ID=Book.ID and Book_Genre.Genre_ID=Genre.ID and Book_Author.Book_ID = Book.ID and Book_Author.Author_ID = Author.ID