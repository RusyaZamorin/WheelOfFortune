using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace WheelOfFortune.StartScene
{
    public class StartButton : MonoBehaviour, IPointerDownHandler
    {
        public int LoadSceneIndex;

        public void OnPointerDown(PointerEventData eventData)
        {
            SceneManager.LoadScene(LoadSceneIndex);
        }
    }
}