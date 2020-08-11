public class PedestalExploreState : State
{
    private SetPedestalAndModel pedestalFrame;
    private PopulateInformationPanelContent infoPanel;
    private ProcessorData data;

    public PedestalExploreState(StateMachine source, ProcessorData data) : base(source)
    {
        this.data = data;
        this.name = nameof(PedestalExploreState);
    }

    public override void OnStateEnter()
    {
        pedestalFrame = (source as GameManager).pedestalFrame.
            GetComponent<TapToPlace>().GetLatestPedestal();
        pedestalFrame.SetModel(data);

        infoPanel = (source as GameManager).infoPanel.GetComponent<PopulateInformationPanelContent>();
        infoPanel.PopulateContent(data);
    }
}