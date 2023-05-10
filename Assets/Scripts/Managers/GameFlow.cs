using UnityEngine;
using Views;

namespace Managers
{
    public class GameFlow : MonoBehaviour
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
}