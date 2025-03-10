namespace Weatherions.Models
{
    public class NewsApiResponse
    {
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}