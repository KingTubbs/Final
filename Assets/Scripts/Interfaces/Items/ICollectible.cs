
namespace Interfaces.Items
{
    using UnityEngine;
    using Classes.Player;

    public interface ICollectible
    {
        void OnCollect(Player player);
        string GetName();
        Sprite GetIcon();
    }
}