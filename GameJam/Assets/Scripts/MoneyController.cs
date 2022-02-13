using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    private int amount = 1000000;
    public Text txt;

    private void Start()
    {
        txt.text = "$" + amount;
    }

    public void Remove(int a)
    {
        amount = Mathf.Clamp(amount - a, 0, 1000000);
        txt.text = "$" + amount;
    }
}
