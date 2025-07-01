using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    // プレイヤーのライフを表示するUIコンポーネント
    public class PlayerLifeView : MonoBehaviour
    {
        private Text mLifeText;

        private void Awake()
        {
            mLifeText = GetComponentInChildren<Text>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            mLifeText.text = PlayerLifeManager.Life.ToString();
            Destroy(this);
        }
    }
}
