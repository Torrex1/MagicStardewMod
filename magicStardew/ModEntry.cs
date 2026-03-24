using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace magicStardew
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
        }

        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            // если предмета нет в инвентаре, то создаем его
            if (!Game1.player.Items.Any(item => item != null && item.ItemId == "MagicBook"))
            {
                Item magicBook = ItemRegistry.Create("MagicBook");

                if (!Game1.player.addItemToInventoryBool(magicBook))
                {
                    // если не удалось добавить в инвентарь, то выбрасываем его на землю
                    Game1.createItemDebris(magicBook, Game1.player.getStandingPosition(), Game1.player.FacingDirection);
                }
                this.Monitor.Log("Magic Book added to inventory or dropped on the ground.", LogLevel.Info);
            }
        }
    }
}
