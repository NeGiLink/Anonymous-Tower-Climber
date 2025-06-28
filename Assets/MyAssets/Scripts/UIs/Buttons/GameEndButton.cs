using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    public class GameEndButton : MonoBehaviour
    {

        private Button mButton;

        private void Awake()
        {
            mButton = GetComponent<Button>();
        }

        private void Start()
        {
            if (mButton != null)
            {
                mButton.onClick.AddListener(Action);
            }
        }

        private void Action()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();//ゲームプレイ終了
#endif
        }
    }
}
