using Animal_Shelter.Data.Entities;

namespace Animal_Shelter.Interfaces
{
    public interface IFavService
    {
        List<int> GetItemIds();
        List<AnimalQuestionnaire> GetAnimals();

        void Add(int id);
        void Remove(int id);
        void Clear();
        int GetFavSize();
    }
}
