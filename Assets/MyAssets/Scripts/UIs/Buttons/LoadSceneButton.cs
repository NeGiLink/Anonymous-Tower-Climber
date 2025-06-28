using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    public class LoadSceneButton : MonoBehaviour
    {
        private Button mButton;
        [SerializeField]
        private SceneList mSceneList;

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
            LoadSceneManager.LoadScene((int)mSceneList);
        }
    }
}
