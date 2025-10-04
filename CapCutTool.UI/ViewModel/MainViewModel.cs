using CapCutTool.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace CapCutTool.UI.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IPersonService _personService;

        [ObservableProperty]
        private string namePerson = string.Empty;

        [ObservableProperty]
        private int age;

        public MainViewModel(IPersonService personService)
        {
            _personService = personService;
        }

        [RelayCommand]
        public void Update()
        {
            (NamePerson, Age) = _personService.GetInfo();
        }
    }
}
