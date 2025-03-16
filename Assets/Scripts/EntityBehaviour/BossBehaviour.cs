using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehaviour : EnemyBehaviour
{
    protected override void Die()
    {
        base.Die();
        SceneManager.LoadScene("KinoBoss");
    }
}
