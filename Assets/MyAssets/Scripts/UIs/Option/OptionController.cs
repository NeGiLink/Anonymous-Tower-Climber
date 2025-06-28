using UnityEngine;

namespace MyAssets
{
    public class OptionController : MonoBehaviour
    {
        [SerializeField]
        private DialogBox mDialogBox;

        // Update is called once per frame
        private void Update()
        {
            if(GameResultManager.GetGameResult() != GameResult.eNone) { return; }
            if(InputManager.GetKeyDown(KeyCode.eESC))
            {
                Canvas canvas = FindAnyObjectByType<Canvas>();
                if(mDialogBox != null )
                {
                    Instantiate(mDialogBox, canvas.transform);
                }
            }
        }
    }
}
