using UnityEngine;

namespace MyAssets
{
    [RequireComponent(typeof(AudioSource))]
    public class BGMManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClipObjectList mAudionClipList;
        public enum BGMList
        {
            eNone = -1,
            eTitle,
            eGame,
            eClear,
            eOver
        }

        private AudioSource mAudioSource;

        private void Awake()
        {
            mAudioSource = GetComponent<AudioSource>();
        }

        public void Play(BGMList list,bool loop,float volum = 1.0f)
        {
            if (mAudionClipList[(int)list] == null) { return; }
            mAudioSource.Stop();
            mAudioSource.clip = mAudionClipList[(int)list];
            mAudioSource.loop = loop;
            mAudioSource.volume = volum;
            mAudioSource.Play();
        }

        public void Stop()
        {
            mAudioSource?.Stop();
        }
    }
}
