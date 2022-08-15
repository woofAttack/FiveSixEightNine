using UnityEngine;

public class TestGamePanelButtonGuessing : MonoBehaviour
{
    [SerializeField] private GamePanelButtonGuessing _gpbg;

    private void Awake() 
    {
        _gpbg.CreateGameNumberButtons(new  int[4] {5, 6, 8, 9}); 
        _gpbg.OnClickButtonNumber += (x) => Debug.Log(x.ToString());   
    }
}

