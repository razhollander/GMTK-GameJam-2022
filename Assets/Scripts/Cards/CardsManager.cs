using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private GameObject cardGO;
    [SerializeField] private Image cardImage;
    [SerializeField] private List<Card> _cards;
    [SerializeField] private int cardAnimationSpeedMilliSeconds = 100;
    [SerializeField] private int numberOfRandomness = 10;
    [SerializeField] private Vector2 minMaxGameEventDuration = new Vector2(10, 15);
    
    private GameEvent _chosenGameEvent;
    
    
    [ContextMenu("Fire")]
    public async void GenerateRandomCard()
    {
        cardGO.SetActive(true);
        await RunCardRandom();
        GameManager.Instance.GameEventsSystem.FireGameEvent(_chosenGameEvent);
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        var duration = Random.Range(minMaxGameEventDuration.x, minMaxGameEventDuration.y+1);
        
        while (duration>0)
        {
            duration -= Time.deltaTime;

            yield return null;
        }

        GenerateRandomCard();
    }

    private async UniTask RunCardRandom()
    {
        var numOfGameEvents = Enum.GetValues(typeof(GameEvent)).Length;

        GameEvent newGameEvent = _chosenGameEvent;

        for (int i = 0; i < numberOfRandomness; i++)
        {
            newGameEvent = _chosenGameEvent;
            
            while (newGameEvent == _chosenGameEvent)
            {
                var rnd = UnityEngine.Random.Range(0, numOfGameEvents);
                Debug.Log("event "+rnd.ToString());

                newGameEvent = (GameEvent)rnd;
            }
            cardImage.sprite = _cards.Find(x => x.CardGameEvent == newGameEvent).CardImage;
            await UniTask.Delay(cardAnimationSpeedMilliSeconds);
        }

        _chosenGameEvent = newGameEvent;
        Debug.Log("Chosen: "+_chosenGameEvent);
    }


}
