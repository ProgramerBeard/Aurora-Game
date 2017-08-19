using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySheet : MonoBehaviour
{

    public Stat maxHealth;

    public float currentHealth { get; protected set; }

    public Stat maxEnergy;

    public float currentEnergy { get; protected set; }

    public Stat maxFocus;

    public float currentFocus { get; protected set; }

    public Stat physicalDefenese;
    public Stat magicalDefenese;

    public Action[] actions;
    public Effect[] effects;

    public List<Action> actionList;
    public List<Effect> effectList;

    public virtual void Awake()
    {
        currentHealth = maxHealth.GetValue();
        currentEnergy = maxEnergy.GetValue();
        currentFocus = 0;

        foreach (Action a in actions)
        {
            actionList.Add(a);
        }

        foreach (Effect e in effects)
        {
            effectList.Add(e);
        }
    }

    public virtual void Start()
    {
    }

    public void GainHealth(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth.GetValue())
        {
            currentHealth = maxHealth.GetValue();
        }
    }

    public void GainEnergy(float amount)
    {
        currentEnergy += amount;

        if (currentEnergy > maxEnergy.GetValue())
        {
            currentEnergy = maxEnergy.GetValue();
        }
    }

    public void GainFocus(float amount)
    {
        currentFocus += amount;

        if (currentFocus > maxFocus.GetValue())
        {
            currentFocus = maxFocus.GetValue();
        }
    }

    public void TakeDamage(float damage, Action.SuperTypes[] superTypes)
    {
        float damageReduction = 0;

        foreach (Action.SuperTypes st in superTypes)
        {
            if (st == Action.SuperTypes.PHYSCIAL)
            {
                damageReduction += physicalDefenese.GetValue();
            }
            else if (st == Action.SuperTypes.MAGICAL)
            {
                damageReduction += magicalDefenese.GetValue();
            }
        }

        damage -= damageReduction;

        if (damage < 0)
        {
            damage = 0;
        }

        TakeDamage(damage);
    }

    public void TakeDamage(float damage, Effect.SuperTypes[] superTypes)
    {
        float damageReduction = 0;

        foreach (Effect.SuperTypes st in superTypes)
        {
            if (st == Effect.SuperTypes.PHYSCIAL)
            {
                damageReduction += physicalDefenese.GetValue();
            }
            else if (st == Effect.SuperTypes.MAGICAL)
            {
                damageReduction += magicalDefenese.GetValue();
            }
        }

        damage -= damageReduction;

        if (damage < 0)
        {
            damage = 0;
        }

        TakeDamage(damage);
    }

    public void Die()
    {
        // Do things that dead things do.
    }

    public virtual Action PickAction() 
    {
        return null;
    }

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}