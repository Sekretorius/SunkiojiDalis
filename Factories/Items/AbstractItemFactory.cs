namespace SunkiojiDalis {
  public abstract class AbstractItemFactory {
    public abstract AbstractWeapon CreateWeapon();
    public abstract AbstractArmor CreateArmor();
    public abstract AbstractPotion CreatePotion();
    public abstract AbstractFood CreateFood();
  }
}