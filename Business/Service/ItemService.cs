
using Context.Interface;
using Entity.Model;
using Mapper.Item;
using Model.Item;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class ItemService : ItemIService
    {
        private readonly ItemIRepository _itemRepository;
        private readonly ColorIService _colorService;
        private readonly MaterialIService _materialService;
        private readonly CategoryIService _categoryService;
        private readonly ItemMicroServiceIDbContext _table;



        public ItemService(ItemMicroServiceIDbContext _idbcontext, ItemIRepository itemRepository,ColorIService colorService,MaterialIService materialService,CategoryIService categoryService)
        {
            _itemRepository = itemRepository;
            _colorService = colorService;
            _materialService = materialService;
            _categoryService = categoryService;
            _table = _idbcontext;

        }
       


        private async void AddingItemDetails()
        {
            _colorService.AddColors();
            _categoryService.AddCategories();
            _materialService.AddMaterials();
        }

        /// get item by id <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ItemDetailsDto> GetItemById(int itemId)
        {
            AddingItemDetails();
            var items =  _itemRepository.GetItemsWithDetails();
            var item = items.FirstOrDefault(item => item.Id == itemId);

            if (item == null)
                throw new ArgumentException("l'action a échoué: l'article ne existe pas");

            return ItemMapper.TransformDtoExitWithDetails(item);
        }

        /// list items> <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemDetailsDto>> GetListItem()
        {
            AddingItemDetails();

            var items =  _itemRepository.GetItemsWithDetails();
            if (items == null)
                throw new ArgumentException("l'action a échoué");

            return items.Select(item => ItemMapper.TransformDtoExitWithDetails(item)).ToList();
        }


        /// add item <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ItemDetailsDto> CreateItem(ItemAdd request)
        {
            AddingItemDetails();

           var itemToAdd = ItemMapper.TransformDtoAdd(request);
            var items = _itemRepository.GetItemsWithDetails();

            bool NameExiste = items.Any(NameExiste => NameExiste.Name == itemToAdd.Name);
            if (NameExiste == true)
                throw new ArgumentException("l'action a échoué: Le nom de l'article existe déjà.");

            if (itemToAdd.CategoryId == 0 || itemToAdd.MaterialId == 0 || itemToAdd.ColorId == 0)
                throw new ArgumentException("l'action a échoué: Les détails de l'article n'ont pas été précisés.");

            Item itemAdd = await _itemRepository.CreateElementAsync(itemToAdd).ConfigureAwait(false);

            if (itemAdd == null)
                throw new ArgumentException("l'action a échoué");
      

            return ItemMapper.TransformDtoExitWithDetails(itemAdd);
        }

        /// Update item <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public async Task<ItemDetailsDto> UpdateItem(ItemUpdate request, int itemId)
        {
            AddingItemDetails();

            var uniteGet = await _itemRepository.GetByKeys(itemId).ConfigureAwait(false);
            if (uniteGet == null)
                throw new ArgumentException("l'action a échoué : l'artcles n'a pas été trouvée");

            var item = _itemRepository.GetItemsWithDetails();

            if (request.Category == 0 || request.Material == 0 || request.Color == 0)
                throw new ArgumentException("l'action a échoué: Les détails de l'article n'ont pas été précisés.");

            var images = item.FirstOrDefault(i => i.Id == itemId).ImagesItems.FirstOrDefault().Images;
            if(images == null)
                throw new ArgumentException("l'action a échoué: errro sur les images");


            var itemDtoUpdate = ItemMapper.TransformDtoUpdate(request, uniteGet,images);
            var itemUpdate = await _itemRepository.UpdateElementAsync(itemDtoUpdate).ConfigureAwait(false);

            if (itemUpdate == null)
                throw new ArgumentException("l'action a échoué : l'articles n'a pas été modifie");


            return ItemMapper.TransformDtoExitWithDetails(itemUpdate);
        }

        /// Delete item <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ItemDetailsDto> DeleteItem(int itemId)
        {
            AddingItemDetails();

            var item = _itemRepository.GetItemsWithDetails().FirstOrDefault(item => item.Id == itemId); 
            if (item == null)
                throw new ArgumentException("l'action a échoué : l'article ne existe pas");

            Item itemDelete = await _itemRepository.DeleteElementAsync(item);

            var imagesItems = item.ImagesItems.ToList(); // Convertir en liste pour éviter une exception de modification en cours d'itération
            foreach (var imageItem in imagesItems)
            {
                var image = imageItem.Images;
                _table.Images.Remove(image);
                _table.ImagesItems.Remove(imageItem);
            }
            await _table.SaveChangesAsync();


            if (itemDelete == null)
                throw new ArgumentException("l'action a échoué : l'article n'a pas été supprime ");

            //var commentListComments = await _itemRepository.GetCommentOfAnItem(itemId);
           /* foreach (var comment in commentListComments)
            {
                await _itemRepository.DeleteElementAsync(comment);
            }*/

            return ItemMapper.TransformDtoExitWithDetails(itemDelete);
        }
    
}
}
