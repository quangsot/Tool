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

            if(!await _draftService.GetContext("clip_test"))
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
            if (await _draftService.InsertEffect())
            {
                StatusEffect = "Chèn Effect Thành Công";
            }
            else
            {
                StatusEffect = "Chèn Effect Thất Bại";
            }
        }

        [RelayCommand]
        public void ClickTransition()
        {
            StatusTransition = "Chèn Transition Thành Công";
        }

        [RelayCommand]
        public void ClickSyncVoid()
        {
            StatusSyncVoice = "Đồng Bộ Âm Thanh Thành Công";
        }
    }
}
