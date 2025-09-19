using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public BookRepository(BookStoreContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<BookModel>> GetBooksAsync()
        {
            //var records = await _context.Books.Select(x=> new BookModel()
            //{
            //    Id=x.Id,
            //    Title=x.Title,
            //    Description=x.Description

            //}).ToListAsync();
            //return records;
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            //var record = await _context.Books.Where(x=>x.Id==id) .Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description

            //}).FirstOrDefaultAsync();
            //return record;
            var book = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            //var book = new Books()
            //{
            //    Title = bookModel.Title,
            //    Description = bookModel.Description
            //};
            var book = _mapper.Map<Books>(bookModel);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task UpdateBookAsync(int id, BookModel bookModel)
        {
            //var book = new Books()
            //{
            //    Id=id,
            //    Title = bookModel.Title,
            //    Description = bookModel.Description
            //};
            var book = _mapper.Map<Books>(bookModel);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            //var book = await _context.Books.FindAsync(id);
            //if (book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;

            //    await _context.SaveChangesAsync();
            //};
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = new Books() { Id = id };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();           
        }

    }
}
