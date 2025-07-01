using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    // �Q�[���X�R�A��\������UI�N���X
    public class GameScoreView : MonoBehaviour
    {
        private Text mScoreText;

        private void Awake()
        {
            mScoreText = GetComponentInChildren<Text>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            GameScoreManager.OnEvent += ViewUpdate;
        }

        private void OnDisable()
        {
            GameScoreManager.OnEvent -= ViewUpdate;
        }

        public void ViewUpdate()
        {
            mScoreText.text = "Score : " + GameScoreManager.TotalScore.ToString().PadLeft(7,'0');
        }
    }
}
