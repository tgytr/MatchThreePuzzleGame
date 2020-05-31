using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class monster_lib_handler : MonoBehaviour
{

    public GameObject monster_panel;
    Animator anim_monsterPanel;

    public GameObject monster_tilePrefab;

    string[] monster_list= {"coolCloud","theFirst","moneyMaker","horseMan" };


    public void InitMonsterLib()
    {
        StartCoroutine(OpenMenu());
    }

    IEnumerator OpenMenu()
    {
        anim_monsterPanel = monster_panel.GetComponent<Animator>();

        if (monster_panel != null)
        {
            bool isActive = monster_panel.activeSelf;


            //checked if the panel is active when button pressed
            if (!isActive)
            {
                monster_panel.SetActive(true);

                //change open property of the animation true to start it
                anim_monsterPanel.SetBool("open", true);
                yield return new WaitForSeconds(0.8f);
                FillMonsterPanel();
            }
            else
            {
                anim_monsterPanel.SetBool("open", false);

                //wait for some time to finish close anim
                yield return new WaitForSeconds(0.6f);

                //after anim finishes set panel inactive
                monster_panel.SetActive(false);
            } 
        }
        yield return null;
    }

    void FillMonsterPanel()
    {
        var rectTransform = monster_panel.GetComponent<RectTransform>();
        int width = (int) rectTransform.rect.width;

        int prefabSize = 150;
        int numPrefabsInColumn = (width - width % prefabSize) / prefabSize;


        for (int i = 0; i < numPrefabsInColumn; i++)
        {
            //GameObject tile = Instantiate(monster_tilePrefab, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
        }
    }
}
