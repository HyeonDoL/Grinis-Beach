using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemSheet sheet;

    private ItemData data;

    public int NeedPearl { get; private set; }

    public virtual string Name()
    {
        return "";
    }

    private void Awake()
    {
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