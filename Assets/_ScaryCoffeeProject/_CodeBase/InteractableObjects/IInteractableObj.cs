using Assets._ScaryCoffeeProject._CodeBase.Common;

namespace Assets._ScaryCoffeeProject._CodeBase.InteractableObjects
{
    public interface IInteractableObj
    {
        InteractableObjectType InteractableObjType { get; }

        void DisableInteraction();
        void EnableInteraction();
        void Use();
    }
}