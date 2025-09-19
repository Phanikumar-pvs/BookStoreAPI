using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Data
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
