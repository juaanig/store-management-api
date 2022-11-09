using store_management_api.Entities;



namespace store_management_api.Data.Repository.Interfaces
{
    public interface IUbicacionRepository
    {
        public List<Ubicacion> GetOne(int id);

        public List<Ubicacion> GetAll();

        public void Add(Ubicacion ubicacion);

        public void Delete(int id);
        
        public void Edit(int id, string nameLocation,bool expDate);

    }
}
