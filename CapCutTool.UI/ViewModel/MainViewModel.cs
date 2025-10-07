using CapCutTool.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public void ClickAnimation()
        {
            if (_draftService.InsertAnimation())
            {
                StatusAnimation = "Chèn Animation Thành Công";
            }
            else
            {
                StatusAnimation = "Chèn Animation Thất Bại";
            }
        }

        [RelayCommand]
        public void ClickEffect()
        {
            if (_draftService.InsertEffect())
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
