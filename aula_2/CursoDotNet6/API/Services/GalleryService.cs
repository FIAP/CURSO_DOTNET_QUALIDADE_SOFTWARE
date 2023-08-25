using API.Entities;
using API.Entities.ViewModels;
using API.Infra;
using AutoMapper;

namespace API.Services
{
    public class GalleryService
    {
        private readonly IMapper _mapper;

        private readonly IMongoRepository<Gallery> _gallery;

        public GalleryService(IMongoRepository<Gallery> gallery, IMapper mapper)
        {
            _mapper = mapper;
            _gallery = gallery;
        }

        public Result<GalleryViewModel> Get(int page, int qtd) =>
            _mapper.Map<Result<GalleryViewModel>>(_gallery.Get(page, qtd));


        public GalleryViewModel Get(string id) =>
           _mapper.Map<GalleryViewModel>(_gallery.Get(id));

        public GalleryViewModel GetBySlug(string slug) =>
       _mapper.Map<GalleryViewModel>(_gallery.GetBySlug(slug));


        public GalleryViewModel Create(GalleryViewModel gallery)
        {
            var entity = new Gallery(gallery.Title, gallery.Legend, gallery.Author, gallery.Tags, gallery.Status, gallery.GalleryImages, gallery.Thumb);
            entity.PublishDate = DateTime.Now;

            _gallery.Create(entity);

            return Get(entity.Id);
        }

        public void Update(string id, GalleryViewModel galleryIn)
        {
            _gallery.Update(id, _mapper.Map<Gallery>(galleryIn));
        }

        public void Remove(string id) => _gallery.Remove(id);

    }
}
