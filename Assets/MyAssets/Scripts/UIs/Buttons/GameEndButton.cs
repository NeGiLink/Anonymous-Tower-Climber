using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    // ゲーム終了ボタンのクラス
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
            InputManager.Shutdown();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();//ゲームプレイ終了
#endif
        }
    }
}
