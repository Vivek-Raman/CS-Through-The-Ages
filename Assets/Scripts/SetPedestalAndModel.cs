using UnityEngine;

public class SetPedestalAndModel : MonoBehaviour
{
    [SerializeField] private ProcessorData processorData = null;

    private Transform holder = null;
    private Renderer frameLeft = null;
    private Renderer frameRight = null;

    private void Awake()
    {
        holder = this.transform.GetChild(0);
        frameLeft = this.transform.GetChild(1).GetComponent<Renderer>();
        frameRight = this.transform.GetChild(2).GetComponent<Renderer>();
    }

    [ContextMenu(nameof(SetModel))]
    public void SetModel(ProcessorData data)
    {
        processorData = data;
        for (int i = 0; i < holder.childCount; ++i)
        {
            Destroy(holder.GetChild(i).gameObject);
        }

        Instantiate(processorData.prefab, holder.position, holder.rotation, holder);

        frameLeft.materials[1].mainTexture = data.imageLeft;
        frameRight.materials[1].mainTexture = data.imageRight;

    }
}
