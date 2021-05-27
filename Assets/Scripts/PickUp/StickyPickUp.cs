public class StickyPickUp : BasePickUp
{
    #region Private methods

    protected override void ApplyEffect()
    {
        var pad = FindObjectOfType<Pad>();

        if (pad != null)
        {
            pad.MakeSticky(duration);
        }
    }

    #endregion
}
