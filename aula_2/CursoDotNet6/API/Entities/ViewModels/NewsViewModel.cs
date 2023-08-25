using API.Entities.Enums;

namespace API.Entities.ViewModels
{
    public class NewsViewModel
    {
        public string? Id { get; set; }
        public string Hat { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string Img { get; set; }
        public string? Slug { get; protected set; }
        public Status Status { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
