using PropertyApp.ViewModel;

namespace PropertyApp.View;

public partial class SetTitleAndDescriptionPage : ContentPage
{
    public SetTitleAndDescriptionPage(SetTitleAndDescriptionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
