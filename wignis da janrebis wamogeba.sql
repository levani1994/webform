select BookName, Genre, BookDescribtion, ReleaseDate
from Book, Genre, Book_Genre
where Book_Genre.Book_ID=Book.ID and Book_Genre.Genre_ID=Genre.ID