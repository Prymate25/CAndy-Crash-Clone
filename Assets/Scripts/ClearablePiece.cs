using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearablePiece : MonoBehaviour
{   public AnimationClip clearAnimation;
    private bool isBeingCleared=false;
    public bool IsBeingCleared{
        get{
            return isBeingCleared;
        }
    }
    protected GamePiece piece;
    // Start is called before the first frame update
    void Awake()
    {
        piece=GetComponent<GamePiece>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Clear(){
        piece.GridRef.level.OnPieceCleared(piece);
        isBeingCleared=true;
        StartCoroutine(ClearCoroutine());
    }
    private IEnumerator ClearCoroutine(){
        Animator animator=GetComponent<Animator>();
        if(animator){
            animator.Play(clearAnimation.name);

            yield return new WaitForSeconds(clearAnimation.length);
            Destroy(gameObject);
        }
    }
}
