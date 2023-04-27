using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{

    // Coloque no inspector a quantidade de andares que voc� quiser
    [SerializeField]
    Transform[] levels;

    int currentLevel;

    [SerializeField]
    int targetedLevel;

    [SerializeField]
    float elevatorSpeed;

    Rigidbody elevatorRb;

    // Start is called before the first frame update
    void Awake()
    {
        elevatorRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mudar andar desejado -> mude do jeito que quiser
        // recomendo colocar um trigger dentro do elevador, e verificar se o jogador est� no trigger antes do jogador poder mudar o elevador
        if (Input.GetKeyDown(KeyCode.W))
        {
            // IF especifico para evitar o erro (ArrayOutOfBounds)
            if (targetedLevel + 1 < levels.Length)
            {
                targetedLevel++;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // IF especifico para evitar o erro (ArrayOutOfBounds)
            if (targetedLevel - 1 >= 0)
            {
                targetedLevel--;
            }
        }

        // Verificar se o Elevador est� no andar desejado, se n�o tiver, o elevador ir� at� o andar
        if (transform.position.y != levels[targetedLevel].transform.position.y)
        {
            GoTo(levels[targetedLevel], elevatorRb);
        }

        // Fun��o que verifica em que andar o elevador est�
        CheckCurrentLevel(levels);
    }

    IEnumerator CheckCurrentLevel(Transform[] levels)
    {
        for (int c = 0; c < levels.Length; c++)
        {
            if (transform.position.y >= levels[c].transform.position.y)
            {
                currentLevel = c;

                yield return new WaitForSeconds(6.0f);
            }
        }
    }

    void GoTo(Transform target, Rigidbody Rb)
    {

        // Determinar� se o elevador ir� pra cima ou pra baixo
        if (target.position.y > Rb.position.y)
        {
            Rb.MovePosition(Rb.position + (Vector3.up * Time.deltaTime * elevatorSpeed));
        }

        else
        {
            Rb.MovePosition(Rb.position + (-Vector3.up * Time.deltaTime * elevatorSpeed));
        }

        // Verifica se o elevador est� proximo do ponto, para evitar tremidas indesejadas
        if (Vector3.Distance(target.position, Rb.position) < 0.05)
        {
            Rb.MovePosition(target.position);
        }
    }
}
