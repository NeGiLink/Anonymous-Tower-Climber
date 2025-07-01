namespace MyAssets
{
    // プレイヤーキャラクターに関するSEを管理するクラス
    public class PlayerSEManager : BaseSEManager
    {
        public enum SEList_Player
        {
            eNone = -1,
            eJump,
            eAttack,
            eDamage,
            eGetItem
        }
    }
}
