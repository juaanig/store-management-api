using store_management_api.Data.Repository.Interfaces;
using store_management_api.Entities;

namespace store_management_api.Data.Repository.implementations
{
    public class UbicRepository
    {
        public class UbicacionRepository : IUbicacionRepository
        {
            public static List<Ubicacion> ubicaciones = new List<Ubicacion>()
            {
                new Ubicacion("Enlatados" ,true),
                new Ubicacion("Tetras " ,false),
                new Ubicacion("Saches" ,true)
            };

            public void Add(Ubicacion ubicacion)
            {
                try
                {
                    ubicaciones.Add(ubicacion);
                }
                catch
                {
                    throw new Exception();
                }
            }

            public void Delete(int id)
            {
                try
                {
                    ubicaciones.Remove(ubicaciones.First(x => (x.Id).Equals(id)));
                }
                catch
                {
                    throw new Exception();
                }
            }

            public void Edit(int id, string nameLocation, Boolean expDate)
            {
                try
                {
                    ubicaciones.First(x => (x.Id).Equals(id)).NameLocation = nameLocation;
                    ubicaciones.First(x => (x.Id).Equals(id)).ExpDate = expDate;
                }
                catch
                {
                    throw new Exception();
                }
            }

            public List<Ubicacion> GetAll()
            {
                try
                {
                    return ubicaciones.ToList();
                }
                catch
                {
                    throw new Exception();
                };
            }

            public List<Ubicacion> GetOne(int id)
            {
                try
                {
                    return ubicaciones.Where(x => (x.Id).Equals(id)).ToList();
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
    }
}
