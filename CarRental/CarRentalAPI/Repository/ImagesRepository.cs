using CarRentalAPI.Model.Domain;

namespace CarRentalAPI.Repository
{
    public interface ImagesRepository
    {
        //Method that will have upload functionality
        Task<Images> Upload(Images image);
    }
}
