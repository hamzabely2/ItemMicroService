
using Context.Interface;
using Entity.Model;
using Mapper.DetailsItem;
using Model.DetailsItem;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class ColorService : ColorIService
    {
        private readonly ItemMicroServiceIDbContext _context;
        private readonly ColorIRepository _colorRepository;

        public ColorService(ItemMicroServiceIDbContext context,ColorIRepository colorRepository)
        {
            _context = context;
            _colorRepository = colorRepository;
        }

        /// <summary>
        /// adding details 
        /// </summary>
        public void AddColors()
        {
            var couleurs = new List<string>
            {
                "Rouge", "Bleu", "Vert", "Jaune", "Orange",
                "Violet", "Rose", "Gris", "Marron", "Noir", "Blanc",
            };
            foreach (var couleur in couleurs)
            {
                if (!_context.Colors.Any(c => c.Label == couleur))
                {
                    var nouvelleDonnee = new Color { Label = couleur };
                    _context.Colors.Add(nouvelleDonnee);
                }
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// get all colors
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<ColorDto>> GetAllColor()
        {
            var colors = await _colorRepository.GetAllAsync().ConfigureAwait(false);
            if (colors == null)
                throw new ArgumentException("l'action a échoué");

            List<ColorDto> colorList = new();
            foreach (Color color in colors)
            {
                colorList.Add(DatailsItemMapper.TransformExiteColor(color));
            }
           return colorList;
        }

        /// <summary>
        /// create color
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ColorDto> CreateColor(ColorDto request)
        {
            var color = DatailsItemMapper.TransformCreateColor(request);
            var LabelExiste = await _colorRepository.GetColorByName(request.Label);
            if(LabelExiste != null)
                throw new ArgumentException("l'action a échoué: la couleur existe déjà");

            var colorCreated = await _colorRepository.CreateElementAsync(color).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteColor(colorCreated);

        }

        /// <summary>
        /// delete color by id
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ColorDto> DeleteColor(int colorId)
        {
            var color = await _colorRepository.GetByKeys(colorId).ConfigureAwait(false);
            if(color == null)
                throw new ArgumentException("l'action a échoué: la couleur n'existe pas");

            var colorDelete = await _colorRepository.DeleteElementAsync(color).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteColor(colorDelete);
        }
    }
}
