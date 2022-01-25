namespace CakeStoreApi.Models
{
    public interface IData
    {
        public  List<CakeStore>? CakesList { get; set; }
        public List<CakeStore> CakesInitializeData();
        public CakeStore? GetCakeById(int?  id);
    }
}
