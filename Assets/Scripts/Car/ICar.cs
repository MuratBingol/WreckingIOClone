
    using UnityEngine;

    public interface ICar
    {
        void TakeDamage(Collision collision);
        void BeHappy();
        void BeSad();

        Rod GetRod();
        Transform GetTransform();
    }
