using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{


    //general attributes
    private string mon_name;
    private string age;
    private Image image;

    //fighting attributes
    private string attack;
    private string defense;
    private string specialPower;

    //others
    private int price;
    private string rank;
    private string type;
    private string leaderEffect;

    private void Awake()
    {
        
    }

    void getDataFromFireBase()
    {

    }


    public string getName()
    {
        return mon_name;
    }

    public string getAge()
    {
        return age;
    }

    public Image getImage()
    {
        return image;
    }

    public string getAttack()
    {
        return attack;
    }

    public string getDeffense()
    {
        return defense;
    }
}
