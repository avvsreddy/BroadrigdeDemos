using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repositories
{
    public interface ICatagoryRepository
    {

        void Save(Catagory catagory);
        List<Catagory> GetAll();

        Catagory GetById(int id);

        void Delete(int catagoryId);

        void Edit(Catagory catagory);

    }
}
