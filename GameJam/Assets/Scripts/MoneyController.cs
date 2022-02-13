using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    private int amount = 100000;
    public Text txt;

    private void Start()
    {
        txt.text = "$" + amount;
    }

    public void Remove(int a)
    {
        amount = Mathf.Clamp(0, 100000, amount - a);
        txt.text = "$" + amount;
    }
}
