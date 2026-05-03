using System.Collections;
using UnityEngine;

public class Chair : Interactable
{
    public float focusTime = 3f;
    bool isChecking = false;

    public override void Interact()
    {
        if (isSatisfied || isChecking) return;

        StartCoroutine(FocusCheck());
    }

    IEnumerator FocusCheck()
    {
        isChecking = true;

        DialogueManager.instance.ShowDialogue(new string[]
        {
            "Chair: Look at me properly...",
            "Chair: Don’t lose focus."
        });

        yield return new WaitForSeconds(1f);

        float timer = 0f;

        while (timer < focusTime)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f))
            {
                // Check if still looking at THIS chair
                if (hit.collider.GetComponentInParent<Chair>() == this)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    Fail();
                    yield break;
                }
            }
            else
            {
                Fail();
                yield break;
            }

            yield return null;
        }

        isSatisfied = true;
        GameManager.instance.chairDone = true;

        DialogueManager.instance.ShowDialogue(new string[]
        {
            "Chair: Hm… you can focus.",
            "Chair: Acceptable."
        });

        isChecking = false;
    }

    void Fail()
    {
        DialogueManager.instance.ShowDialogue(new string[]
        {
            "Chair: You lost focus.",
            "Chair: Try again."
        });

        isChecking = false;
    }
}