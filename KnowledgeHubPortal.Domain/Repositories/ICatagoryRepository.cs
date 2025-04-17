using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repositories
{
    public interface ICatagoryRepository
    {

        void Save(Catagory catagory);
        List<Catagory> GetAll();

        Catagory GetById(int id);
    }
}
