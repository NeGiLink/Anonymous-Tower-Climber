using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    //ボタンをキー入力で処理するための管理クラス
    public class ButtonController : MonoBehaviour
    {
        [SerializeField]
        private Sprite mNormal;
        public Sprite Normal => mNormal;
        [SerializeField]
        private Sprite mHover;
        public Sprite Hover => mHover;


        private List<Button> mButtons = new List<Button>();

        private Button mDecideButton;

        private Vector2 mBasePos;

        private Vector2 mBaseScale;

        private Vector2 mDecidePos = new Vector2(0.0f,-10.0f);

        private Vector2 mDecideScale = new Vector2(0.9f, 0.9f);

        private Timer mDecideTimer = new Timer();

        private void Awake()
        {
            Button[] buttons = GetComponentsInChildren<Button>();
            for(int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].gameObject.transform.parent.gameObject == gameObject)
                {
                    mButtons.Add(buttons[i]);
                }
            }
        }

        private void Start()
        {
            //初期選択ボタン
            mDecideButton = mButtons[0];

            mDecideTimer.OnEnd += DecideEndDirection;
        }

        // Update is called once per frame
        void Update()
        {
            mDecideTimer.Update(Time.unscaledDeltaTime);

            if(mButtons.Count <= 0) { return; }

            if(InputManager.GetKeyDown(KeyCode.eDecide))
            {
                DecideStartDirection();
            }
            if (!mDecideTimer.IsEnd()) { return; }
            Button[] buttons = GetSelectButtonPos();
            if(InputManager.GetKeyDown(KeyCode.eUpSelect))
            {
                if (buttons[0] != null)
                {
                    mDecideButton = buttons[0];
                }
            }
            else if(InputManager.GetKeyDown(KeyCode.eDownSelect))
            {
                if (buttons[1] != null)
                {
                    mDecideButton = buttons[1];
                }
            }

            if (InputManager.GetKeyDown(KeyCode.eLeftSelect))
            {
                if (buttons[2] != null)
                {
                    mDecideButton = buttons[2];
                }
            }
            else if (InputManager.GetKeyDown(KeyCode.eRightSelect))
            {
                if (buttons[3] != null)
                {
                    mDecideButton = buttons[3];
                }
            }

            for (int i = 0; i < mButtons.Count; i++)
            {
                if (mButtons[i] == mDecideButton)
                {
                    mButtons[i].image.sprite = mHover;
                }
                else
                {
                    mButtons[i].image.sprite = mNormal;
                }
            }
        }

        private void DecideEndDirection()
        {
            mDecideButton.transform.position = mBasePos;
            mDecideButton.transform.localScale = mBaseScale;
            mDecideButton.onClick.Invoke();
        }
        private void DecideStartDirection()
        {
            mBasePos = mDecideButton.transform.position;
            mBaseScale = mDecideButton.transform.localScale;

            mDecideButton.transform.position = mBasePos + mDecidePos;
            mDecideButton.transform.localScale = mDecideScale;
            mDecideTimer.Start(0.5f);
        }
        //現在選択されているボタンの位置からもっとも近い
        //上下左右のボタンを選択
        private Button[] GetSelectButtonPos()
        {
            Button[] buttons = new Button[4];

            for(int i = 0; i < mButtons.Count;i++)
            {
                if(mButtons[i] == mDecideButton) { continue; }
                Transform rectTransform = mButtons[i].transform;
                Transform decideRect = mDecideButton.transform;
                if(decideRect.position.y <= rectTransform.position.y)
                {
                    buttons[0] = mButtons[i];
                }
                else if (decideRect.position.y >= rectTransform.position.y)
                {
                    buttons[1] = mButtons[i];
                }

                if (decideRect.position.x <= rectTransform.position.x)
                {
                    buttons[3] = mButtons[i];
                }
                else if (decideRect.position.x >= rectTransform.position.x)
                {
                    buttons[2] = mButtons[i];
                }
            }

            return buttons;
        }
    }
}
