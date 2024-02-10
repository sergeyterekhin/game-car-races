using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMoved : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RoadMove());
        StartCoroutine(BackgroundMove());
        StartCoroutine(El1BackgroundMove());
        StartCoroutine(El2BackgroundMove());
    }


    IEnumerator El2BackgroundMove()
    {
        while (true)
        {
            GameObject[] elbgObjects = GameObject.FindGameObjectsWithTag("el2bg");
            foreach (GameObject elbackground in elbgObjects)
            {
                GameElementsController scriptelbackground = elbackground.GetComponent<GameElementsController>();
                scriptelbackground.Move();
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator El1BackgroundMove()
    {
        while (true)
        {
            GameObject[] elbgObjects = GameObject.FindGameObjectsWithTag("el1bg");
            foreach (GameObject elbackground in elbgObjects)
            {
                GameElementsController scriptelbackground = elbackground.GetComponent<GameElementsController>();
                scriptelbackground.Move();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator BackgroundMove()
    {
        while (true)
        {
            GameObject[] bgObjects = GameObject.FindGameObjectsWithTag("Background");
            foreach (GameObject background in bgObjects)
            {
                GameElementsController scriptbackground = background.GetComponent<GameElementsController>();
                scriptbackground.Move();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator RoadMove()
    {
        while (true)
        {
            GameObject[] roadObjects = GameObject.FindGameObjectsWithTag("Road");
            foreach(GameObject road in roadObjects)
            {
                GameElementsController scriptRoad = road.GetComponent<GameElementsController>();
                scriptRoad.Move();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}

/* 
 РАЗОБРАТЬСЯ С МНОГОПОТОЧНОСТЬЮ!!

 Оказывается Coroutine работают в одном потоке
 и выполняются после базовых методов Update FixedUpdate 
 надо сделать так чтобы объекты двигались в разных потоках
 (если можно, не знаю) не нравится что все выполняется после
 базовых событий юнити

Использование многопоточности в Unity имеет несколько потенциальных минусов:
1. Сложность синхронизации: Работа с многопоточностью требует правильной синхронизации доступа к общим данным.
Неправильная синхронизация может привести к состоянию гонки или блокировке, что может вызвать непредсказуемое поведение приложения.

2. Усложнение отладки: Отладка многопоточного кода может быть сложной задачей. Состояние гонки и другие проблемы, 
связанные с многопоточностью, могут проявляться нестабильно и быть трудно воспроизводимыми.

3. Нарушение потокобезопасности Unity API: Некоторые части Unity API не являются потокобезопасными и могут вызывать 
проблемы при использовании многопоточности. Например, многопоточный доступ к объектам Unity, таким как GameObject 
или компоненты, может вызвать ошибки или непредсказуемое поведение.

4. Возможные проблемы с производительностью: Использование многопоточности может привести к увеличению накладных 
расходов на синхронизацию и управление потоками, что может негативно сказаться на производительности приложения. 
В некоторых случаях, использование многопоточности может быть неоправданным из-за незначительного выигрыша в производительности.

5. Ограничения многопоточности в Unity: Unity имеет некоторые ограничения на использование многопоточности. Например, многопоточный
доступ к графическому контексту может вызвать ошибки или непредсказуемое поведение.

Использование многопоточности в Unity требует осторожного подхода и должно быть хорошо обосновано.
*/