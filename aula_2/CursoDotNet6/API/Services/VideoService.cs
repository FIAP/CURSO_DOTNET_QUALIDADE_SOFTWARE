using API.Entities;
using API.Entities.ViewModels;
using API.Infra;
using AutoMapper;

namespace API.Services
{
    public class VideoService
    {
        private readonly IMapper _mapper;

        private readonly IMongoRepository<Video> _video;

        public VideoService(IMongoRepository<Video> video, IMapper mapper)
        {
            _mapper = mapper;
            _video = video;
        }

        public Result<VideoViewModel> Get(int page, int qtd) =>
            _mapper.Map<Result<VideoViewModel>>(_video.Get(page, qtd));


        public VideoViewModel Get(string id) =>
           _mapper.Map<VideoViewModel>(_video.Get(id));

        public VideoViewModel GetBySlug(string slug) =>
       _mapper.Map<VideoViewModel>(_video.GetBySlug(slug));


        public VideoViewModel Create(VideoViewModel video)
        {
            var entity = new Video(video.Hat, video.Title, video.Author, video.Thumbnail, video.UrlVideo, video.Status);
            entity.PublishDate = DateTime.Now;
            _video.Create(entity);

            return Get(entity.Id);
        }

        public void Update(string id, VideoViewModel newsIn)
        {
            _video.Update(id, _mapper.Map<Video>(newsIn));
        }

        public void Remove(string id) => _video.Remove(id);

    }
}
