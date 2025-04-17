using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;

namespace KnowledgeHubPortal.Data
{
    public class CatagoryRepository : ICatagoryRepository
    {
        private KHPortalDbContext _context;

        public CatagoryRepository(KHPortalDbContext context)
        {
            this._context = context;
        }
        public List<Catagory> GetAll()
        {
            return _context.Catagories.ToList();
        }

        public Catagory GetById(int id)
        {
            return _context.Catagories.Find(id);
        }

        public void Save(Catagory catagory)
        {
            _context.Catagories.Add(catagory);
            _context.SaveChanges();
        }
    }
}
