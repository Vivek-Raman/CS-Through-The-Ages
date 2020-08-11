public class PedestalPlacementState : State
{
    private TapToPlace pedestalFrame = null;

    public PedestalPlacementState(StateMachine source) : base(source)
    {
        pedestalFrame = (source as GameManager).pedestalFrame.GetComponent<TapToPlace>();
        this.name = nameof(PedestalExploreState);
    }

    public override void OnStateEnter()
    {
        pedestalFrame.RecalculatePlacement();
    }

    public override void OnStateTick()
    {
        if (pedestalFrame.placed)
        {
            (source as GameManager).PlaceNextProcessor();
        }
    }
}