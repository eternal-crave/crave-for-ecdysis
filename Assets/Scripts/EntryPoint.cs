using UnityEngine;
using Views;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private MainView mainView;
    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        var presenter = new MainViewPresenter(new MainViewModel(), mainView);
    }
}