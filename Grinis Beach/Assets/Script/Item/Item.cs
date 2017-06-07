using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemSheet defaultSheet;

    private ItemData data;

    public int NeedPearl { get; private set; }

    public virtual string Name() { return ""; }

    protected virtual ItemSheet Sheet()
    {
        return defaultSheet;
    }

    private void Awake()
    {
        ItemSheet sheet = Sheet();

        for(int count = 0; count < sheet.m_data.Count; count++)
        {
            if (sheet.m_data[count].name == Name())
            {
                data = sheet.m_data[count];
                break;
            }
        }

        NeedPearl = data.needPearl;
    }

    public virtual void Ability() { }
}