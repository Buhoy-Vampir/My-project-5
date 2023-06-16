using TMPro;
using UnityEngine;

public class LoadText : MonoBehaviour
{
    private int i = 0;
    private float time = 0;
    public TextMeshProUGUI Text;

    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            i++;
            time = 0;
        }
        switch(i)
        {
            case 0:
                Text.text = "Загрузка";
                break;
            case 1:
                Text.text = "Загрузка.";
                break;
            case 2:
                Text.text = "Загрузка..";
                break;
            case 3:
                Text.text = "Загрузка...";
                break;
            case 4:
                i = 0;
                break;
        }
    }
}
