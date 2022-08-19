using UnityEngine;

public class HiddenArrayNumbersSetupSimple : PresenterSetup
{
    [SerializeField] private PanelSwitcher _switcher;
    [SerializeField] private TestPresenter _presenter;
    private protected override void PostAwake()
    {
        
    }

    private protected override void Click()
    {
        _switcher.Switch();
        _presenter.StartGame();
    }
}


