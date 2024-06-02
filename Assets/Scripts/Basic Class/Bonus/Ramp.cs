using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : Bonus, IPoolObject
{
    public string BonusName { get { return "Ramp"; } }
    public IEnumerator ActionBonus(GameObject Gobject)
    {
        yield return new WaitForSeconds(4f);
    }

    public override void Action(GameObject Gobject)
    {
        var gAction = Gobject.GetComponent<ICanGrapBonus>();
        if (gAction != null) { 
            gAction.SetBonus(ActionBonus(Gobject));
            this.gameObject.SetActive(false);
        }
    }

    public void DestroyPool()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivePool()
    {
        this.gameObject.SetActive(true);
    }
}
 