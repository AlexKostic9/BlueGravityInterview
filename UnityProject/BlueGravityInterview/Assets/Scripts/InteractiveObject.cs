using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    public UnityEvent OnPlayerEntered;
    public UnityEvent OnPlayerLeft;
    public UnityEvent OnItemUsed;

    [SerializeField] private Animator animatorComponent;

    [SerializeField] private string triggerNameOnPlayerApproach;
    [SerializeField] private string triggerNameOnPlayerLeave;

    public virtual void UseItem()
    {
        OnItemUsed?.Invoke();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            OnPlayerEntered?.Invoke();
            GameplayManager.Instance.SetActiveItem(this);
            if (animatorComponent != null)
            {
                animatorComponent.SetTrigger(triggerNameOnPlayerApproach);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            OnPlayerLeft?.Invoke();
            GameplayManager.Instance.ClearActiveItem(this);
            if (animatorComponent != null)
            {
                animatorComponent.SetTrigger(triggerNameOnPlayerLeave);
            }
        }
    }
}
