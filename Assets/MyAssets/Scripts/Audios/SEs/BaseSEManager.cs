using UnityEngine;

namespace MyAssets
{
    // �x�[�X�ƂȂ�SE�Ǘ��N���X
    [RequireComponent(typeof(AudioSource))]
    public class BaseSEManager : MonoBehaviour
    {
        [SerializeField]
        protected AudioClipObjectList   mSEClipList;

        protected AudioSource           mAudioSource;

        protected virtual void Awake()
        {
            mAudioSource = GetComponent<AudioSource>();
        }

        public virtual void OnPlay(int se, float volum = 1.0f)
        {
            mAudioSource.volume = volum;
            mAudioSource.PlayOneShot(mSEClipList[se]);
        }
    }
}
