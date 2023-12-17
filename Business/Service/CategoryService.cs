using Context.Interface;
using Entity.Model;
using Mapper.DetailsItem;
using Model.DetailsItem;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ItemMicroServiceIDbContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ItemMicroServiceIDbContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;

        }

        /// <summary>
        /// adding details 
        /// </summary>
        public void AddCategories()
        {
            var categories = new List<string>
            {
                "Tagine", "Pot de conservation", "Pot de jardin"

            };

            foreach (var category in categories)
            {
                if (!_context.Categories.Any(c => c.Label == category))
                {
                    var nouvelleDonnee = new Category { Label = category };
                    _context.Categories.Add(nouvelleDonnee);
                }
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<CategoryDto>> GetAllCategory()
        {
            var categories = await _categoryRepository.GetAllAsync().ConfigureAwait(false);
            if (categories == null)
                throw new ArgumentException("l'action a échoué");

            List<CategoryDto> categoryList = new();
            foreach (Category categorie in categories)
            {
                categoryList.Add(DatailsItemMapper.TransformExiteCategory(categorie));
            }
            return categoryList;
        }

        /// <summary>
        /// create category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CategoryDto> CreateCategory(CategoryDto request)
        {
            var category = DatailsItemMapper.TransformCreateCategory(request);
            var LabelExiste = await _categoryRepository.GetCategoryByName(request.Label);
            if (LabelExiste != null)
                throw new ArgumentException("l'action a échoué: la catégorie existe déjà");

            var categoryCreated = await _categoryRepository.CreateElementAsync(category).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteCategory(categoryCreated);

        }

        /// <summary>
        /// delete category by id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<CategoryDto> DeleteCategory(int categoryId)
        {
            var category = await _categoryRepository.GetByKeys(categoryId).ConfigureAwait(false);
            if (category == null)
                throw new ArgumentException("l'action a échoué: la catégorie n'existe pas");

            var categoryDelete = await _categoryRepository.DeleteElementAsync(category).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteCategory(categoryDelete);
        }
    }


}
