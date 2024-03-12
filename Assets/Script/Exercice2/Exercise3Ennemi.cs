public class Exercise3Ennemi : Exercise2Ennemi {
    public override void TakeDamage() {
        if (_animator!=null)_animator.SetTrigger("TakeDamage"); 
        base.TakeDamage();
    }
}