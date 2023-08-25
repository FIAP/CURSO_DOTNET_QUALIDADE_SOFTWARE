using Domain;

//SOLID

namespace Application.UseCase
{
    //UseCase --Clean arquiteture
    //DDD em Camadas -- Service
    //Hexagonal -> Service ou UseCase
    //Onion Architeture --> Serice e UseCase 
    public interface INewsUseCase
    {
        IEnumerable<News> GetAll();
    }
}
