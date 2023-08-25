namespace Domain
{
    public class News
    {
        public News(string title, string hat, string description, string thumb, string thumbNail)
        {
            Title = title;
            Hat = hat;
            Description = description;
            Thumb = thumb;
            ThumbNail = thumbNail;

            //acoes--methos...etc
        }

        //regras de negocio

        public string Title { get; private set; }
        public string Hat { get; private set; }
        public string Description { get; private set; }
        public string Thumb { get; private set; }
        public string ThumbNail { get; private set; }

    }
}