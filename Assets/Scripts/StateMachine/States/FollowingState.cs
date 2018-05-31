using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingState : IState
{
    private float followSpeed = 4;
    private Transform follower;
    private Transform playerToFollow;
    private TextMesh smileIcon;

    public FollowingState(GameObject _follower, Collision2D _playerToFollow, TextMesh _smileIcon)
    {
        follower = _follower.transform;
        playerToFollow = _playerToFollow.transform;
        smileIcon = _smileIcon;
    }

    public void Enter()
    {
        follower.GetComponent<Follower>().StartCoroutine(ShowSmiley());
    }

    public void Execute()
    {
        follower.position = Vector2.MoveTowards(follower.position, playerToFollow.position, followSpeed * Time.deltaTime);
    }

    public void Exit()
    {
        
    }

    private IEnumerator ShowSmiley()
    {
        smileIcon.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        smileIcon.gameObject.SetActive(false);
    }
}
