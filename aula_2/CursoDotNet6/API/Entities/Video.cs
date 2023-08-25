using API.Entities.Enums;
using API.Infra;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities
{
    public class Video : BaseEntity
    {
        public Video(string hat, string title, string author, string thumbnail,string urlVideo, Status status)
        {
            Hat = hat;
            Title = title;
            Author = author;
            Thumbnail = thumbnail;
            Status = status;
            UrlVideo = urlVideo;
            ValidateEntity();
        }

        [BsonElement("hat")]
        public string Hat { get; private set; }

        [BsonElement("title")]
        public string Title { get; private set; }       

        [BsonElement("author")]
        public string Author { get; private set; }

        [BsonElement("thumbnail")]
        public string Thumbnail { get; private set; }

        [BsonElement("urlVideo")]
        public string UrlVideo { get; private set; }


        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Title, "O título não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(Hat, "O chapéu não pode estar vazio!");

            AssertionConcern.AssertArgumentLength(Title, 90, "O título deve ter até 90 caracteres!");
            AssertionConcern.AssertArgumentLength(Hat, 40, "O chapéu deve ter até 40 caracteres!");
        }

    }
}
