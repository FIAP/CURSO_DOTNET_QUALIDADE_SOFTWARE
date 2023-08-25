using API.Entities.ViewModels;

namespace API.Services
{
    public class ClipeService : IClipeService
    {
        public string Create(ClipeViewModel clipe)
        {
            if (clipe.TimeEnd < clipe.TimeInit)            
                return "O tempo final não pode ser menor que o inicial.";

            if (clipe.UrlVideo.Contains("youtube"))
                return "O vídeo não pode ser do Youtube.";


            return "Clipe criado com sucesso!";
        }
    }
}
