namespace MyAssets
{
    //�Q�[���̃V�X�e���Ɋւ���SE���Ǘ�����N���X
    public class SystemSEManager : BaseSEManager
    {
        private static SystemSEManager  instance;

        public static SystemSEManager   Instance => instance;

        public enum SEList_System
        {
            None = -1,
            Decide,
            Select,
            DecreaseLife,
            EnemyDead
        }

        protected override void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            base.Awake();
        }
    }
}
