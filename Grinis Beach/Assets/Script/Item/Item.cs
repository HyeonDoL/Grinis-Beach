using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string name;

    [SerializeField]
    private ItemSheet sheet;

    private ItemData data;

    public int NeedPearl { get; private set; }

    private void Awake()
    {
        for(int count = 0; count < sheet.m_data.Count; count++)
        {
            if (sheet.m_data[count].name == name)
            {
                data = sheet.m_data[count];
                break;
            }
        }

        NeedPearl = data.needPearl;
    }

    public virtual void Ability() { }
}