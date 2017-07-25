namespace Garbage.Core.Cards
{
    public interface ICard
    {
        Suit Suit { get; }
        CardValue Value { get; }

        void Discard();
        void Hide();
        void Lock();
        void Play();
        void Select();
        void Start();
    }
}