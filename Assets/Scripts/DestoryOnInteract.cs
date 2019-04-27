public class DestoryOnInteract : Interactable
{
    public override void OnInteract()
    {
        Destroy(this.gameObject);
    }
}
