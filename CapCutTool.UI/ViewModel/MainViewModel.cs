using CapCutTool.Core.Json;
using CapCutTool.Core.Model;
using CapCutTool.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;
using System.Threading.Tasks;
namespace CapCutTool.UI.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDraftService _draftService;

        [ObservableProperty]
        private string statusAnimation = string.Empty;

        [ObservableProperty]
        private string statusEffect = string.Empty;

        [ObservableProperty]
        private string statusTransition = string.Empty;

        [ObservableProperty]
        private string statusSyncVoice = string.Empty;

        public MainViewModel(IDraftService draftService)
        {
            _draftService = draftService;
        }

        [RelayCommand]
        public async Task ClickAnimation()
        {
            var animationNeedAdd = new List<Materials.MaterialAnimation>();
            foreach (var animation in Data.Animations)
            {
                var temp = JsonSerializer.Deserialize<Materials.MaterialAnimation>(animation);
                animationNeedAdd.Add(temp);
            }

            if (!await _draftService.GetContext("clip_test"))
            {
                StatusAnimation = "Chèn Animation Thất Bại";
                return;
            }

            if (await _draftService.InsertAnimation(animationNeedAdd, 1, 2))
            {
                StatusAnimation = "Chèn Animation Thành Công";
            }
            else
            {
                StatusAnimation = "Chèn Animation Thất Bại";
            }
        }

        [RelayCommand]
        public async Task ClickEffect()
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                Converters = { new PropperCaseGuidJsonConverter() }
            };
            var effectNeedAdd = new List<Materials.VideoEffect>();
            foreach (var effect in Data.Effects)
            {
                var temp = JsonSerializer.Deserialize<Materials.VideoEffect>(effect, jsonSerializerOptions);
                effectNeedAdd.Add(temp);
            }

            if (!await _draftService.GetContext("clip_test"))
            {
                StatusEffect = "Chèn Effect Thất Bại";
                return;
            }

            if (await _draftService.InsertEffect(effectNeedAdd, 40, true))
            {
                StatusEffect = "Chèn Effect Thành Công";
            }
            else
            {
                StatusEffect = "Chèn Effect Thất Bại";
            }
        }

        [RelayCommand]
        public async Task ClickTransition()
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                Converters = { new PropperCaseGuidJsonConverter() }
            };
            var transitionNeedAdd = new List<Materials.Transition>();
            foreach (var effect in Data.Transitions)
            {
                var temp = JsonSerializer.Deserialize<Materials.Transition>(effect, jsonSerializerOptions);
                transitionNeedAdd.Add(temp);
            }

            if (!await _draftService.GetContext("clip_test"))
            {
                StatusTransition = "Chèn Transition Thất Bại";
                return;
            }

            if (await _draftService.InsertTransition(transitionNeedAdd))
            {
                StatusTransition = "Chèn Transition Thành Công";
            }
            else
            {
                StatusTransition = "Chèn Transition Thất Bại";
            }
        }

        [RelayCommand]
        public void ClickSyncVoid()
        {
            StatusSyncVoice = "Đồng Bộ Âm Thanh Thành Công";
        }
    }
}
