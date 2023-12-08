using Context.Interface;
using Entity.Model;
using Mapper.DetailsItem;
using Model.DetailsItem;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class MaterialService : MaterialIService
    {
        private readonly ItemMicroServiceIDbContext _context;
        private readonly MaterialIRepository _materialRepository;

        public MaterialService(ItemMicroServiceIDbContext context, MaterialIRepository materialRepository)
        {
            _context = context;
            _materialRepository = materialRepository;

        }

        /// <summary>
        /// adding details 
        /// </summary>
        public void AddMaterials()
        {
            var materials = new List<string>
            {
                "Argile rouge", "Argile blanche", "Argile chamottée", "Argile noire", "Argile grès",

            };

            foreach (var material in materials)
            {
                if (!_context.Materials.Any(c => c.Label == material))
                {
                    var nouvelleDonnee = new Material { Label = material };
                    _context.Materials.Add(nouvelleDonnee);
                }
            }

            _context.SaveChanges();
        }


        /// <summary>
        /// get all materials
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<MaterialDto>> GetAllMaterial()
        {
            var materials = await _materialRepository.GetAllAsync().ConfigureAwait(false);
            if (materials == null)
                throw new ArgumentException("l'action a échoué");

            List<MaterialDto> materialList = new();
            foreach (Material material in materials)
            {
                materialList.Add(DatailsItemMapper.TransformExiteMaterial(material));
            }
            return materialList;
        }

        /// <summary>
        /// create material
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MaterialDto> CreateMaterial(MaterialDto request)
        {
            var material = DatailsItemMapper.TransformCreateMaterial(request);
            var LabelExiste = await _materialRepository.GetMaterialByName(request.Label);
            if (LabelExiste != null)
                throw new ArgumentException("l'action a échoué: la matériel existe déjà");

            var materialCreated = await _materialRepository.CreateElementAsync(material).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteMaterial(materialCreated);

        }

        /// <summary>
        /// delete material by id
        /// </summary>
        /// <param name="materilId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<MaterialDto> DeleteMaterial(int materilId)
        {
            var material = await _materialRepository.GetByKeys(materilId).ConfigureAwait(false);
            if (material == null)
                throw new ArgumentException("l'action a échoué: la matériel n'existe pas");

            var materialDelete = await _materialRepository.DeleteElementAsync(material).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteMaterial(materialDelete);
        }
    }
}
