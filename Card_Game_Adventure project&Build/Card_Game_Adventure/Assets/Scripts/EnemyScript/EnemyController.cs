using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // -------------------------------------
    //見た目に関する操作(cardView)
    //データに関する操作(cardModel)
    // ---------------------------------------
    public EnemyView enemyView;
    public EnemyModel enemyModel;
    public CardModel cardModel;

    AudioSource audioSource;

    public List<AudioClip> audioClips = new List<AudioClip>();

    private void Awake()
    {
        enemyView = GetComponent<EnemyView>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void Init(int monsterID)
    { 
        enemyModel = new EnemyModel(monsterID);
        enemyView.Show(enemyModel);
    }

    public void CheckAudio()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }

    /// <summary>
    /// モンスターが生きているかどうかの処理
    /// </summary>
    public void CheckAlive()
    {
        if (enemyModel.isAlive)
        {
            enemyView.Refresh(enemyModel);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
